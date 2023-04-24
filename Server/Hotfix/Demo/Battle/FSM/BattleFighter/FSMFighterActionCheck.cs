using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.Battle.FSM.BattleFighter
{
    /// <summary>
    /// 玩家出手检测
    /// </summary>
    public class FSMFighterActionCheck : IStateNode
    {
#pragma warning disable ET0004
        private StateMachine StateMachine;
        public void OnCreate(StateMachine machine)
        {
            StateMachine = machine;
        }

        public void OnEnter()
        {
            // 检测玩家状态
            // 1.如果有一些扣血的状态 在这里执行扣血
            // 2.如果是被禁锢(或死亡，但是死亡不应该走这里的节点的)
            var com = StateMachine.Owner as FSMComponent;
            if (com == null)
            {
                Log.Error($"节点FSMBattleStartCheck所属的FSMComponent 是空的");
                return;
            }

            var unit = com.Parent.Parent as Unit;
            if (unit == null)
            {
                Log.Error($"Unit是空的");
                return;
            }

            var source = unit.GetComponent<FighterComponent>().GetBattleSource();
            var battleScene = unit.DomainScene().GetComponent<UnitComponent>().GetChild<Unit>(source).GetComponent<BattleSceneComponent>();
            if (battleScene.CheckPlayerAllDied() || battleScene.CheckMonsterAllDied())
            {
                if (battleScene.CheckPlayerAllDied())
                    Log.Warning($"我方阵营全部死亡 游戏结束");
                else
                    Log.Warning($"敌方阵营全部死亡 游戏结束");
            }

            // 切换到出手状态
            StateMachine.ChangeState<FSMFighertActionBegin>();
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {
            Log.Warning("FSMFighterActionCheck OnUpdate");
        }
    }
}
