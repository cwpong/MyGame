using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET
{
	[FriendClass(typeof(DlgMain))]
	public static  class DlgMainSystem
	{

		public static void RegisterUIEvent(this DlgMain self)
		{
			self.View.EButton_RoleButton.AddListener(()=>
			{
				//self.ZoneScene().GetComponent<UIComponent>().HideWindow<DlgMain>();
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow<DlgRoleDetails>();
            });

			self.View.EButton_BagButton.AddListener(()=>
			{
                // self.ZoneScene().GetComponent<UIComponent>().HideWindow<DlgMain>();
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow<DlgBag>();
            });

			self.View.EButton_RankButton.AddListener(() =>
			{
                self.ZoneScene().GetComponent<UIComponent>().ShowWindow<DlgRank>();
            });

			self.View.EBeginBattleBtnButton.AddListenerAsync(()=>
			{
				return self.EnterBattle();

            });
		}

		public static void ShowWindow(this DlgMain self, Entity contextData = null)
		{
		}

		private static async ETTask EnterBattle(this DlgMain self)
		{
			await BattleHelper.EnterBattleScene(self.ZoneScene());

			self.ZoneScene().GetComponent<UIComponent>().HideWindow<DlgMain>();
			self.ZoneScene().GetComponent<UIComponent>().ShowWindow<DlgBattle>();
		}
	}
}
