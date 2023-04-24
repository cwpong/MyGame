using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(Player))]
    public static class DisconnectHelper
    {
        public static async ETTask Disconnect(this Session self)
        {
            if (self == null || self.IsDisposed)
                return;

            var instanceId = self.InstanceId;
            await TimerComponent.Instance.WaitAsync(1000);

            // session有可能被释放过了 所以需要校验
            if (self.InstanceId != instanceId)
                return;

            self.Dispose();
        }

        public static async ETTask KickPlayer(Player player, bool isException = false)
        {
            if (player == null || player.IsDisposed)
                return;

            var instanceId = player.InstanceId;
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, player.Account.GetHashCode()))
            {
                if (player.IsDisposed || instanceId != player.InstanceId)
                    return;


                if (!isException)
                {
                    switch (player.PlayerState)
                    {
                        case PlayerState.Disconnect:
                            break;

                        case PlayerState.Gate:
                            break;

                        case PlayerState.Game:
                            // 通知游戏逻辑服下线Unit角色逻辑，并将数据存入数据库
                            var m2gRequestExitGame = (M2G_RequestExitGame)await MessageHelper.CallLocationActor(player.UnitId, new G2M_RequestExitGame());
                            // 通知移除账号角色登陆信息
                            var loginCenterConfigSceneId = StartSceneConfigCategory.Instance.LoginCenterConfig.InstanceId;
                            var L2GRemoveLoginRecord = (L2G_RemoveLoginRecord)await MessageHelper.CallActor(loginCenterConfigSceneId, new G2L_RemoveLoginRecord()
                            {
                                AccountId = player.Account,
                                ServerId = player.DomainZone()
                            });

                            break;
                    }
                }
                

                player.PlayerState = PlayerState.Disconnect;
                player.DomainScene().GetComponent<PlayerComponent>()?.Remove(player.Account);
                player?.Dispose();
                await TimerComponent.Instance.WaitAsync(300);
            }
        }
    }
}
