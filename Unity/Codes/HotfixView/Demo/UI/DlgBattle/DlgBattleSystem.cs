using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

namespace ET
{
	[FriendClass(typeof(DlgBattle))]
	public static  class DlgBattleSystem
	{

		public static void RegisterUIEvent(this DlgBattle self)
		{
			self.RegisterCloseEvent<DlgBattle>(self.View.EBtnExitButton);
			self.View.EBtnBeginButton.AddListenerAsync(()=>
			{
				return self.BeginBattle();
            });
		}

		public static void ShowWindow(this DlgBattle self, Entity contextData = null)
		{
            var battleCom = self.DomainScene().GetComponent<BattleSceneComponent>();
			if (battleCom != null)
			{
				var fighters = battleCom.GetAllFighters();
				for (int i = 0; i < fighters.Count; ++i)
				{
					var fighter = fighters[i];
					BattleHelper.LogFighterNumericInfo(fighter, 0, true);
				}
			}

			// 创建预设
        }

		
		private static async ETTask BeginBattle(this DlgBattle self)
		{
			M2C_GetBattleRecord m2c_GetBattleRecord = null;
			try
			{
				m2c_GetBattleRecord = (M2C_GetBattleRecord)await self.ZoneScene().GetComponent<SessionComponent>().Session.Call(new C2M_GetBattleRecord());
				if (m2c_GetBattleRecord.Error != ErrorCode.ERR_Success)
				{
					Log.Error("获取战斗记录失败");
					return;
				}

				// 根据记录播放表现
				var records = m2c_GetBattleRecord.OneBattleRecords;
				for (int i = 0; i < records.Count; ++i)
				{
					var record = records[i];
					Log.Warning($"战斗记录 ===> 第{record.CurRound}回合 {record.Attacker} 使用技能{record.SkillId}");
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}
			await ETTask.CompletedTask;
		}
	}
}
