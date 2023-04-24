using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ServerInfosComponentDestroySysstem : DestroySystem<ServerInfosComponent>
    {
        public override void Destroy(ServerInfosComponent self)
        {
            foreach (var serverInfo in self.List_ServerInfo)
                serverInfo?.Dispose();

            self.List_ServerInfo.Clear();
            self.CurrentServerId = 0;
        }
    }

    [FriendClass(typeof(ServerInfosComponent))]
    public static class ServerInfosComponentSystem
    {
        public static void Add(this ServerInfosComponent self, ServerInfo serverInfo)
        {
            self.List_ServerInfo.Add(serverInfo);
        }
    }
}
