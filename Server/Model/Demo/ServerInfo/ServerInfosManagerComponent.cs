using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [ChildType(typeof(ServerInfo))]
    [ComponentOf(typeof(Scene))]
   
    public class ServerInfosManagerComponent : Entity, IAwake, IDestroy, ILoad
    {
        public List<ServerInfo> List_ServerInfos = new List<ServerInfo>();
    }
}
