using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.UnitCache.Handler
{
    public class Other2UnitCache_AddOrUpdateUnitHandler : AMActorRpcHandler<Scene, Other2UnitCache_AddOrUpdateUnit, UnitCache2Other_AddOrUpdateUnit>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_AddOrUpdateUnit request, UnitCache2Other_AddOrUpdateUnit response, Action reply)
        {
            UpdateUnitCacheAsync(scene, request, response).Coroutine();
            reply();
            await ETTask.CompletedTask;
        }

        private async ETTask UpdateUnitCacheAsync(Scene scene, Other2UnitCache_AddOrUpdateUnit request, UnitCache2Other_AddOrUpdateUnit response)
        {
            var unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
            using (var entityList = ListComponent<Entity>.Create())
            {
                for (var index = 0; index < request.EntityTypes.Count; ++index)
                {
                    var type = Game.EventSystem.GetType(request.EntityTypes[index]);
                    var entity = (Entity)MongoHelper.FromBson(type, request.EntityBytes[index]);
                    entityList.Add(entity);
                }

                await unitCacheComponent.AddOrUpdate(request.UnitId, entityList);
            }
        }
    }
}
