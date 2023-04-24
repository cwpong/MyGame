using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    /// <summary>
    /// 技能释放完要做的事：添加\驱散状态，移除AI组件等
    /// </summary>
    public class AI_SkillEnd : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            var fighter = aiComponent.GetParent<Unit>();
            var skillCom = fighter.GetComponent<SkillComponent>();
            if (skillCom.GetCurSkillActionSatte() == SkillActionState.ActionOver)
            {
                Log.Warning($"{fighter.Id} Check AI_SkillEnd");
                return 0;
            }

            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            var fighter = aiComponent.GetParent<Unit>();
            var skillCom = fighter.GetComponent<SkillComponent>();
            skillCom.OnSkillOver();
            fighter.RemoveComponent<AIComponent>();
            await ETTask.CompletedTask;
        }
    }
}
