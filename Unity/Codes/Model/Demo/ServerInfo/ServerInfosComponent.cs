using System.Collections.Generic;


namespace ET
{
    [ChildType(typeof(ServerInfo))]
    [ComponentOf(typeof(Scene))]
    public class ServerInfosComponent : Entity, IAwake, IDestroy
    {
        public List<ServerInfo> List_ServerInfo = new List<ServerInfo>();
        public int CurrentServerId = 0;
    }
}
