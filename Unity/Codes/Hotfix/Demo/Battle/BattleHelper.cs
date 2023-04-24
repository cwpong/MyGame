using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public static class BattleHelper
    {
        /// <summary>
        /// 打印战斗对象的属性
        /// </summary>
        /// <param name="unit"></param>
        public static void LogFighterNumericInfo(Unit unit, int type, bool isShowAll = true)
        {
            var num = unit.GetComponent<NumericComponent>();
            if (num == null)
            {
                Log.Warning($"{unit.Id} 没有数值组件");
            }

            if (isShowAll)
            {
                var phyAtk = num.GetAsInt(NumericType.BattlePhysicalAttack);
                var phyDef = num.GetAsInt(NumericType.BattlePhysicalDefense);
                var spellAtk = num.GetAsInt(NumericType.BattleSpellAttack);
                var spellDef = num.GetAsInt(NumericType.BattleSpellDefense);
                var hp = num.GetAsInt(NumericType.BattleMaxHp);
                var speed = num.GetAsInt(NumericType.BattleSpeed);
                var unitType = unit.Type == UnitType.Player ? "我方角色" : "敌方角色";
                Log.Info($"{unitType} {unit.Id}进入房间 物攻 = {phyAtk} 物防 = {phyDef} 法攻 = {spellAtk} 法防 = {spellDef} 气血 = {hp} 速度 = {speed}");
            }
            else
            {
                var value = num.GetAsInt(type);
                Log.Info($"{unit.Id}的属性{type} 当前值为{value}");
            }
        }

        public static async ETTask<int> EnterBattleScene(Scene scene)
        {
            M2C_CreateBattle m2c_CreateBattle = null;
            try
            {
                m2c_CreateBattle = (M2C_CreateBattle) await scene.GetComponent<SessionComponent>().Session.Call(new C2M_CreateBattle());
                if (m2c_CreateBattle.Error != ErrorCode.ERR_Success)
                {
                    Log.Error("进入关卡失败");
                    return m2c_CreateBattle.Error;
                }

                for (int i = 0; i < m2c_CreateBattle.Fighters.Count; ++i)
                {
                    var fighter = UnitFactory.CreateFighter(scene, m2c_CreateBattle.Fighters[i]);
                    scene.GetComponent<BattleSceneComponent>().FighterJoin(fighter);
                }

                // 初始化战场对象
                return m2c_CreateBattle.Error;
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return m2c_CreateBattle.Error;
            }

        } 
    }
}
