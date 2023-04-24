using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ComponentOf]
    public class FSMComponent : Entity, IAwake, IUpdate, IDestroy
    {
        public StateMachine StateMachine;
        public bool IsRun;

    }
}
