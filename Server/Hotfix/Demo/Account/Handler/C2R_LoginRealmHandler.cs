using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.Account.Handler
{
    public class C2R_LoginRealmHandler : AMRpcHandler<C2R_LoginRealm, R2C_LoginRealm>
    {
        protected override async ETTask Run(Session session, C2R_LoginRealm request, R2C_LoginRealm response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Realm)
            {
                Log.Error($"请求的Scene错误， 当前Scene为 {session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            var domainScene = session.DomainScene();
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            var token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (token == null || token != request.RealmTokenKey)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            // 只需要连接一次
            domainScene.GetComponent<TokenComponent>().Remove(request.AccountId);

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait((int)CoroutineLockType.LoginRealm, request.AccountId))
                {
                    // 取模固定分配一个网关
                    var config = RealmGateAddressHelper.GetGate(domainScene.Zone, request.AccountId);

                    // 向网关请求一个Key，客户端可以拿着这个Key连接网关
                    var g2R_GetLoginGateKey = (G2R_GetLoginGateKey)await MessageHelper.CallActor(config.InstanceId, new R2G_GetLoginGateKey()
                    {
                        AccountId = request.AccountId,

                    });

                    if (g2R_GetLoginGateKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = g2R_GetLoginGateKey.Error;
                        reply();
                        return;
                    }

                    response.GateSessionKey = g2R_GetLoginGateKey.GateSessionKey;
                    response.GateAddress = config.OuterIPPort.ToString();
                    reply();

                    session?.Disconnect().Coroutine();  
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
