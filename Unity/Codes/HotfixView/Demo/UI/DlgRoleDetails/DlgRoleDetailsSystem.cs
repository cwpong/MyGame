namespace ET
{
	[FriendClass(typeof(DlgRoleDetails))]
	[FriendClass(typeof(EquipmentsComponent))]
	public static  class DlgRoleDetailsSystem
	{

		public static void RegisterUIEvent(this DlgRoleDetails self)
		{
			self.RegisterCloseEvent<DlgRoleDetails>(self.View.EButton_CloseButton);
		}

		public static void ShowWindow(this DlgRoleDetails self, Entity contextData = null)
		{
			FnDrawEquipItems(self);
			FnUpdateAttrUI(self);
		}

		private static void FnDrawEquipItems(this DlgRoleDetails self)
		{
			var equipMents = self.ZoneScene().GetComponent<EquipmentsComponent>();

			// 几个位置的装备 现在只有键盘跟鼠标 先写
			Log.Warning($"equip = {equipMents.EquipItems.Count}");
			if (equipMents.EquipItems.TryGetValue((int)EquipPosition.Keyboard, out var keybord))
			{
				self.View.ESKeyboardSlot.SetItemData(keybord);
				self.View.ESKeyboardSlot.SetClickHandler(() =>
				{
                    self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_EquipDetail);
                    self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgEquipDetail>().RefreshInfo(keybord, ItemOwner.Role);
				});
			}
			else
			{
				Log.Warning("没有穿键盘");
			}

			if (equipMents.EquipItems.TryGetValue((int)EquipPosition.Mouse, out var mouse))
			{
                self.View.ESMouseSlot.SetItemData(mouse);
                self.View.ESKeyboardSlot.SetClickHandler(() =>
                {
                    self.ZoneScene().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_EquipDetail);
                    self.ZoneScene().GetComponent<UIComponent>().GetDlgLogic<DlgEquipDetail>().RefreshInfo(mouse, ItemOwner.Role);
                });
            }
            else
            {
                Log.Warning("没有穿鼠标");
            }
        }

        public static void FnUpdateAttrUI(this DlgRoleDetails self)
		{
			// 获取当前玩家Unit
			var unit = UnitHelper.GetMyUnitFromCurrentScene(self.ZoneScene().CurrentScene());
			var numCom = unit.GetComponent<NumericComponent>();

			var physicalAttack = numCom.GetAsLong((int)NumericType.PhysicalAttack);
			self.View.EPhysicalAttackText.SetText($"物理攻击：{physicalAttack}");

			var spellAttack = numCom.GetAsLong((int)NumericType.SpellAttack);
			self.View.E_SpellAttackText.SetText($"魔法攻击：{spellAttack}");

            var physicalDefense = numCom.GetAsLong((int)NumericType.PhysicalDefense);
            self.View.EPhysicalDefenseText.SetText($"物理防御：{physicalDefense}");

            var spellDefense = numCom.GetAsLong((int)NumericType.SpellDefense);
            self.View.E_SpellDefenseText.SetText($"魔法防御：{spellDefense}");

            var speed = numCom.GetAsLong((int)NumericType.Speed);
            self.View.E_SpeedText.SetText($"速度：{physicalAttack}");

            var maxHp = numCom.GetAsLong((int)NumericType.MaxHp);
            self.View.EMaxHpText.SetText($"气血：{maxHp}");
        }
    }
}
