using NLog.Filters;
using NLog.Targets;
using System.Collections.Generic;

namespace ET
{
    /// <summary>
    /// 根据技能配置选取技能目标
    /// </summary>
    public class AI_CollectTarget : AAIHandler
    {
        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
        {
            var fighter = aiComponent.GetParent<Unit>();
            var skillCom = fighter.GetComponent<SkillComponent>();
            if (skillCom.GetCurSkillActionSatte() == SkillActionState.CheckOver)
            {
                return 0;
            }

            return 1;
        }

        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
        {
            var attacker = aiComponent.GetParent<Unit>();
            var source = attacker.GetComponent<FighterComponent>().GetBattleSource();
            var battleSceneComponent = attacker.DomainScene().GetComponent<UnitComponent>().GetChild<Unit>(source).GetComponent<BattleSceneComponent>();
            if (battleSceneComponent == null)
            {
                Log.Error($"玩家{attacker}不在战场中");
                attacker.RemoveComponent<AIComponent>();
                return;
            }

            var skillComponent = attacker.GetComponent<SkillComponent>();
            switch (attacker.Type)
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

                    for(int i = 0; i < primarys.Count; ++i)
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

                    skillComponent.SetSkillTarget(attacker, targets);
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

                    skillComponent.SetSkillTarget(attacker, targets);
                    break;
            }

            //if(targets)
            skillComponent.SetSkillActionState(SkillActionState.CollectOver);
            await ETTask.CompletedTask;
        }
    }
}
