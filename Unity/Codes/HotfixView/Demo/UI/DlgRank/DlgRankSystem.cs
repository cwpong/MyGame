using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

namespace ET
{
	[FriendClass(typeof(DlgRank))]
    [FriendClass(typeof(RankInfo))]

	public static  class DlgRankSystem
	{
        [Timer(TimerType.RefreshRankUI)]
        public class RankUITimer : ATimer<DlgRank>
        {
            public override void Run(DlgRank dlg)
            {
                dlg?.DrawRankInfo().Coroutine();
            }
        }


        public static void RegisterUIEvent(this DlgRank self)
		{
			self.RegisterCloseEvent<DlgRank>(self.View.EButton_CloseButton);
			self.View.ELoopScroll_RankLoopVerticalScrollRect.AddItemRefreshListener((trans, index) =>
			{
				self.OnLoopChange(trans, index);
            });
		}

		public static void ShowWindow(this DlgRank self, Entity contextData = null)
		{
			self.DrawRankInfo().Coroutine();

            // 定时刷新 (可能不需要，先学个示例) 毫秒为单位
            self.Timer = TimerComponent.Instance.NewRepeatedTimer(5000, TimerType.RefreshRankUI, self);
        }

		public static void HideWindow(this DlgRank self, Entity contextData = null)
		{
            TimerComponent.Instance.Remove(ref self.Timer);
        }

		private static void OnLoopChange(this DlgRank self, Transform transform, int index)
		{
            var scrollItem = self.ScrollItemRanks[index].BindTrans(transform);
            var rankInfo = self.ZoneScene().GetComponent<RankComponent>().GetRankInfoByIndex(index);
            var order = index + 1;

            scrollItem.ETextRankText.SetText(order.ToString());
            scrollItem.ETextNameText.SetText(rankInfo.Name);
            scrollItem.ETextLvText.SetText($"Lv.{rankInfo.Lv}");

        }

		private static async ETTask DrawRankInfo(this DlgRank self)
		{
            try
            {
                Scene ZoneScene = self.ZoneScene();
                int errorCode = await RankHelper.GetRankInfo(ZoneScene);
                if (errorCode != ErrorCode.ERR_Success)
                {
                    Log.Error(errorCode.ToString());
                    return;
                }

                if (!ZoneScene.GetComponent<UIComponent>().IsWindowVisible(WindowID.WindowID_Rank))
                    return;

                int count = self.ZoneScene().GetComponent<RankComponent>().GetRankCount();
                self.AddUIScrollItems(ref self.ScrollItemRanks, count);
                self.View.ELoopScroll_RankLoopVerticalScrollRect.SetVisible(true, count);
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }
        }

    }
}
