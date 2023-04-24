using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class SkillComponentAwakeSystem : AwakeSystem<SkillComponent, int>
    {
        public override void Awake(SkillComponent self, int skillId)
        {
            self.InitSkill(skillId);
        }
    }

    public class SkillComponentDestroySystem : DestroySystem<SkillComponent>
    {
        public override void Destroy(SkillComponent self)
        {
            self.SkillConfig = null;
        }
    }

    [FriendClass(typeof(SkillComponent))]
    public static class SkillComponentSystem
    {
        public static void InitSkill(this SkillComponent self, int skillId)
        {
            self.SkillConfig = SkillConfigCategory.Instance.Get(skillId);
        }

        /// <summary>
        /// 出手时使用
        /// </summary>
        /// <param name="self"></param>
        public static void SkillPrepare(this SkillComponent self)
        {
            var fighter = self.GetParent<Unit>();
            if (fighter == null)
            {
                Log.Error($"技能组件没有战场对象");
                return;
            }

            // 开始执行技能
            self.CurState = SkillActionState.Idle;
            fighter.AddComponent<AIComponent, int>(2);
        }

        public static void SetSkillActionState(this SkillComponent self, SkillActionState state)
        {
            self.CurState = state;
        }

        public static SkillActionState GetCurSkillActionSatte(this SkillComponent self)
        {
            return self.CurState;
        }

        public static void SetSkillTarget(this SkillComponent self, Unit attacker, List<Unit> targets)
        {
            self.Attacker = attacker;
            self.TargetList = targets;
        }

        public static SkillConfig GetCurSkillConfig(this SkillComponent self)
        {
            return self.SkillConfig;
        }

        public static Unit GetAttacker(this SkillComponent self)
        {
            return self.Attacker;
        }

        public static List<Unit> GetSkillTargets(this SkillComponent self)
        {
            return self.TargetList;
        }

        public static void OnSkillOver(this SkillComponent self)
        {
            // TODO 丑陋的写法
            //var fighter = self.GetParent<Unit>();
            //var source = fighter.GetComponent<FighterComponent>().GetBattleSource();
            //var battleScene = fighter.DomainScene().GetComponent<UnitComponent>().GetChild<Unit>(source).GetComponent<BattleSceneComponent>();
            //battleScene.SetCurState(BattleState.Idle);
        }
    }
}
