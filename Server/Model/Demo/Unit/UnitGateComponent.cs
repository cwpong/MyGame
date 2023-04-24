namespace ET
{
	[ComponentOf(typeof(Unit))]
	public class UnitGateComponent : Entity, IAwake<long>, ITransfer
	{
		public long GateSessionActorId;

#pragma warning disable ET0006 // 实体类禁止声明方法
        public void Awake(long gateSessionId)
		{
            GateSessionActorId = gateSessionId;

        }
#pragma warning restore ET0006 // 实体类禁止声明方法
    }
}