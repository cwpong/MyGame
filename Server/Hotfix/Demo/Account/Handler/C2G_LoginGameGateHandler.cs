using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.Account.Handler
{
    [FriendClass(typeof(Player))]
    [FriendClass(typeof(SessionPlayerComponent))]
    [FriendClass(typeof(SessionStateComponent))]
    public class C2G_LoginGameGateHandler : AMRpcHandler<C2G_LoginGameGate, G2C_LoginGameGate>
    {
        protected override async ETTask Run(Session session, C2G_LoginGameGate request, G2C_LoginGameGate response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Gate)
            {
                Log.Error($"请求的Scene错误, 当前Scene为; {session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            // 长连接 需要移除这个
            session.RemoveComponent<SessionAcceptTimeoutComponent>();
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                return;
            }

            var scene = session.DomainScene();
            var tokenKey = scene.GetComponent<GateSessionKeyComponent>().Get(request.Account);
            if (tokenKey == null || !tokenKey.Equals(request.Key))
            {
                response.Error = ErrorCode.ERR_ConnectGateKeyError;
                response.Message = "Gate Key 验证失败";
                reply();
                session?.Disconnect().Coroutine();
            }

            scene.GetComponent<GateSessionKeyComponent>().Remove(request.Account);
            var instanceId = session.InstanceId;
            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, request.Account.GetHashCode()))
                {
                    if (instanceId != session.InstanceId)
                        return;

                    // 通知登陆中心服 记录本次登陆的服务器zone
                    var loginCenterConfig = StartSceneConfigCategory.Instance.LoginCenterConfig;
                    L2G_AddLoginRecord l2G_AddLoginRecord = null;

                    try
                    {
                        l2G_AddLoginRecord = (L2G_AddLoginRecord)await MessageHelper.CallActor(loginCenterConfig.InstanceId,
                                                                        new G2L_AddLoginRecord()
                                                                        {
                                                                            AccountId = request.Account,
                                                                            ServerId = scene.Zone,
                                                                        });

                        if (l2G_AddLoginRecord.Error != ErrorCode.ERR_Success)
                        {
                            response.Error = l2G_AddLoginRecord.Error;
                            reply();
                            session?.Disconnect().Coroutine();
                            return;
                        }

                        var sessionStateComponent = session.GetComponent<SessionStateComponent>();
                        if (sessionStateComponent == null)
                            sessionStateComponent = session.AddComponent<SessionStateComponent>();

                        sessionStateComponent.State = SessionState.Normal;

                        var player = scene.GetComponent<PlayerComponent>().Get(request.Account);
                        if (player == null)
                        {
                            // 添加一个新的GateUnit映射
                            player = scene.GetComponent<PlayerComponent>().AddChildWithId<Player, long, long>(
                                                                            request.RoleId, request.Account, request.RoleId);

                            player.PlayerState = PlayerState.Gate;
                            scene.GetComponent<PlayerComponent>().Add(player);
                            session.AddComponent<MailBoxComponent, MailboxType>(MailboxType.GateSession);
                        }
                        else
                        {
                            // 处于倒计时下线状态
                            player.RemoveComponent<PlayerOfflineOutTimeComponent>();
                        }

                        session.AddComponent<SessionPlayerComponent>().PlayerId = player.Id;
                        session.GetComponent<SessionPlayerComponent>().PlayerInstanceId = player.InstanceId;
                        session.GetComponent<SessionPlayerComponent>().AccountId = request.Account;
                        player.SessionInstanceId = session.InstanceId;
                        player.ClientSession = session;
                        reply();
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex);
                        reply();
                    }
                }
            }
        }
    }
}
