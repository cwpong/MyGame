using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class C2A_GetRealmKeyHandler : AMRpcHandler<C2A_GetRealmKey, A2C_GetRealmKey>
    {
        protected override async ETTask Run(Session session, C2A_GetRealmKey request, A2C_GetRealmKey response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误， 当前Scene为 :{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_RequestRepeatedly;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            var token = session.DomainScene().GetComponent<TokenComponent>().Get(request.AccountId);
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                // 上线逻辑(1) 17分钟
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, request.AccountId))
                {
                    var realmStartSceneConfig = RealmGateAddressHelper.GetRealm(request.ServerId);
                    // 进程间通信
                    var r2a_GetRealmKey = (R2A_GetRealmKey) await MessageHelper.CallActor(realmStartSceneConfig.InstanceId, new A2R_GetRealmKey()
                    {
                        AccountId = request.AccountId,
                    });

                    if (r2a_GetRealmKey.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = r2a_GetRealmKey.Error;
                        reply();
                        session?.Disconnect().Coroutine();
                        return;
                    }

                    response.Realmkey = r2a_GetRealmKey.RealmKey;
                    response.RealmAddress = realmStartSceneConfig.OuterIPPort.ToString();
                    reply();
                    session?.Disconnect().Coroutine();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
