using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ET
{
    public class FSMFighterTurn : IStateNode
    {
#pragma warning disable ET0004
        private StateMachine StateMachine;
        public void OnCreate(StateMachine machine)
        {
            StateMachine = machine;
        }

        // 选择速度最快且还没出手的对象
        public void OnEnter()
        {
            Log.Warning($"FSMFighterTurn OnEnter");
            
            var com = StateMachine.Owner as FSMComponent;
            if (com == null)
            {
                Log.Error($"节点FSMBattleStartCheck所属的FSMComponent 是空的");
                return;
            }

            var battleScene = com.Parent as BattleSceneComponent;
            if (battleScene == null)
            {
                // 这里是异常情况了, 虽然认为节点执行，但是还是要做一个异常处理，现在不知道怎么处理 先打个日志
                Log.Error($"没有BattleSceneComponent");
                return;
            }

            if (!battleScene.IsAllActionOver())
            {
                var aliveFighters = battleScene.GetAliveFighters();
                aliveFighters.Sort((lhs, rhs) =>
                {
                    var lNum = lhs.GetComponent<NumericComponent>();
                    var rNum = rhs.GetComponent<NumericComponent>();

                    return lNum.GetAsInt(NumericType.BattleSpeed).CompareTo(rNum.GetAsInt(NumericType.BattleSpeed));
                });

                // 这里状态已经变了
                for (int i = 0; i < aliveFighters.Count; ++i)
                {
                    var fighter = aliveFighters[i];
                    if (!fighter.GetComponent<FighterComponent>().HasAction())
                    {
                        battleScene.ResetCurBattleRecord();
                        fighter.GetComponent<FighterComponent>().DoAction(() =>
                        {
                            com.GetMachine().ChangeState<FSMBattleStartCheck>();
                            //Log.Warning($"{fighter.Id}出手完毕");
                        });

                        //Log.Warning($"{fighter.Id}出手");
                        break;
                    }
                    else
                    {
                        //Log.Warning($"{fighter.Id}这回合已经出手过了");
                    }
                }
            }
            else
            {
                battleScene.StepNextRound();
                Log.Warning($"全部出手完毕");
                com.GetMachine().ChangeState<FSMBattleStartCheck>();
            }
        }

        public void OnExit()
        {
        }

        public void OnUpdate()
        {
            Log.Warning($"FSMFighterTurn OnUpdate");
        }
    }
}
