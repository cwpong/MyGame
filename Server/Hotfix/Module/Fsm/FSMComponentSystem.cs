using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class FSMComponentDestroySystem : DestroySystem<FSMComponent>
    {
        public override void Destroy(FSMComponent self)
        {
            self.StateMachine = null;
            self.IsRun = false;
        }
    }

    public class FSMComponentUpdateSystem : UpdateSystem<FSMComponent>
    {
        public override void Update(FSMComponent self)
        {
            //if(self.StateMachine != null && self.IsRun)
            //    self.StateMachine.Update();
        }
    }

    [FriendClass(typeof(FSMComponent))]
    public static class FSMComponentSystem
    {
        public static void AddNode(this FSMComponent self, IStateNode node)
        {
            if (self.StateMachine == null)
                self.StateMachine = new StateMachine(self);

        }

        public static StateMachine GetMachine(this FSMComponent self)
        {
            if (self.StateMachine == null)
                self.StateMachine = new StateMachine(self);

            return self.StateMachine;
        }

        public static void BeginFsm(this FSMComponent self)
        {
            self.IsRun = true;
        }
         
        public static void Run(this FSMComponent self, IStateNode node)
        {
            // TODO 判断是否有这个节点
            self.StateMachine.Run(node.GetType());
        }

        //public static void ChangeState(this FSMComponent self,  string name)
        //{
        //    // TODO 判断是否有这个节点
        //    self.StateMachine.ChangeState(name);
        //}
    }
}
