namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRoleDetails :Entity,IAwake,IUILogic
	{

		public DlgRoleDetailsViewComponent View { get => this.Parent.GetComponent<DlgRoleDetailsViewComponent>();} 

		 

	}
}
