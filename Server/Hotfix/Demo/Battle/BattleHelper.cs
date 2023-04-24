using System.Collections.Generic;

namespace ET
{
    public static class BattleHelper
    {
        /// <summary>
        /// 根据等级 创建关卡 假如我和怪兽的战斗对象
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="lv"></param>
        public static List<Unit> CreateFighters(Unit unit, int lv)
        {
            var list = new List<Unit>();

            var scene = unit.DomainScene();
            // 加入玩家 目前只有一个
            var myFighter = scene.GetComponent<UnitComponent>().AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1001);
            var battleScene = unit.GetComponent<BattleSceneComponent>();
            //self.MultiMapFighters.Add(UnitType.Player, myFighter);//[UnitType.Player].Add(me);
            //属性先从玩家自己的取
            var myNumericCom = unit.GetComponent<NumericComponent>();
            var myFighterNumericCom = myFighter.AddComponent<NumericComponent>();

            // 初始化一些战斗属性
            myFighterNumericCom.SetNoEvent(NumericType.IsAlive, 1);
            myFighterNumericCom.Set(NumericType.BattlePhysicalAttack, myNumericCom.GetAsInt(NumericType.PhysicalAttack));
            myFighterNumericCom.Set(NumericType.BattleSpellAttack, myNumericCom.GetAsInt(NumericType.SpellAttack));
            myFighterNumericCom.Set(NumericType.BattlePhysicalDefense, myNumericCom.GetAsInt(NumericType.PhysicalDefense));
            myFighterNumericCom.Set(NumericType.BattleSpellDefense, myNumericCom.GetAsInt(NumericType.SpellDefense));
            myFighterNumericCom.Set(NumericType.BattleSpeed, myNumericCom.GetAsInt(NumericType.Speed));
            myFighterNumericCom.Set(NumericType.BattleMaxHp, myNumericCom.GetAsInt(NumericType.MaxHp));
            myFighter.AddComponent<FighterComponent, long>(unit.Id);
            myFighter.AddComponent<SkillComponent, int>(1001);
            list.Add(myFighter);
            var randLv = RandomHelper.RandomNumber(1, lv);
            for (int i = 0; i < 3; ++i)
            {
                var monsterUnit = UnitFactory.CreateMonster(scene, unit.Id, randLv);
                // TODO 测试 后面走配置
                // self.MultiMapFighters.Add(UnitType.Monster, monsterUnit); //[UnitType.Monster].Add(monsterUnit);
                monsterUnit.AddComponent<FighterComponent, long>(unit.Id);
                monsterUnit.AddComponent<SkillComponent, int>(1001);
                list.Add(monsterUnit);
            }

            return list;
        }

        public static (bool, BattleResult) CheckBattleIsOver(BattleSceneComponent component)
        {
            if (component.CheckPlayerAllDied())
                return (true, BattleResult.Lose);
            else if (component.CheckMonsterAllDied())
                return (true, BattleResult.Win);
            else
                return (false, BattleResult.NoResult);
        }

        /// <summary>
        /// 计算伤害
        /// </summary>
        /// <returns></returns>
        public static int CalculateBattleDamage()
        {
            var damage = 0;
            return damage;
        }
    }
}
