using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(FighterComponent))]
    internal class FSMFighterActionEnd : IStateNode
    {
#pragma warning disable ET0004
        private StateMachine StateMachine;
        public void OnCreate(StateMachine machine)
        {
            StateMachine = machine;
        }

        public void OnEnter()
        {
            // 回合结束 这里先做一个抛出事件的
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

            var fighter = unit.GetComponent<FighterComponent>();
            fighter.OnActionEnd();
        }

        public void OnExit()
        {
            
        }

        public void OnUpdate()
        {
            Log.Warning("FSMFighterActionEnd OnUpdate");
        }
    }
}
