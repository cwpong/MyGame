namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgPatch :Entity,IAwake,IUILogic
	{

		public DlgPatchViewComponent View { get => this.Parent.GetComponent<DlgPatchViewComponent>();} 

		 

	}
}
