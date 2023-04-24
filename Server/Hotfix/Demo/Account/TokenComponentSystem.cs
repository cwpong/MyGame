using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(TokenComponent))]
    public static class TokenComponentSystem 
    {
        public static void Add(this TokenComponent self, long key, string token)
        {
            self.Dict_TokenDictionary.Add(key, token);
            self.TimeOutRemoveKey(key, token).Coroutine();
        }

        public static string Get(this TokenComponent self, long key)
        {
            if (self.Dict_TokenDictionary.TryGetValue(key, out var token))
            {
                return token;;
            }

            return string.Empty;
        }

        public static void Remove(this TokenComponent self, long key)
        {
            self.Dict_TokenDictionary.Remove(key);
        }

        private static async ETTask TimeOutRemoveKey(this TokenComponent self, long key, string tokenKey)
        {
            await TimerComponent.Instance.WaitAsync(600000);
            var onlineToken = self.Get(key);

            if (!string.IsNullOrEmpty(onlineToken) && onlineToken == tokenKey)
                self.Remove(key);
        }
    }
}
