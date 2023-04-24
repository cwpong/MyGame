using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class BattleSceneComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<long, Unit> DictFighters = new Dictionary<long, Unit>();
    }
}
