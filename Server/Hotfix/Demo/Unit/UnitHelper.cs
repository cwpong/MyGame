using ET.Demo.UnitCache;
using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(Unit))]
    [FriendClass(typeof(MoveComponent))]
    [FriendClass(typeof(NumericComponent))]
    [FriendClass(typeof(GateMapComponent))]
    public static class UnitHelper
    {
        public static UnitInfo CreateUnitInfo(Unit unit)
        {
            UnitInfo unitInfo = new UnitInfo();
            NumericComponent nc = unit.GetComponent<NumericComponent>();
            unitInfo.UnitId = unit.Id;
            unitInfo.ConfigId = unit.ConfigId;
            unitInfo.Type = (int)unit.Type;
            Vector3 position = unit.Position;
            unitInfo.X = position.x;
            unitInfo.Y = position.y;
            unitInfo.Z = position.z;
            Vector3 forward = unit.Forward;
            unitInfo.ForwardX = forward.x;
            unitInfo.ForwardY = forward.y;
            unitInfo.ForwardZ = forward.z;

            // 装载NumericComponent的数值类型
            foreach ((int key, long value) in nc.NumericDic)
            {
                unitInfo.Ks.Add(key);
                unitInfo.Vs.Add(value);
            }

            return unitInfo;
        }

        public static async ETTask<(bool, Unit)> LoadUnit(Player player)
        {
            var gateMapComponent = player.AddComponent<GateMapComponent>();
            gateMapComponent.Scene = await SceneFactory.Create(gateMapComponent, "GateMap", SceneType.Map);

            var unit = await UnitCacheHelper.GetUnitCache(gateMapComponent.Scene, player.UnitId);
            var isNewUnit = unit == null;

            if (isNewUnit)
            {
                unit = UnitFactory.Create(gateMapComponent.Scene, player.Id, UnitType.Player);

                var roleInfos = await DBManagerComponent.Instance.GetZoneDB(player.DomainZone()).Query<RoleInfo>(d => d.Id == player.UnitId);
                unit.AddComponent(roleInfos[0]);

                UnitCacheHelper.AddOrUpdateUnitAllCache(unit);
            }

            return (isNewUnit, unit);
        }

        public static async ETTask InitUnit(Unit unit, bool isNew)
        {
            await ETTask.CompletedTask;
        }

        
        // 获取看见unit的玩家，主要用于广播
        public static Dictionary<long, AOIEntity> GetBeSeePlayers(this Unit self)
        {
            return self.GetComponent<AOIEntity>().GetBeSeePlayers();
        }
        
        public static void NoticeUnitAdd(Unit unit, Unit sendUnit)
        {
            M2C_CreateUnits createUnits = new M2C_CreateUnits();
            createUnits.Units.Add(CreateUnitInfo(sendUnit));
            MessageHelper.SendToClient(unit, createUnits);
        }
        
        public static void NoticeUnitRemove(Unit unit, Unit sendUnit)
        {
            M2C_RemoveUnits removeUnits = new M2C_RemoveUnits();
            removeUnits.Units.Add(sendUnit.Id);
            MessageHelper.SendToClient(unit, removeUnits);
        }
    }
}