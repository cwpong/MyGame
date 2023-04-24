//using NLog.Filters;
//using System;

//namespace ET
//{
//    /// <summary>
//    /// 使用技能
//    /// </summary>
//    public class AI_UseSkill : AAIHandler
//    {
//        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
//        {
//            var fighter = aiComponent.GetParent<Unit>();
//            var skillCom = fighter.GetComponent<SkillComponent>();
//            if (skillCom.GetCurSkillActionSatte() == SkillActionState.CollectOver)
//            {
//                Log.Warning($"{fighter.Id} Check AI_UseSkill");
//                return 0;
//            }

//            return 1;
//        }

//        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
//        {
//            // 根据技能配置 开始计算伤害
//            var attacker = aiComponent.GetParent<Unit>();
//            var source = attacker.GetComponent<FighterComponent>().GetBattleSource();
//            var battleSceneComponent = attacker.DomainScene().GetComponent<UnitComponent>().GetChild<Unit>(source).GetComponent<BattleSceneComponent>();
//            if (battleSceneComponent == null)
//            {
//                Log.Error($"玩家{attacker}不在战场中");
//                attacker.RemoveComponent<AIComponent>();
//                return;
//            }

//            var skillComponent = attacker.GetComponent<SkillComponent>();
//            var skillConfig = skillComponent.GetCurSkillConfig();

//            // 技能配置表需要做个是增益还是简易的判断
//            if (skillComponent.GetSkillTargets() == null || skillComponent.GetSkillTargets().Count <= 0)
//            {
//                skillComponent.SetSkillActionState(SkillActionState.ActionOver);
//                return;
//            }

//            bool isAttack = skillConfig.TargetObject == 1;
//            var attackerCom = skillComponent.GetAttacker().GetComponent<NumericComponent>();

//            // 获取当前的记录
//            var record = battleSceneComponent.GetCurBattleRecord();
//            record.CurRound = battleSceneComponent.GetCurRound();
//            record.Attacker = attacker.Id;
//            for (int i = 0; i < skillComponent.GetSkillTargets().Count; ++i)
//            {
//                var skillTarget = skillComponent.GetSkillTargets()[i];
//                var targetNumCom = skillTarget.GetComponent<NumericComponent>();
//                // TODO 写一个技能效果辅助类 先写死
//                // 攻击分物攻和法攻
//                if (isAttack)
//                {
//                    // 物攻型 造成伤害
//                    if (skillConfig.SkillType == NumericType.PhysicalAttack)
//                    {
//                        var attackerAttack = attackerCom.GetAsInt(NumericType.BattlePhysicalAttack);
//                        var targetDefense = targetNumCom.GetAsInt(NumericType.BattlePhysicalDefense);
//                        var damage = (int)(attackerAttack * (skillConfig.PhysicalAttackRate * 1.0f / 10000));
//                        var deductHp = Math.Max(0, damage - targetDefense);
//                        var curHp = targetNumCom.GetAsInt(NumericType.BattleMaxHp);
//                        curHp -= deductHp;
//                        curHp = Math.Max(0, curHp);
//                        Log.Warning($"{skillComponent.GetAttacker().Id}的物理技能伤害为 {damage} 目标防御为{targetDefense} 造成伤害{deductHp} 目标血量剩余{curHp}");
//                        targetNumCom.SetNoEvent(NumericType.BattleMaxHp, curHp);
//                        if (curHp <= 0)
//                        {
//                            targetNumCom.SetNoEvent(NumericType.IsAlive, 0);
//                            Log.Warning($"{skillTarget.Id} {skillTarget.Type}死亡");
//                        }

//                        // 填充一条记录
//                        var BattleEffectTarget = new BattleEffectTarget();
//                        BattleEffectTarget.Target = skillTarget.Id;
//                        BattleEffectTarget.BattleHpChangeBySkill = new BattleHpChange();
//                        BattleEffectTarget.BattleHpChangeBySkill.ChangeType = NumericType.BattleMaxHp;
//                        BattleEffectTarget.BattleHpChangeBySkill.Value = deductHp;
//                        record.Targets.Add(BattleEffectTarget);
//                    }
//                    else if (skillConfig.SkillType == NumericType.SpellAttack)
//                    {
//                        var attackerAttack = attackerCom.GetAsInt(NumericType.BattleSpellAttack);
//                        var targetDefense = targetNumCom.GetAsInt(NumericType.BattleSpellDefense);
//                        var damage = (int)(attackerAttack * (skillConfig.SpellAttackRate * 1.0f / 10000));
//                        var deductHp = Math.Max(0, damage - targetDefense);
//                        var curHp = targetNumCom.GetAsInt(NumericType.BattleMaxHp);
//                        curHp -= deductHp;
//                        curHp = Math.Max(0, curHp);
//                        Log.Warning($"{skillComponent.GetAttacker().Id}的法术技能伤害为 {damage} 目标防御为{targetDefense} 造成伤害{deductHp} 目标血量剩余{curHp}");
//                        targetNumCom.SetNoEvent(NumericType.BattleMaxHp, curHp);
//                        if (curHp <= 0)
//                        {
//                            targetNumCom.SetNoEvent(NumericType.IsAlive, 0);
//                            Log.Warning($"{skillComponent.GetSkillTargets()[i].Id} 死亡");
//                        }

//                        // 填充一条记录
//                        var BattleEffectTarget = new BattleEffectTarget();
//                        BattleEffectTarget.Target = skillTarget.Id;
//                        BattleEffectTarget.BattleHpChangeBySkill = new BattleHpChange();
//                        BattleEffectTarget.BattleHpChangeBySkill.ChangeType = NumericType.BattleMaxHp;
//                        BattleEffectTarget.BattleHpChangeBySkill.Value = deductHp;
//                        record.Targets.Add(BattleEffectTarget);
//                    }
//                }
//                // 增益的先不写了吧
//                else
//                {
//                }
//            }

//            skillComponent.SetSkillActionState(SkillActionState.ActionOver);
//            await ETTask.CompletedTask;
//        }
//    }
//}
