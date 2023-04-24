using System;

namespace ET
{
    // 判断技能是否能使用 比如被禁锢\眩晕时就无法使用技能
    public class AI_SkillCheck : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            var fighter = aiComponent.GetParent<Unit>();
            var skillCom = fighter.GetComponent<SkillComponent>();
            if (skillCom.GetCurSkillActionSatte() == SkillActionState.Idle)
            {
                return 0;
            }

            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            var fighter = aiComponent.GetParent<Unit>();
            var skillCom = fighter.GetComponent<SkillComponent>();
            skillCom.SetSkillActionState(SkillActionState.CheckOver);
            await ETTask.CompletedTask;
        }
    }
}
