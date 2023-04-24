using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    // 这个标签指定执行的定时器类型
    [Timer(TimerType.AccountSessionCheckOutTime)]
    public class AccountSessionCheckOutTimer : ATimer<AccountCheckOutTimeComponent>
    {
        public override void Run(AccountCheckOutTimeComponent self)
        {
            try
            {
                self.DeleteSession();
            }
            catch(Exception e)
            {
                Log.Error(e);
            }
        }
    }

    [ObjectSystem]
    public class AccountCheckOutTimeComponentAwakeSystem : AwakeSystem<AccountCheckOutTimeComponent, long>
    {
        /// <summary>
        /// 启动定时器
        /// </summary>
        /// <param name="self"></param>
        /// <param name="accountId"></param>
        public override void Awake(AccountCheckOutTimeComponent self, long accountId)
        {
            self.AccountId = accountId;
            TimerComponent.Instance.Remove(ref self.Timer);

            // 启动定时器 10分钟
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 600000, TimerType.AccountSessionCheckOutTime, self);
        }
    }

    [ObjectSystem]
    public class AccountCheckOutTimeComponentDestorySystem : DestroySystem<AccountCheckOutTimeComponent>
    {
        public override void Destroy(AccountCheckOutTimeComponent self)
        {
            self.AccountId = 0;

            // 如果是主动断开的 则移除定时器
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    [FriendClass(typeof(AccountCheckOutTimeComponent))]
    public static class AccountCheckOutTimeComponentSystem
    {
        public static void DeleteSession(this AccountCheckOutTimeComponent self)
        {
            var session = self.GetParent<Session>();
            var sessionInstanceId = session.DomainScene().GetComponent<AccountSessionsComponent>().Get(self.AccountId);

            // 判断是不是原来的会话，是的话则移除
            if (session.InstanceId == sessionInstanceId)
                session.DomainScene().GetComponent<AccountSessionsComponent>().Remove(self.AccountId);

            session?.Send(new A2C_Disconnect() { Error = 1});
            session?.Disconnect().Coroutine();
        }
    }
}
