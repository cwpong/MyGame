using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ObjectSystem]
    public class LoginInfoRecordComponentDestorySystem : DestroySystem<LoginInfoRecordComponent>
    {
        public override void Destroy(LoginInfoRecordComponent self)
        {
            self.Dict_AccountLoginInfo.Clear();
        }
    }

    [FriendClass(typeof(LoginInfoRecordComponent))]
    public static class LoginInfoRecordComponentSystem
    {
        public static void Add(this LoginInfoRecordComponent self, long key, int value)
        {
            self.Dict_AccountLoginInfo[key] = value;
        }

        public static void Remove(this LoginInfoRecordComponent self, long key)
        {
            self.Dict_AccountLoginInfo.Remove(key);
        }

        public static int Get(this LoginInfoRecordComponent self, long key)
        {
            if (self.Dict_AccountLoginInfo.TryGetValue(key, out var v))
                return v;

            return -1;
        }

        public static bool IsExist(this LoginInfoRecordComponent self, long key)
        {
            return self.Dict_AccountLoginInfo.ContainsKey(key);
        }
    }
}
