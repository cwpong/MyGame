using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Unit))]
    public class SkillComponent : Entity, IAwake<int>, IDestroy
    {
        // TODO 当前暂且认为只有一个技能吧
        public SkillConfig SkillConfig;
        public SkillActionState CurState = SkillActionState.Idle;
        public Unit Attacker;
        public List<Unit> TargetList = new List<Unit>();
    }
}
