using System;

namespace ET
{
    public class C2M_CreateBattleHandler : AMActorLocationRpcHandler<Unit, C2M_CreateBattle, M2C_CreateBattle>
    {
        protected override async ETTask Run(Unit unit, C2M_CreateBattle request, M2C_CreateBattle response, Action reply)
        {
            var fighters = BattleHelper.CreateFighters(unit, unit.GetComponent<NumericComponent>().GetAsInt(NumericType.RoleLv));
            var battleScene = unit.GetComponent<BattleSceneComponent>();
            for (int i = 0; i < fighters.Count; ++i)
            {
                battleScene.FighterJoin(fighters[i]);
                response.Fighters.Add(UnitHelper.CreateUnitInfo(fighters[i]));
            }

            battleScene.GenerateBattleResult();
            reply();
            await ETTask.CompletedTask;
        }
    }
}
