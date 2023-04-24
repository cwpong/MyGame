using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.Account
{
    public enum SessionState
    {
        Normal,
        Game,
    }

    [ComponentOf(typeof(Session))]
    public class SessionStateComponent : Entity, IAwake
    {
        public SessionState State;
    }
}
