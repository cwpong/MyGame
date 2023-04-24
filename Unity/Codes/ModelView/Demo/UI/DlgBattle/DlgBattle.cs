namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgBattle :Entity,IAwake,IUILogic
	{

		public DlgBattleViewComponent View { get => this.Parent.GetComponent<DlgBattleViewComponent>();} 

		 

	}
}
