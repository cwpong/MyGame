using System;
using System.Diagnostics;
using System.Net.WebSockets;
using UnityEngine;

namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Scene scene, long id, UnitType unitType)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                {
                    Unit unit = unitComponent.AddChildWithId<Unit, int>(id, 1001);
                    NumericComponent numericComponent = unit.AddComponent<NumericComponent>();

                    // 因为是创建新的角色 所以需要从配置获取角色需要的数值数据
                    var numericCfgs = PlayerNumericConfigCategory.Instance.GetAll();
                    var initialCfg = PlayerLevelConfigCategory.Instance.Get(1);

                    numericComponent.SetNoEvent(NumericType.RoleLv, 1);
                    // 很蠢的初始化方式 后面再优化吧
                    foreach (var numericCfg in numericCfgs)
                    {
                        var numeric = numericCfg.Key;
                        if (numeric == NumericType.PhysicalAttack)
                        {
                            numericComponent.SetNoEvent(NumericType.BattlePhysicalAttack, initialCfg.PhysicalAttack);
                        }
                        else if (numeric == NumericType.SpellAttack)
                        {
                            numericComponent.SetNoEvent(NumericType.BattleSpellAttack, initialCfg.SpellAttack);
                        }
                        else if (numeric == NumericType.PhysicalDefense)
                        {
                            numericComponent.SetNoEvent(NumericType.BattlePhysicalDefense, initialCfg.PhysicalDefense);
                        }
                        else if (numeric == NumericType.SpellDefense)
                        {
                            numericComponent.SetNoEvent(NumericType.BattleSpellDefense, initialCfg.SpellDefense);
                        }
                        else if (numeric == NumericType.Speed)
                        {
                            numericComponent.SetNoEvent(NumericType.BattleSpeed, initialCfg.Speed);
                        }
                        else if (numeric == NumericType.MaxHp)
                        {
                            numericComponent.SetNoEvent(NumericType.BattleMaxHp, initialCfg.Hp);
                        }
                        else
                        {
                            Log.Error($"试图创建不存在的属性{numeric}");
                        }
                    }
   
                    unitComponent.Add(unit);
                    unit.AddComponent<BagComponent>();
                    unit.AddComponent<EquipmentsComponent>();
                    return unit;
                }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }

        //public static Unit CreateMyFighter(Scene scene, long soucreId, int lv)
        //{

        //}

        public static Unit CreateMonster(Scene scene, long soucreId, int lv)
        {
            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 2001);
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            var numericCfgs = PlayerNumericConfigCategory.Instance.GetAll();
            var initialCfg = PlayerLevelConfigCategory.Instance.Get(lv);
            numericComponent.SetNoEvent(NumericType.RoleLv, lv);
            numericComponent.SetNoEvent(NumericType.IsAlive, 1);
            // 很蠢的初始化方式 后面再优化吧
            foreach (var numericCfg in numericCfgs)
            {
                var numeric = numericCfg.Key;
                if (numeric == NumericType.PhysicalAttack)
                {
                    numericComponent.SetNoEvent(NumericType.BattlePhysicalAttack, initialCfg.PhysicalAttack);
                }
                else if (numeric == NumericType.SpellAttack)
                {
                    numericComponent.SetNoEvent(NumericType.BattleSpellAttack, initialCfg.SpellAttack);
                }
                else if (numeric == NumericType.PhysicalDefense)
                {
                    numericComponent.SetNoEvent(NumericType.BattlePhysicalDefense, initialCfg.PhysicalDefense);
                }
                else if (numeric == NumericType.SpellDefense)
                {
                    numericComponent.SetNoEvent(NumericType.BattleSpellDefense, initialCfg.SpellDefense);
                }
                else if (numeric == NumericType.Speed)
                {
                    numericComponent.SetNoEvent(NumericType.BattleSpeed, initialCfg.Speed);
                }
                else if (numeric == NumericType.MaxHp)
                {
                    numericComponent.SetNoEvent(NumericType.BattleMaxHp, initialCfg.Hp);
                }
                else
                {
                    Log.Error($"试图创建不存在的属性{numeric}");
                }
            }

            return unit;
        }
    }
}