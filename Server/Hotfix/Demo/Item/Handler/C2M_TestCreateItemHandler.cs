// 测试创建一个装备
namespace ET
{
    public class C2M_TestCreateItemHandler : AMActorLocationHandler<Unit, C2M_TestCreateItem>
    {
        protected override async ETTask Run(Unit unit, C2M_TestCreateItem message)
        {
            var cfg = ItemConfigCategory.Instance.GetRandomEquipItemCfg();
            BagHelper.AddItemByConfig(unit, cfg.Id);
            await ETTask.CompletedTask;
        }
    }
}
