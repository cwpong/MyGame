using System.Collections.Generic;

namespace ET
{
    [ChildType(typeof(Scene))]
    [ComponentOf(typeof(Scene))]
    public class TokenComponent : Entity, IAwake
    {
        public readonly Dictionary<long, string> Dict_TokenDictionary = new Dictionary<long, string>();
    }
}
