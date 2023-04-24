using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class ServerInfosManagerComponentAwakeSystem : AwakeSystem<ServerInfosManagerComponent>
    {
        public override void Awake(ServerInfosManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    public class ServerInfosManagerComponentDestroySystem : DestroySystem<ServerInfosManagerComponent>
    {
        public override void Destroy(ServerInfosManagerComponent self)
        {
            foreach (var serverInfo in self.List_ServerInfos)
            {
                serverInfo?.Dispose();
            }

            self.List_ServerInfos.Clear();
        }
    }

    public class ServerInfosManagerComponentLoadSystem : LoadSystem<ServerInfosManagerComponent>
    {
        public override void Load(ServerInfosManagerComponent self)
        {
            self.Awake().Coroutine();
        }
    }

    [FriendClass(typeof(ServerInfo))]
    [FriendClass(typeof(ServerInfosManagerComponent))]
    public static class ServerInfosManagerComponentSystem
    {
        public static async ETTask Awake(this ServerInfosManagerComponent self)
        {
            var serverInfoList = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone())
                                        .Query<ServerInfo>(d => true);

            if(serverInfoList == null || serverInfoList.Count <= 0)
            {
                var srverInfoConfigs = ServerInfoConfigCategory.Instance.GetAll();
                self.List_ServerInfos.Clear();
                foreach (var cfg in srverInfoConfigs.Values)
                {
                    var serverInfo = self.AddChildWithId<ServerInfo>(cfg.Id);
                    serverInfo.Str_ServerName = cfg.ServerName;
                    serverInfo.Int_Status = (int)ServerStatus.Normal;
                    self.List_ServerInfos.Add(serverInfo);
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(serverInfo);
                }

                return;
            }


            foreach (var serverInfo in serverInfoList)
            {
                self.AddChild(serverInfo);
                self.List_ServerInfos.Add(serverInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}
