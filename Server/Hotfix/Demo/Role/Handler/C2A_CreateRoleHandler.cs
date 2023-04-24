using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public class C2A_CreateRoleHandler : AMRpcHandler<C2A_CreateRole, A2C_CreateRole>
    {
        protected override async ETTask Run(Session session, C2A_CreateRole request, A2C_CreateRole response, Action reply)
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

            if (string.IsNullOrEmpty(request.Name))
            {
                response.Error = ErrorCode.ERR_RoleNameIsNull;
                reply();
                return;
            }

            // 防止频繁发起请求
            using (session.AddComponent<SessionLockingComponent>())
            {
                // 查询数据库
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.CreateRoleLock, request.AccountId))
                {
                    var roleInfos = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Query<RoleInfo>(d => d.Str_Name == request.Name && d.Int_ServerId == request.ServerId);

                    if (roleInfos != null && roleInfos.Count > 0)
                    {
                        response.Error = ErrorCode.ERR_RoleNameSame;
                        reply();
                        return;
                    }

                    var newRoleInfo = session.AddChildWithId<RoleInfo>(IdGenerater.Instance.GenerateUnitId(request.ServerId));
                    newRoleInfo.Str_Name = request.Name;
                    newRoleInfo.Int_State = (int)RoleInfoState.Normal;
                    newRoleInfo.Int_ServerId = request.ServerId;
                    newRoleInfo.Long_AccountId = request.AccountId;
                    newRoleInfo.Long_CreateTime = TimeHelper.ServerNow();
                    newRoleInfo.Long_LastLoginTime = TimeHelper.ServerNow();
                    newRoleInfo.Long_RoleId = newRoleInfo.Id;
                    await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<RoleInfo>(newRoleInfo);

                    response.RoleInfo = newRoleInfo.ToMessage();
                    reply();
                    newRoleInfo?.Dispose();
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
