namespace ET
{
	[ComponentOf(typeof(Session))]
	public class SessionPlayerComponent : Entity, IAwake, IDestroy
	{
		public long PlayerId;
		public long PlayerInstanceId;
		public long AccountId;
		public bool IsLoginAgin = false; // 用来判断是不是二次登陆
	}
}