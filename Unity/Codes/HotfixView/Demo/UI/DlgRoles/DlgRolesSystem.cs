using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgRoles))]
	[FriendClass(typeof(RoleInfosComponent))]
	[FriendClass(typeof(RoleInfo))]
	public static  class DlgRolesSystem
	{

		public static void RegisterUIEvent(this DlgRoles self)
		{
			self.View.EButton_BeginButton.AddListenerAsync(()=>
			{
				return self.OnBeginBtnClick();
            });

			self.View.EButton_CreateButton.AddListenerAsync(()=>
			{
				return self.OnCreateBtnClick();
            });

			self.View.EButton_DeleteButton.AddListenerAsync(() =>
            {
                return self.OnDeleteBtnClick();
            });

			self.View.ELoopScrollList_RolesLoopVerticalScrollRect.AddItemRefreshListener((Transform transform, int index) =>
			{
				self.OnRoleListRefreshHandler(transform, index);
            });
        }

		public static void ShowWindow(this DlgRoles self, Entity contextData = null)
		{
			self.RefreshRoleItems();
        }

		public static void RefreshRoleItems(this DlgRoles self)
		{

            int count = self.ZoneScene().GetComponent<RoleInfosComponent>().List_RoleInfos.Count;
            self.AddUIScrollItems(ref self.Dict_RoleItem, count);
            self.View.ELoopScrollList_RolesLoopVerticalScrollRect.SetVisible(true, count);
        }

		/// <summary>
		/// 进入游戏
		/// </summary>
		/// <param name="self"></param>
		/// <returns></returns>
		private static async ETTask OnBeginBtnClick(this DlgRoles self)
		{
            if (self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
            {
                Log.Error("请选择角色");
                return;
            }

            try
            {
                var errorCode = await LoginHelper.GetRelamKey(self.ZoneScene());
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error($"GetRelamKey Faild {errorCode}");
                    return;
                }

				Log.Warning("请求进入游戏服");
				// 进入游戏
				errorCode = await LoginHelper.EnterGame(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error($"EnterGame faild {errorCode}");
					return;
				}

				self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Main);
				self.ZoneScene().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Roles);
				// 游戏主界面
				Log.Warning("打开游戏主界面");
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return;
            }

            await ETTask.CompletedTask;
        }


        private static async ETTask OnCreateBtnClick(this DlgRoles self)
        {
			var name = self.View.EInput_NameInputField.text;

			if (string.IsNullOrEmpty(name))
			{
				Log.Error("Name is empty");
				return;
			}

			try
			{
				var errorCode = await LoginHelper.CreateRole(self.ZoneScene(), name);
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error($"Create Role Faild {errorCode}");
					return;
				}

				self.RefreshRoleItems();
			}
			catch(Exception ex)
			{
				Log.Error(ex.ToString());
			}
			
            await ETTask.CompletedTask;
        }

        private static async ETTask OnDeleteBtnClick(this DlgRoles self)
        {
			if(self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId == 0)
			{
				Log.Error("请选择需要删除的角色");
				return;
			}

			try
			{
				var errorCode = await LoginHelper.DeleteRole(self.ZoneScene());
				if (errorCode != ErrorCode.ERR_Success)
				{
					Log.Error($"Delete Role Faild {errorCode}");
					return;
				}

				self.RefreshRoleItems();
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
				return;
			}

            await ETTask.CompletedTask;
        }

		// 设置组件状态
		private static void OnRoleListRefreshHandler(this DlgRoles self, Transform transform, int index)
		{
            var roleItem = self.Dict_RoleItem[index].BindTrans(transform);
            var info = self.ZoneScene().GetComponent<RoleInfosComponent>().List_RoleInfos[index];
			roleItem.ELabel_NameText.SetText(info.Str_Name);
			Log.Warning($"info.Long_RoleId = {info.Long_RoleId}  self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = {self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId}");
			roleItem.EImg_SelectImage.color = info.Long_RoleId == self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId ? Color.red : Color.cyan;
			roleItem.EImg_SelectButton.AddListener(() =>
			{
				self.OnSelectRoleHandler(info.Long_RoleId);
            });
        }

		private static void OnSelectRoleHandler(this DlgRoles self, long Id)
		{
			self.ZoneScene().GetComponent<RoleInfosComponent>().CurrentRoleId = Id;
            self.RefreshRoleItems();
        }
    }
}
