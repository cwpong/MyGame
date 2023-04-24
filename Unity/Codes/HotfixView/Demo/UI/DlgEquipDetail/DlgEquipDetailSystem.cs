using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
    /// <summary>
    /// 装备详情界面
    /// </summary>
    [FriendClass(typeof(AttributeEntry))]
    [FriendClass(typeof(EquipInfoComponent))]
    [FriendClass(typeof(DlgEquipDetail))]
	public static  class DlgEquipDetailSystem
	{
        public static void RegisterUIEvent(this DlgEquipDetail self)
        {
            self.RegisterCloseEvent<DlgEquipDetail>(self.View.EBtn_MaskCloseButton);
            self.RegisterCloseEvent<DlgEquipDetail>(self.View.EButton_CloseButton);
           
            self.View.EBtn_SellButton.AddListenerAsync(self.OnSellItemHandler);
        }

        public static void ShowWindow(this DlgEquipDetail self, Entity contextData = null)
        {
            //self.View.
        }

        public static void HideWindow(this DlgEquipDetail self)
        {
            //self.RemoveUIScrollItems(ref self.ScrollItemEntries);
        }


        public static void OnEntryLoopHandler(this DlgEquipDetail self, Transform transform, int index)
        {
            //Scroll_Item_entry scrollItemEntry = self.ScrollItemEntries[index].BindTrans(transform);
            //Item item = ItemHelper.GetItem(self.ZoneScene(), self.ItemId, self.ItemContainerType);
            //AttributeEntry entry = item.GetComponent<EquipInfoComponent>().EntryList[index];
            //scrollItemEntry.E_EntryNameText.text = PlayerNumericConfigCategory.Instance.Get(entry.Key).Name + ":";
            //bool isPrcent = PlayerNumericConfigCategory.Instance.Get(entry.Key).isPrecent > 0;
            //scrollItemEntry.E_EntryValueText.text = "+" + (isPrcent ? $"{(entry.Value / 10000.0f).ToString("0.00")}%" : entry.Value.ToString());
        }

        public static void RefreshInfo(this DlgEquipDetail self, Item item, ItemOwner itemOwner)
        {
            self.ItemUid = item.Id;
            self.ItemOwner = itemOwner;

            // 背景框颜色 后面设计一个公共UI
            self.View.ESItem.SetItemData(item);
            self.View.EText_NameText.SetText(item.Config.Name);
            self.View.EText_DescText.SetText(item.Config.Desc);
            var isLoad = itemOwner == ItemOwner.Role;
            var enableSell = !isLoad;
            self.View.EBtn_SellButton.SetVisible(enableSell);
            if (isLoad)
            {
                self.View.EBtn_OpButton.AddListenerAsync(() => { return self.OnOpBtnClickHandler(true);});
                self.View.EText_OpText.SetText("卸下");
            }
            else
            {
                self.View.EBtn_OpButton.AddListenerAsync(() => { return self.OnOpBtnClickHandler(false);});
                self.View.EText_OpText.SetText("穿戴");
            }

            self.DrawEntries(item);
        }

        public static void DrawEntries(this DlgEquipDetail self, Item item)
        {
            var equipInfo = item.GetComponent<EquipInfoComponent>();
            var count = equipInfo.EntryList.Count;
            Log.Warning($"属性词条数量 = {count}");
            EUIHelper.GenerateByTempalte(self.View.ETAttrRootImage.transform, count);
            for (int i = 0; i < equipInfo.EntryList.Count; ++i)
            {
                var typeId = equipInfo.EntryList[i].Key;
                var value = equipInfo.EntryList[i].Value;
                var cfg = PlayerNumericConfigCategory.Instance.Get(typeId);
                var text = self.View.ETAttrRootImage.transform.GetChild(i).GetComponent<Text>();
                if (cfg != null)
                {
                    text.SetText($"{cfg.Name} +{value}");
                }
                else
                {
                    Log.Error($"没有id = {typeId}的属性配置");
                    text.SetText(string.Empty);
                }
            }
        }

        /// <summary>
        /// 穿戴/卸下
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static async ETTask OnOpBtnClickHandler(this DlgEquipDetail self, bool isUnload)
        {
            if (isUnload)
            {
                // 卸下装备
                try
                {
                    int errorCode = await ItemApplyHelper.UnloadEquipItem(self.ZoneScene(), self.ItemUid);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        Log.Error(errorCode.ToString());
                        return;
                    }

                    self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_EquipDetail);
                    self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgBag>().RedrawItems();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }
            else
            {
                // 穿戴装备
                try
                {
                    int errorCode = await ItemApplyHelper.EquipItem(self.ZoneScene(), self.ItemUid);
                    if (errorCode != ErrorCode.ERR_Success)
                    {
                        Log.Error(errorCode.ToString());
                        return;
                    }
                    self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_EquipDetail);
                    self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgBag>().RedrawItems();
                }
                catch (Exception e)
                {
                    Log.Error(e.ToString());
                }
            }

            await ETTask.CompletedTask;
        }

        public static async ETTask OnSellItemHandler(this DlgEquipDetail self)
        {
            try
            {
                int errorCode = await ItemApplyHelper.SellBagItem(self.ZoneScene(), self.ItemUid);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_EquipDetail);
                self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgBag>().RedrawItems();
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }
    }
}
