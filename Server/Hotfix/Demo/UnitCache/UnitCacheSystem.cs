using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class UnitCacheDestroySystem : DestroySystem<UnitCache>
    {
        public override void Destroy(UnitCache self)
        {
            foreach (var entity in self.CacheComponentsDictionary.Values)
            {
                entity.Dispose();
            }

            self.CacheComponentsDictionary.Clear();
            self.Key = null;
        }
    }

    [FriendClass(typeof(UnitCache))]
    public static class UnitCacheSystem
    {
        public static async ETTask<Entity> Get(this UnitCache self, long unitId)
        {
            Entity entity = null;
            if (!self.CacheComponentsDictionary.TryGetValue(unitId, out entity))
            {
                entity = await DBManagerComponent.Instance.GetZoneDB(self.DomainZone()).Query<Entity>(unitId, self.Key);

                if(entity != null)
                    self.AddOrUpdate(entity);
            }

            return entity;
        }

        public static void Delete(this UnitCache self, long id)
        {
            if (self.CacheComponentsDictionary.TryGetValue(id, out var entity))
            {
                entity.Dispose();
                self.CacheComponentsDictionary.Remove(id);
            }
        }


        public static void AddOrUpdate(this UnitCache self, Entity entity)
        {
            if (entity == null)
                return;

            if (self.CacheComponentsDictionary.TryGetValue(entity.Id, out var oldEnetyi))
            {
                if (oldEnetyi != entity)
                    oldEnetyi.Dispose();

                self.CacheComponentsDictionary.Remove(entity.Id);
            }

            self.CacheComponentsDictionary.Add(entity.Id, entity);
        }
    }
}
