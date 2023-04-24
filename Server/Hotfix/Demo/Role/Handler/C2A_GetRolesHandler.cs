using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public class C2A_GetRolesHandler : AMRpcHandler<C2A_GetRoles, A2C_GetRoles>
    {
        protected override async ETTask Run(Session session, C2A_GetRoles request, A2C_GetRoles response, Action reply)
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

            var token = session.DomainScene().GetComponent<TokenComponent>().Get(request.Account);
            if (token == null || token != request.Token)
            {
                response.Error = ErrorCode.ERR_TokenError;
                reply();
                session?.Disconnect().Coroutine();
                return;
            }

            using (session.AddComponent<SessionLockingComponent>())
            {
                // 保证创角的时候不会进行获取角色的请求
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRoleLock, request.Account))
                {
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone())
                                            .Query<RoleInfo>(d => d.Long_AccountId == request.Account 
                                                            && d.Int_ServerId == request.ServerId
                                                            && d.Int_State == (int)RoleInfoState.Normal);

                    if (roleInfos == null || roleInfos.Count == 0)
                    {
                        reply();
                        return;
                    }

                    foreach (var roleInfo in roleInfos)
                    {
                        response.RoleInfo .Add(roleInfo.ToMessage());
                        roleInfo?.Dispose();
                    }

                    roleInfos.Clear();
                    reply();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
