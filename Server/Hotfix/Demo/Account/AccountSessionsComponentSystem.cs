using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    [FriendClass(typeof(AccountSessionsComponent))]
    public class AccpintSessionsComponentDestorySystem : DestroySystem<AccountSessionsComponent>
    {
        public override void Destroy(AccountSessionsComponent self)
        {
            self.Dict_AccountDictionary.Clear();
        }
    }

    [FriendClass(typeof(AccountSessionsComponent))]
    public static class AccountSessionsComponentSystem
    {
        public static long Get(this AccountSessionsComponent self, long accountId)
        {
            if(self.Dict_AccountDictionary.TryGetValue(accountId, out var instanceId))
                return instanceId;

            return 0;
        }

        public static void Add(this AccountSessionsComponent self, long accountId, long sessionInstanceId)
        {
            self.Dict_AccountDictionary[accountId] = sessionInstanceId;
        }

        public static void Remove(this AccountSessionsComponent self, long accountId)
        {
            self.Dict_AccountDictionary.Remove(accountId);
        }
    }
}
