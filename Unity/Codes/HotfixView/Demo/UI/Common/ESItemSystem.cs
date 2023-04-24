using System;
using System.Runtime.CompilerServices;

namespace ET
{
    // 公共的物品UI 负责显示背景边框 图标 数量 点击事件，可以通过参数修改显示规则
    public static class ESItemSystem
    {
        public static void SetItemData(this ESItem self, Item item)
        {
            self.EImg_IconImage.overrideSprite = IconHelper.LoadIconSprite("EquipIcon", item.Config.Icon);
            self.EImg_BgBorderImage.color = item.GetBgColor();
            self.ELabel_CountText.SetText(string.Empty);
        }

        public static void SetItemCount(this ESItem self, int count)
        {
            self.ELabel_CountText.SetText(count.ToString());
        }

        public static void SetClickHandler(this ESItem self, Action cb)
        {
            self.EBtn_SelectButton.AddListenerWithParam(self.OnItemClick, cb);
        }

        public static void OnItemClick(this ESItem self, Action cb)
        {
            cb?.Invoke();
        }
    }
}
