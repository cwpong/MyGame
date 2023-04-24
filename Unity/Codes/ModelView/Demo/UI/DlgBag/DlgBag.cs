﻿using System.Collections.Generic;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgBag :Entity,IAwake,IUILogic
	{
		public DlgBagViewComponent View { get => this.Parent.GetComponent<DlgBagViewComponent>();}

		public Dictionary<int, Scroll_Item_Item> Items;
		public ItemType CurItemType;
    }
}
