using System;
using System.Collections.Generic;

namespace ET
{
    public class FSMFighertActionBegin : IStateNode
    {
#pragma warning disable ET0004
        private StateMachine StateMachine;
        public void OnCreate(StateMachine machine)
        {
            StateMachine = machine;
        }

        public void OnEnter()
        {
            // 使用技能
            var com = StateMachine.Owner as FSMComponent;
            if (com == null)
            {
                Log.Error($"节点FSMFighertActionBegin所属的FSMComponent 是空的");
                return;
            }

            var unit = com.Parent.Parent as Unit;
            if (unit == null)
            {
                Log.Error($"Unit是空的");
                return;
            }

            var source = unit.GetComponent<FighterComponent>().GetBattleSource();
            var battleSceneComponent = unit.DomainScene().GetComponent<UnitComponent>().GetChild<Unit>(source).GetComponent<BattleSceneComponent>();
            if (battleSceneComponent == null)
            {
                Log.Error($"{unit.Id} 不在战场中");
                return;
            }

            var skillComponent = unit.GetComponent<SkillComponent>();
            // 选择目标
            switch (unit.Type)
            {
                // 后面写个帮助类来选择目标吧
                case UnitType.Player:
                    var config = skillComponent.GetCurSkillConfig();
                    List<Unit> targets = new List<Unit>();
                    // 预选的目标
                    List<Unit> primarys = new List<Unit>();
                    if (config.TargetObject == 0)
                    {
                        primarys = battleSceneComponent.GetFightersByType(UnitType.Player);
                    }
                    else
                    {
                        primarys = battleSceneComponent.GetFightersByType(UnitType.Monster);
                    }

                    // TODO 需要做处理
                    if (primarys == null || primarys.Count <= 0)
                    {
                        Log.Error("对方没有战场角色了 游戏结束");
                        return;
                    }

                    for (int i = 0; i < primarys.Count; ++i)
                    {
                        if (i >= config.TargetRange)
                            break;

                        var target = primarys[i];
                        if (target.GetComponent<NumericComponent>().GetAsInt(NumericType.BattleMaxHp) <= 0)
                        {
                            continue;
                        }
                        else
                        {
                            targets.Add(target);
                        }
                    }

                    skillComponent.SetSkillTarget(unit, targets);
                    break;

                case UnitType.Monster:
                    config = skillComponent.GetCurSkillConfig();
                    targets = new List<Unit>();
                    // 预选的目标
                    primarys = new List<Unit>();
                    if (config.TargetObject == 0)
                    {
                        primarys = battleSceneComponent.GetFightersByType(UnitType.Monster);
                    }
                    else
                    {
                        primarys = battleSceneComponent.GetFightersByType(UnitType.Player);
                    }

                    // TODO 需要做处理
                    if (primarys == null || primarys.Count <= 0)
                    {
                        Log.Error("对方没有战场角色了 游戏结束");
                        return;
                    }

                    for (int i = 0; i < primarys.Count; ++i)
                    {
                        if (i >= config.TargetRange)
                            break;

                        var target = primarys[i];
                        if (target.GetComponent<NumericComponent>().GetAsInt(NumericType.BattleMaxHp) <= 0)
                        {
                            continue;
                        }
                        else
                        {
                            targets.Add(target);
                        }
                    }

                    skillComponent.SetSkillTarget(unit, targets);
                    break;
            }
            if (skillComponent.GetSkillTargets() == null || skillComponent.GetSkillTargets().Count <= 0)
            {
                (bool, BattleResult) result = BattleHelper.CheckBattleIsOver(battleSceneComponent);
                if (result.Item1)
                {
                    Log.Warning($"游戏结束， 战斗结果:{result.Item2}");
                    StateMachine.ChangeState<FSMFighterActionEnd>();
                }
            }

            // 根据技能配置 开始计算伤害
            var skillConfig = skillComponent.GetCurSkillConfig();
            // 技能配置表需要做个是增益还是简易的判断

            bool isAttack = skillConfig.TargetObject == 1;
            var attackerCom = skillComponent.GetAttacker().GetComponent<NumericComponent>();

            // 获取当前的记录
            var record = battleSceneComponent.GetCurBattleRecord();
            record.CurRound = battleSceneComponent.GetCurRound();
            record.Attacker = unit.Id;
            for (int i = 0; i < skillComponent.GetSkillTargets().Count; ++i)
            {
                var skillTarget = skillComponent.GetSkillTargets()[i];
                var targetNumCom = skillTarget.GetComponent<NumericComponent>();
                // TODO 写一个技能效果辅助类 先写死
                // 攻击分物攻和法攻
                if (isAttack)
                {
                    // 物攻型 造成伤害
                    if (skillConfig.SkillType == NumericType.PhysicalAttack)
                    {
                        var attackerAttack = attackerCom.GetAsInt(NumericType.BattlePhysicalAttack);
                        var targetDefense = targetNumCom.GetAsInt(NumericType.BattlePhysicalDefense);
                        var damage = (int)(attackerAttack * (skillConfig.PhysicalAttackRate * 1.0f / 10000));
                        var deductHp = Math.Max(0, damage - targetDefense);
                        var curHp = targetNumCom.GetAsInt(NumericType.BattleMaxHp);
                        curHp -= deductHp;
                        curHp = Math.Max(0, curHp);
                        Log.Warning($"{skillComponent.GetAttacker().Id}的物理技能伤害为 {damage} 目标防御为{targetDefense} 造成伤害{deductHp} 目标血量剩余{curHp}");
                        targetNumCom.SetNoEvent(NumericType.BattleMaxHp, curHp);
                        if (curHp <= 0)
                        {
                            targetNumCom.SetNoEvent(NumericType.IsAlive, 0);
                            Log.Warning($"{skillTarget.Id} {skillTarget.Type}死亡");
                        }

                        // 填充一条记录
                        var BattleEffectTarget = new BattleEffectTarget();
                        BattleEffectTarget.Target = skillTarget.Id;
                        BattleEffectTarget.BattleHpChangeBySkill = new BattleHpChange();
                        BattleEffectTarget.BattleHpChangeBySkill.ChangeType = NumericType.BattleMaxHp;
                        BattleEffectTarget.BattleHpChangeBySkill.Value = deductHp;
                        record.Targets.Add(BattleEffectTarget);
                    }
                    else if (skillConfig.SkillType == NumericType.SpellAttack)
                    {
                        var attackerAttack = attackerCom.GetAsInt(NumericType.BattleSpellAttack);
                        var targetDefense = targetNumCom.GetAsInt(NumericType.BattleSpellDefense);
                        var damage = (int)(attackerAttack * (skillConfig.SpellAttackRate * 1.0f / 10000));
                        var deductHp = Math.Max(0, damage - targetDefense);
                        var curHp = targetNumCom.GetAsInt(NumericType.BattleMaxHp);
                        curHp -= deductHp;
                        curHp = Math.Max(0, curHp);
                        Log.Warning($"{skillComponent.GetAttacker().Id}的法术技能伤害为 {damage} 目标防御为{targetDefense} 造成伤害{deductHp} 目标血量剩余{curHp}");
                        targetNumCom.SetNoEvent(NumericType.BattleMaxHp, curHp);
                        if (curHp <= 0)
                        {
                            targetNumCom.SetNoEvent(NumericType.IsAlive, 0);
                            Log.Warning($"{skillComponent.GetSkillTargets()[i].Id} 死亡");
                        }

                        // 填充一条记录
                        var BattleEffectTarget = new BattleEffectTarget();
                        BattleEffectTarget.Target = skillTarget.Id;
                        BattleEffectTarget.BattleHpChangeBySkill = new BattleHpChange();
                        BattleEffectTarget.BattleHpChangeBySkill.ChangeType = NumericType.BattleMaxHp;
                        BattleEffectTarget.BattleHpChangeBySkill.Value = deductHp;
                        record.Targets.Add(BattleEffectTarget);
                    }
                }
                // 增益的先不写了吧
                else
                {
                }
            }

            StateMachine.ChangeState<FSMFighterActionEnd>();
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {
            Log.Warning($"FSMFighertActionBegin OnUpdate");
        }
    }
}
