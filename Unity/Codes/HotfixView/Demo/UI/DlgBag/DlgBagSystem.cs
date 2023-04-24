using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgBag))]
	[FriendClass(typeof(BagComponent))]
	public static  class DlgBagSystem
	{
		public static void RegisterUIEvent(this DlgBag self)
		{
			self.RegisterCloseEvent<DlgBag>(self.View.EButton_CloseButton);
            self.View.ETagGroupToggleGroup.AddListener(self.OnToggleSelectedHandler);
			self.View.ELoopScrollList_ItemLoopVerticalScrollRect.AddItemRefreshListener(self.OnLoopItemRefreshHandler);

			// 测试代码
			self.View.EButton_TestButton.AddListener(self.TestCeateItem);
		}

		public static void ShowWindow(this DlgBag self, Entity contextData = null)
		{
			// 默认选中武器
			self.View.EEquipToggle.IsSelected(true);
		}

		public static void HideWindow(this DlgBag self)
		{
			self.RemoveUIScrollItems(ref self.Items);

        }

		public static void RedrawItems(this DlgBag self)
		{
			self.ZoneScene().GetComponent<BagComponent>().Type2Items.TryGetValue((int)self.CurItemType, out var itemList);
			var showCount = itemList == null ? 0 : itemList.Count;
			self.AddUIScrollItems(ref self.Items, showCount);
			self.View.ELoopScrollList_ItemLoopVerticalScrollRect.SetVisible(true, showCount);
		}

		private static void OnToggleSelectedHandler(this DlgBag self, int index)
		{
			self.CurItemType = (ItemType)index;
			self.RedrawItems();
		}

        private static void OnLoopItemRefreshHandler(this DlgBag self, Transform root, int index)
        {
			self.ZoneScene().GetComponent<BagComponent>().Type2Items.TryGetValue((int)self.CurItemType, out var items);
			var scrollItem = self.Items[index].BindTrans(root);
			scrollItem.Refresh(items[index].Id);
        }

		private static void TestCeateItem(this DlgBag self)
		{
            //self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_TestCreateItem());
            self.ZoneScene().GetComponent<SessionComponent>().Session.Send(new C2M_TestStartBattle());
        }
    }
}
