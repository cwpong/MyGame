using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(UnitCache))]
    public class UnitCacheComponentAwakeSystem : AwakeSystem<UnitCacheComponent>
    {
        public override void Awake(UnitCacheComponent self)
        {
            self.UnitCacheKeyList.Clear();

            foreach (var type in Game.EventSystem.GetTypes().Values)
            {
                // TODO ?等于
                if (type != typeof(IUnitCache) && typeof(IUnitCache).IsAssignableFrom(type))
                    self.UnitCacheKeyList.Add(type.Name);
            }

            foreach (var key in self.UnitCacheKeyList)
            {
                var unitCache = self.AddChild<UnitCache>();
                unitCache.Key = key;
                self.UnitCaches.Add(key, unitCache);
            }
        }
    }

    public class UnitCacheComponentDestroySystem : DestroySystem<UnitCacheComponent>
    {
        public override void Destroy(UnitCacheComponent self)
        {
            foreach (var unitCache in self.UnitCaches.Values)
                unitCache?.Dispose();

            self.UnitCaches.Clear();
        }
    }

    [FriendClass(typeof(UnitCache))]
    [FriendClass(typeof(UnitCacheComponent))]
    public static class UnitCacheComponentSystem
    {
        public static async ETTask<Entity> Get(this UnitCacheComponent self, long unitId, string key)
        {
            if (!self.UnitCaches.TryGetValue(key, out var unitCache))
            {
                unitCache = self.AddChild<UnitCache>();
                unitCache.Key = key;
                self.UnitCaches.Add(key, unitCache);
            }

            return await unitCache.Get(unitId);
        }

        public static void Delete(this UnitCacheComponent self, long unitId)
        {
            foreach (var cache in self.UnitCaches.Values)
            {
                cache.Delete(unitId);
            }
        }

        public static async ETTask AddOrUpdate(this UnitCacheComponent self, long id, ListComponent<Entity> entityList)
        {
            using (var list = ListComponent<Entity>.Create())
            {
                foreach (var entity in entityList)
                {
                    var key = entity.GetType().Name;
                    if (!self.UnitCaches.TryGetValue(key, out var unitCache))
                    {
                        unitCache = self.AddChild<UnitCache>();
                        unitCache.Key = key;
                        self.UnitCaches.Add(key, unitCache);
                    }

                    unitCache.AddOrUpdate(entity);
                    list.Add(entity);
                }

                if (list.Count > 0)
                    await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Save(id, list);
            
            }
        }
    }
}
