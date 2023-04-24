using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class FighterComponent : Entity, IAwake<long>, IDestroy
    {
        public long BattleSource = 0;   // 战场是谁发起的

        // 本回合是否出手过了
        public bool HasAction = false;
        public Action ActionEnd;
    }
}
