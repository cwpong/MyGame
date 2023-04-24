using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(Player))]
    [FriendClass(typeof(SessionPlayerComponent))]
    [ActorMessageHandler]
    public class L2G_DisconnectGateUnitHandler : AMActorRpcHandler<Scene, L2G_DisconnectGateUnit, G2L_DisconnectGateUnit>
    {
        protected override async ETTask Run(Scene scene, L2G_DisconnectGateUnit request, G2L_DisconnectGateUnit response, Action reply)
        {
            var accountId = request.AccountId;

            // 跟登陆gate的时候保持一致
            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginGate, accountId.GetHashCode()))
            {
                var playerComponent = scene.GetComponent<PlayerComponent>();
                var player = playerComponent.Get(accountId);

                if (player == null)
                {
                    reply();
                    return;
                }

                scene.GetComponent<GateSessionKeyComponent>().Remove(accountId);
                //var gateSession = Game.EventSystem.Get(player.SessionInstanceId) as Session;
                var gateSession = player.ClientSession;
                if (gateSession != null && !gateSession.IsDisposed)
                {
                    // 顶号之前记录
                    if(gateSession.GetComponent<SessionPlayerComponent>() != null)
                        gateSession.GetComponent<SessionPlayerComponent>().IsLoginAgin = true;

                    // 向被顶号的人发送踢下线
                    gateSession.Send(new A2C_Disconnect() { Error = ErrorCode.ERR_OtherAccountLogin });
                    gateSession?.Disconnect().Coroutine();
                }

                player.SessionInstanceId = 0;
                playerComponent.Remove(accountId);
                player.Dispose();
            }

            reply();
        }
    }
}
