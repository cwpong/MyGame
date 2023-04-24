using ET.Demo.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(SessionPlayerComponent))]
    [FriendClass(typeof(SessionStateComponent))]
    [FriendClass(typeof(Player))]
    [FriendClass(typeof(GateMapComponent))]
    ///GateMapComponent
    public class C2G_EnterGameHandler : AMRpcHandler<C2G_EnterGame, G2C_EnterGame>
    {
        protected override async ETTask Run(Session session, C2G_EnterGame request, G2C_EnterGame response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error($"请求的Scene错误, 当前Scene为: {session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            var sessionPlayerComponent = session.GetComponent<SessionPlayerComponent>();
            if (sessionPlayerComponent == null)
            {
                response.Error = ErrorCode.ERR_SessionPlayerError;
                reply();
                return;
            }

            var player = Game.EventSystem.Get(sessionPlayerComponent.PlayerInstanceId) as Player;
            if (player == null || player.IsDisposed)
            {
                response.Error = ErrorCode.ERR_NonePayerError;
                reply();
                return;
            }

            var instanceId = session.InstanceId;

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.Account.GetHashCode()))
                {
                    if (instanceId != session.InstanceId || player.IsDisposed)
                    {
                        response.Error = ErrorCode.ERR_PlayerSessionError;
                        reply();
                        return;
                    }

                    // 不存在或者已在游戏服中
                    if (session.GetComponent<SessionStateComponent>() != null
                            && session.GetComponent<SessionStateComponent>().State == SessionState.Game)
                    {
                        response.Error = ErrorCode.ERR_SessionPlayerError;
                        reply();
                        return;
                    }

                    // 顶号
                    if (player.PlayerState == PlayerState.Game)
                    {
                        try
                        {
                            var reqEnter = await MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestEnterGameState());
                            if (reqEnter.Error == ErrorCode.ERR_Success)
                            {
                                reply();
                                return;
                            }

                            Log.Error("二次登陆失败");
                            response.Error = ErrorCode.ERR_EnterGameError;
                            await DisconnectHelper.KickPlayer(player, true);
                            reply();
                            session?.Disconnect().Coroutine();
                        }
                        catch (Exception ex) 
                        {
                            Log.Error("二次登录失败  " + ex.ToString());
                            response.Error = ErrorCode.ERR_EnterGameError;
                            await DisconnectHelper.KickPlayer(player, true);
                            reply();
                            session?.Disconnect().Coroutine();
                            throw;
                        }

                        return;
                    }
                    // 正常状态
                    else
                    {
                        try
                        {
                            //var gateMapComponent = player.AddComponent<GateMapComponent>();
                            //gateMapComponent.Scene = await SceneFactory.Create(gateMapComponent, "GateMap", SceneType.Map);
                            //var unit = UnitFactory.Create(gateMapComponent.Scene, player.Id, UnitType.Player);

                            // 从数据库或者缓存中加载处Unti实体及其相关组件
                            (bool isNewPlayer, Unit unit) = await UnitHelper.LoadUnit(player);
                            // 二次登陆时这个session会被释放，后端就无法找到对应的客户端unit
                            //unit.AddComponent<UnitGateComponent, long>(session.InstanceId);
                            // 顶号时player不会被改变
                            unit.AddComponent<UnitGateComponent, long>(player.InstanceId);

                            // 玩家上线后的初始化操作
                            await UnitHelper.InitUnit(unit, isNewPlayer);

                            var unitId = unit.Id;
                            response.MyId = unitId;
                            reply();

                            var startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "Game");
                            await TransferHelper.Transfer(unit, startSceneConfig.InstanceId, startSceneConfig.Name);
                                    
                            var sessionStateComponent = session.GetComponent<SessionStateComponent>();
                            if (sessionStateComponent == null)
                                sessionStateComponent = session.AddComponent<SessionStateComponent>();

                            sessionStateComponent.State = SessionState.Game;
                            player.PlayerState = PlayerState.Game;
                        }
                        catch (Exception e)
                        {
                            response.Error = ErrorCode.ERR_EnterGameError;
                            reply();
                            await DisconnectHelper.KickPlayer(player, true);
                            Log.Error($"角色进入游戏逻辑服出现问题 {e}");
                        }
                    }
                }
            }
        }
    }
}
