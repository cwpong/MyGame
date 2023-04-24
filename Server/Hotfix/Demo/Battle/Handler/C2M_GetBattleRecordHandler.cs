using System;

namespace ET
{
    public class C2M_GetBattleRecordHandler : AMActorLocationRpcHandler<Unit, C2M_GetBattleRecord, M2C_GetBattleRecord>
    {
        protected override async ETTask Run(Unit unit, C2M_GetBattleRecord request, M2C_GetBattleRecord response, Action reply)
        {
            var battleComponent = unit.GetComponent<BattleSceneComponent>();
            var record = battleComponent.GetBattleRecord();
            response.OneBattleRecords = record;

            reply();
            await ETTask.CompletedTask;
        }
    }
}
