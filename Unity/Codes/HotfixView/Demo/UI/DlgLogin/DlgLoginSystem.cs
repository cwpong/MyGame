using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

namespace ET
{
	public static  class DlgLoginSystem
	{

		public static void RegisterUIEvent(this DlgLogin self)
		{
			self.View.E_LoginButton.AddListenerAsync(() => { return self.OnLoginClickHandler();});
		}

		public static void ShowWindow(this DlgLogin self, Entity contextData = null)
		{

        }
		
		public static async ETTask OnLoginClickHandler(this DlgLogin self)
		{
			try
			{
                var errcode = await LoginHelper.Login(
                self.DomainScene(),
                ConstValue.LoginAddress,
                self.View.E_AccountInputField.GetComponent<InputField>().text,
                self.View.E_PasswordInputField.GetComponent<InputField>().text);

				if (errcode != ErrorCode.ERR_Success)
				{
					Log.Error(errcode.ToString());
					return;
				}

				errcode = await LoginHelper.GetServerInfos(self.ZoneScene());
				if (errcode != ErrorCode.ERR_Success )
				{
					Log.Error(errcode.ToString() + "获取服务器列表失败");
					return;
				}

				self.DomainScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
                self.DomainScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Server);
            }
			catch (Exception e) 
			{
				Log.Error(e.ToString());
			}
		}
		
		public static void HideWindow(this DlgLogin self)
		{

		}
		
	}
}
