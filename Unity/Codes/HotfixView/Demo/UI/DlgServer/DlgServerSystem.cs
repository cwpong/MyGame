using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof(ServerInfosComponent))]
    [FriendClass(typeof(DlgServer))]
    [FriendClass(typeof(ServerInfo))]
    public static class DlgServerSystem
    {
        public static void RegisterUIEvent(this DlgServer self)
        {
            self.View.EButton_ConfirmButton.AddListenerAsync(()=>
            {
                return self.OnConfirmClickHandler();
            });

            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index)=>
            {
                self.OnValueChange(transform, index);
            });
        }

        public static void ShowWindow(this DlgServer self, Entity contextData = null)
        {
            int count = self.ZoneScene().GetComponent<ServerInfosComponent>().List_ServerInfo.Count;
            self.AddUIScrollItems(ref self.dict_ServerItem, count);
            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.SetVisible(true, count);
        }

        public static void OnValueChange(this DlgServer self, Transform transform, int index)
        {
            var serverItem = self.dict_ServerItem[index].BindTrans(transform);
            var info = self.ZoneScene().GetComponent<ServerInfosComponent>().List_ServerInfo[index];
            serverItem.EText_ServerNameText.SetText(info.Str_ServerName);
            serverItem.EImg_BgImage.color = info.Id == self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId ? Color.red : Color.cyan;
            serverItem.EButton_SelectButton.AddListener(()=>
            {
                self.OnSelectServerItemHandler(info.Id);
            });
        }

        public static void OnSelectServerItemHandler(this DlgServer self, long serverId)
        {
            self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId = int.Parse(serverId.ToString());
            Log.Debug($"当前选择的服务器ID是 {serverId}");
            self.View.ELoopScrollList_ServerLoopVerticalScrollRect.RefillCells();
        }

        public static async ETTask OnConfirmClickHandler(this DlgServer self)
        {
            var isSelect = self.ZoneScene().GetComponent<ServerInfosComponent>().CurrentServerId != 0;

            if (!isSelect)
            {
                Debug.LogError("未选择区服");
                return;
            }

            try
            {
                var errorCode = await LoginHelper.GetRoles(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString() + "获取角色失败");
                    return;
                }

                self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Roles);
                self.ZoneScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Server);

            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}
