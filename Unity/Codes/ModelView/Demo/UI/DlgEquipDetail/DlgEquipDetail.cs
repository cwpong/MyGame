namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgEquipDetail :Entity,IAwake,IUILogic
	{

		public DlgEquipDetailViewComponent View { get => this.Parent.GetComponent<DlgEquipDetailViewComponent>();}

		public long ItemUid;
		public ItemOwner ItemOwner;

    }
}
