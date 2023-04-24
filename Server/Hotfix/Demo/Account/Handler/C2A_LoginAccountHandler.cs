using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class C2A_LoginAccountHandler : AMRpcHandler<C2A_LoginAccount, A2C_LoginAccount>
    {
        protected override async ETTask Run(Session session, C2A_LoginAccount request, A2C_LoginAccount response, Action reply)
        {
            if (session.DomainScene().SceneType != SceneType.Account)
            {
                Log.Error($"请求的Scene错误， 当前的Scene是{session.DomainScene().SceneType}");
                session.Dispose();
                return;
            }

            // 不及时移除的话Session会在N秒后才断开
            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            // 防止重复发送登陆请求
            if (session.GetComponent<SessionLockingComponent>() != null)
            {
                response.Error = ErrorCode.ERR_LoginInfoError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // 账号验证
            if (string.IsNullOrEmpty(request.AccountName) || string.IsNullOrEmpty(request.Password))
            {
                response.Error = ErrorCode.ERR_LoginInfoError;
                reply();
                session.Disconnect().Coroutine();
                return;
            }

            // 其他验证 比如格式

            using (session.AddComponent<SessionLockingComponent>())
            {
                using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, 
                                                                    request.AccountName.Trim().GetHashCode()))
                {
                    // 查询数据库中是否存在
                    var accountInfoList = await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).
                                                    Query<Account>(d => d.Str_AccountName.Equals(request.AccountName.Trim()));

                    Account account = null;

                    // 存在账户
                    if (accountInfoList != null && accountInfoList.Count > 0)
                    {
                        account = accountInfoList[0];
                        session.AddChild(account);

                        if (account.Int_AccountType == (int)AccountType.BlackList)
                        {
                            // 可以定义更详细的错误码
                            response.Error = ErrorCode.ERR_LoginInfoError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }

                        if (!account.Str_Password.Equals(request.Password))
                        {
                            // 可以定义更详细的错误码
                            response.Error = ErrorCode.ERR_LoginInfoError;
                            reply();
                            session.Disconnect().Coroutine();
                            account?.Dispose();
                            return;
                        }
                    }
                    // 不存在，则新建
                    else
                    {
                        account = session.AddChild<Account>();
                        account.Str_AccountName = request.AccountName.Trim();
                        account.Str_Password = request.Password;
                        account.Long_CreateTime = TimeHelper.ServerNow();
                        account.Int_AccountType = (int)AccountType.General;
                        await DBManagerComponent.Instance.GetZoneDB(session.DomainZone()).Save<Account>(account);
                    }

                    // 向登陆中心服发送登陆消息
                    var startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.DomainZone(), "LoginCenter");
                    var loginCenterInstanceId = startSceneConfig.InstanceId;
                    var loginAccountResponse = (L2A_LoginAccountResponse) await ActorMessageSenderComponent.Instance.Call(loginCenterInstanceId, new A2L_LoginAccountRequest() { AccountId = account.Id });

                    if (loginAccountResponse.Error != ErrorCode.ERR_Success)
                    {
                        response.Error = loginAccountResponse.Error;
                        reply();
                        session?.Disconnect().Coroutine(); 
                        account?.Dispose();
                        return;
                    }

                    // 如果已经有关联的回话，则先关闭并发送踢下线的消息，并将新的会话记录下来
                    var accountSessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(account.Id);
                    var otherSession = Game.EventSystem.Get(accountSessionInstanceId) as Session;
                    otherSession?.Send(new A2C_Disconnect() { Error = 0});
                    otherSession?.Disconnect().Coroutine();
                    session.DomainScene().GetComponent<AccountSessionsComponent>().Add(account.Id, session.InstanceId);
                    
                    // 防止客户端异常断开链接（没有正常通知后端）,或者登陆了账号服之后不做操作，则自动踢下线
                    session.AddComponent<AccountCheckOutTimeComponent, long>(account.Id);

                    var token = TimeHelper.ServerNow().ToString() + RandomHelper.RandomNumber(int.MinValue, int.MaxValue).ToString();
                    session.DomainScene().GetComponent<TokenComponent>().Remove(account.Id);
                    session.DomainScene().GetComponent<TokenComponent>().Add(account.Id, token);

                    response.AccountId = account.Id;
                    response.Token = token;

                    reply();
                    account?.Dispose();
                }
            }
        }
    }
}
