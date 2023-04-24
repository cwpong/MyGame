using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.UnitCache.Handler
{
    [FriendClass(typeof(UnitCacheComponent))]
    public class Other2UnitCache_GetUnitHandler : AMActorRpcHandler<Scene, Other2UnitCache_GetUnit, UnitCache2Other_GetUnit>
    {
        protected override async ETTask Run(Scene scene, Other2UnitCache_GetUnit request, UnitCache2Other_GetUnit response, Action reply)
        {
            var unitCacheComponent = scene.GetComponent<UnitCacheComponent>();
            var dict = MonoPool.Instance.Fetch(typeof(Dictionary<string, Entity>)) as Dictionary<string, Entity>;

            try
            {
                if (request.ComponentNameList.Count == 0)
                {
                    dict.Add(nameof(Unit), null);
                    foreach (var s in unitCacheComponent.UnitCacheKeyList)
                        dict.Add(s, null);
                }
                else
                {
                    foreach(var s in request.ComponentNameList)
                        dict.Add(s, null);
                }

                foreach (var key in dict.Keys)
                {
                    var entity = await unitCacheComponent.Get(request.UnitId, key);
                    dict[key] = entity;
                }

                response.ComponentNameList.AddRange(dict.Keys);
                response.EntityList.AddRange(dict.Values);
            }
            finally
            {
                dict.Clear();
                MonoPool.Instance.Recycle(dict);
            }

            reply();
            await ETTask.CompletedTask;
        }
    }
}
