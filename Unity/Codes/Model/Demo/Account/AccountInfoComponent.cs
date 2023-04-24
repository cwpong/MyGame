using System;
namespace ET
{
    [ChildType(typeof(Scene))]
    [ComponentOf(typeof(Scene))]
    public class AccountInfoComponent : Entity, IAwake, IDestroy
    {
        public string Token { get; set; }
        public long AccountId { get; set; }

        public string RealmKey;
        public string RealmAddress;
    }
}
