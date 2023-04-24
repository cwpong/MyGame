namespace ET
{
    public static class UnitFactory
    {
        public static Unit Create(Scene currentScene, UnitInfo unitInfo)
        {
	        UnitComponent unitComponent = currentScene.GetComponent<UnitComponent>();
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
	        unitComponent.Add(unit);
	        NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
	        for (int i = 0; i < unitInfo.Ks.Count; ++i)
		        numericComponent.Set(unitInfo.Ks[i], unitInfo.Vs[i]);
	        

	        unit.AddComponent<ObjectWait>();
			// 通知创建Unit
	        Game.EventSystem.Publish(new EventType.AfterUnitCreate() {Unit = unit});
            return unit;
        }

		public static Unit CreateFighter(Scene currentScene, UnitInfo unitInfo)
		{
            UnitComponent unitComponent = currentScene.DomainScene().CurrentScene().GetComponent<UnitComponent>();
            Log.Warning($"currentScene = {currentScene.Id} currentScene.DomainScene() = {currentScene.CurrentScene().Id} currentScene.DomainScene().CurrentScene() = {currentScene.DomainScene().CurrentScene().Id}");
            Unit unit = unitComponent.AddChildWithId<Unit, int>(unitInfo.UnitId, unitInfo.ConfigId);
            unitComponent.Add(unit);
            NumericComponent numericComponent = unit.AddComponent<NumericComponent>();
            for (int i = 0; i < unitInfo.Ks.Count; ++i)
                numericComponent.Set(unitInfo.Ks[i], unitInfo.Vs[i]);

            unit.AddComponent<ObjectWait>();
            return unit;
        }
    }
}
