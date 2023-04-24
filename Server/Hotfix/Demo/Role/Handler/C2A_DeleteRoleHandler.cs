using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public class C2A_DeleteRoleHandler : AMRpcHandler<C2A_DeleteRole, A2C_DeleteRole>
    {
        protected override async ETTask Run(Session session, C2A_DeleteRole request, A2C_DeleteRole response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误， 当前Scene为 :{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_NetWorkError;
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
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRoleLock, request.AccountId))
                {
                    // 查询数据库是否有角色
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(request.ServerId).
                        Query<RoleInfo>(d => d.Long_AccountId == request.RoleInfoId && d.Int_ServerId == request.ServerId);

                    if (roleInfos == null || roleInfos.Count == 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNotExist;
                        reply(); 
                        return;
                    }

                    var roleInfo = roleInfos[0];

                    // why?
                    session.AddChild(roleInfo);

                    roleInfo.Int_State = (int)RoleInfoState.Freeze;
                    await DBManagerComponent.Instance.GetZoneDB(request.ServerId).Save(roleInfo);
                    response.DeletedRoleInfoId = roleInfo.Id;
                    roleInfo.Dispose();

                    reply();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
