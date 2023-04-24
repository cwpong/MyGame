using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public static class Scroll_Item_BagItemSystem
    {
        public static void Refresh(this Scroll_Item_Item self, long uid)
        {
            var item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(uid);
            self.EImg_IconImage.overrideSprite = IconHelper.LoadIconSprite("EquipIcon", item.Config.Icon);
            self.EImg_BgBorderImage.color = item.GetBgColor();

            // 装备不可叠加 先用1吧
            self.ELabel_CountText.SetText("1");
            self.EBtn_SelectButton.AddListenerWithId(self.OnItemBtnClick, uid);
        }

        /// <summary>
        /// 点击物品
        /// </summary>
        /// <param name="self"></param>
        /// <param name="uid"></param>
        public static void OnItemBtnClick(this Scroll_Item_Item self, long uid)
        {
            // TODO 根据类型打开不同的界面 现在只有装备界面
            self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_EquipDetail);
            Item item = self.ZoneScene().GetComponent<BagComponent>().GetItemById(uid);
            self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgEquipDetail>().RefreshInfo(item, ItemOwner.Bag);
        }
    }
}
