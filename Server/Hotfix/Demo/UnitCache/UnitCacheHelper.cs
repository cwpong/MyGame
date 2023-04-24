using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.UnitCache
{
    public static class UnitCacheHelper
    {
        public static async ETTask AddOrUpdateUnitCache<T>(this T self) where T : Entity, IUnitCache
        {
            var message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = self.Id };
            message.EntityTypes.Add(typeof(T).FullName);
            message.EntityBytes.Add(MongoHelper.ToBson(self));
            await MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(self.Id).InstanceId, message);
        }

        public static async ETTask<Unit> GetUnitCache(Scene scene, long unitId)
        {
            var instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            var message = new Other2UnitCache_GetUnit() { UnitId = unitId };
            var queryUnit = (UnitCache2Other_GetUnit)await MessageHelper.CallActor(instanceId, message);
            if (queryUnit.Error != ErrorCode.ERR_Success || queryUnit.EntityList.Count == 0)
                return null;

            var indexOf = queryUnit.ComponentNameList.IndexOf(nameof(Unit));
            var unit = queryUnit.EntityList[indexOf] as Unit;

            if (unit == null)
                return null;

            scene.AddChild(unit);
            foreach (var entity in queryUnit.EntityList)
            {
                if (entity == null || entity is Unit)
                    continue;

                unit.AddComponent(entity);
            }

            return unit;

        }

        public static async ETTask<T> GetUnitComponentCache<T>(long unitId) where T : Entity, IUnitCache
        {
            var message = new Other2UnitCache_GetUnit() { UnitId = unitId };
            message.ComponentNameList.Add(typeof(T).FullName);
            var instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            var queryUnit = (UnitCache2Other_GetUnit)await MessageHelper.CallActor(instanceId, message);

            if(queryUnit.Error == ErrorCode.ERR_Success && queryUnit.EntityList.Count > 0)
                return queryUnit.EntityList[0] as T;

            return null;
        }

        public static async ETTask DeleteUnitCache(long unitId)
        {
            var message = new Other2UnitCache_DeleteUnit() { UnitId = unitId };
            var instanceId = StartSceneConfigCategory.Instance.GetUnitCacheConfig(unitId).InstanceId;
            await MessageHelper.CallActor(instanceId, message);
        }

        /// <summary>
        /// 保存Unit以及Unit身上的组件到缓存服及数据库中
        /// </summary>
        public static void AddOrUpdateUnitAllCache(Unit unit)
        {
            var message = new Other2UnitCache_AddOrUpdateUnit() { UnitId = unit.Id };
            message.EntityTypes.Add(unit.GetType().FullName);
            message.EntityBytes.Add(MongoHelper.ToBson(unit));

            foreach ((Type key, Entity entity) in unit.Components)
            {
                if (!typeof(IUnitCache).IsAssignableFrom(key))
                {
                    continue;
                }

                message.EntityTypes.Add(key.FullName);
                message.EntityBytes.Add(MongoHelper.ToBson(entity));
            }

            MessageHelper.CallActor(StartSceneConfigCategory.Instance.GetUnitCacheConfig(unit.Id).InstanceId, message).Coroutine();
        }
    }
}
