using ET.Demo.Battle.FSM.BattleFighter;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class FighterComponentAwakeSystem : AwakeSystem<FighterComponent, long>
    {
        public override void Awake(FighterComponent self, long sourceId)
        {
            self.BattleSource = sourceId;

            self.AddComponent<FSMComponent>();
            self.GetComponent<FSMComponent>().GetMachine().AddNode<FSMFighterActionCheck>();
            self.GetComponent<FSMComponent>().GetMachine().AddNode<FSMFighertActionBegin>();
            self.GetComponent<FSMComponent>().GetMachine().AddNode<FSMFighterActionEnd>();
        }
    }

    [FriendClass(typeof(FighterComponent))]
    public class FighterComponentDestroySystem : DestroySystem<FighterComponent>
    {
        public override void Destroy(FighterComponent self)
        {
            self.HasAction = false;
            self.BattleSource = 0;
            self.ActionEnd = null;
        }
    }

    [FriendClass(typeof(FighterComponent))]
    public static class FighterComponentSystem
    {
        public static long GetBattleSource(this FighterComponent self)
        {
            return self.BattleSource;
        }

        public static void DoAction(this FighterComponent self, Action actionEnd)
        {
            self.ActionEnd = actionEnd;
            self.HasAction = true;
            self.GetComponent<FSMComponent>().GetMachine().Run<FSMFighterActionCheck>();      
        }

        public static void OnActionEnd(this FighterComponent self)
        {
            self.ActionEnd?.Invoke();
        }

        /// <summary>
        /// 新的一回合 需要处理一些状态的重置
        /// </summary>
        /// <param name="self"></param>
        public static void ResetAction(this FighterComponent self)
        {
            // 行动
            self.HasAction = false;
        }

        public static bool HasAction(this FighterComponent self)
        {
            return self.HasAction;
        }
    }
}
