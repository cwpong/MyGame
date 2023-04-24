using System;


namespace ET
{
	[ActorMessageHandler]
	// Gate -> Map
	public class M2M_UnitTransferRequestHandler : AMActorRpcHandler<Scene, M2M_UnitTransferRequest, M2M_UnitTransferResponse>
	{
		protected override async ETTask Run(Scene scene, M2M_UnitTransferRequest request, M2M_UnitTransferResponse response, Action reply)
		{
			await ETTask.CompletedTask;
			UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
			Unit unit = request.Unit;
			
			// 这里会报错 因为上一次的没有释放掉
			unitComponent.AddChild(unit);
            // TODO 不移除的话有bug 先取巧处理
            //unitComponent.Remove(unit.Id);
            unitComponent.Add(unit);
			unit.AddComponent<UnitDBSaveComponent>();
			foreach (Entity entity in request.Entitys)
			{
				// 触发生命周期
				unit.AddComponent(entity);
			}
			
			unit.AddComponent<MailBoxComponent>();
			
			// 通知客户端创建My Unit
			M2C_CreateMyUnit m2CCreateUnits = new M2C_CreateMyUnit();
			m2CCreateUnits.Unit = UnitHelper.CreateUnitInfo(unit);
			MessageHelper.SendToClient(unit, m2CCreateUnits);

			// 通知客户端同步背包信息
			ItemUpdateNoticeHelper.SyncAllBagItems(unit);
			// 同步装备
            ItemUpdateNoticeHelper.SyncAllEquipItems(unit);

			unit.AddComponent<BattleSceneComponent>();

            // 加入aoi
            //unit.AddComponent<AOIEntity, int, Vector3>(9 * 1000, unit.Position);

            response.NewInstanceId = unit.InstanceId;
			
			reply();
		}
	}
}