namespace ET
{
    public class C2M_TestStartBattleHandler : AMActorLocationHandler<Unit, C2M_TestStartBattle>
    {
        protected override async ETTask Run(Unit unit, C2M_TestStartBattle message)
        {
            // TODO 
            // unit.GetComponent<BattleSceneComponent>().CreateMonster(unit.Id);
            await ETTask.CompletedTask;
        }
    }
}
