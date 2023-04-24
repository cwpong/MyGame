
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRoleDetailsViewComponent : Entity,IAwake,IDestroy 
	{
		public ESItem ESKeyboardSlot
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_eskeyboardslot == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Sprite_BackGround/Equips/KeyBoardSlot/ESKeyboardSlot");
		    	   this.m_eskeyboardslot = this.AddChild<ESItem,Transform>(subTrans);
     			}
     			return this.m_eskeyboardslot;
     		}
     	}

		public ESItem ESMouseSlot
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esmouseslot == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Sprite_BackGround/Equips/KeMouseSlot/ESMouseSlot");
		    	   this.m_esmouseslot = this.AddChild<ESItem,Transform>(subTrans);
     			}
     			return this.m_esmouseslot;
     		}
     	}

		public ESItem ESHeadsetdSlot
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esheadsetdslot == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Sprite_BackGround/Equips/KeyHeadsetSlot/ESHeadsetdSlot");
		    	   this.m_esheadsetdslot = this.AddChild<ESItem,Transform>(subTrans);
     			}
     			return this.m_esheadsetdslot;
     		}
     	}

		public ESItem ESClothesSlot
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esclothesslot == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Sprite_BackGround/Equips/KeyClothesSlot/ESClothesSlot");
		    	   this.m_esclothesslot = this.AddChild<ESItem,Transform>(subTrans);
     			}
     			return this.m_esclothesslot;
     		}
     	}

		public ESItem ESPantsSlot
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_espantsslot == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Sprite_BackGround/Equips/KeyPantsSlot/ESPantsSlot");
		    	   this.m_espantsslot = this.AddChild<ESItem,Transform>(subTrans);
     			}
     			return this.m_espantsslot;
     		}
     	}

		public ESItem ESShoesSlot
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esshoesslot == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Sprite_BackGround/Equips/KeyShoesSlot/ESShoesSlot");
		    	   this.m_esshoesslot = this.AddChild<ESItem,Transform>(subTrans);
     			}
     			return this.m_esshoesslot;
     		}
     	}

		public UnityEngine.UI.Text EPhysicalAttackText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPhysicalAttackText == null )
     			{
		    		this.m_EPhysicalAttackText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Sprite_BackGround/Down/Attr/EPhysicalAttack");
     			}
     			return this.m_EPhysicalAttackText;
     		}
     	}

		public UnityEngine.UI.Text E_SpellAttackText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SpellAttackText == null )
     			{
		    		this.m_E_SpellAttackText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Sprite_BackGround/Down/Attr/E_SpellAttack");
     			}
     			return this.m_E_SpellAttackText;
     		}
     	}

		public UnityEngine.UI.Text EPhysicalDefenseText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPhysicalDefenseText == null )
     			{
		    		this.m_EPhysicalDefenseText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Sprite_BackGround/Down/Attr/EPhysicalDefense");
     			}
     			return this.m_EPhysicalDefenseText;
     		}
     	}

		public UnityEngine.UI.Text E_SpellDefenseText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SpellDefenseText == null )
     			{
		    		this.m_E_SpellDefenseText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Sprite_BackGround/Down/Attr/E_SpellDefense");
     			}
     			return this.m_E_SpellDefenseText;
     		}
     	}

		public UnityEngine.UI.Text E_SpeedText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SpeedText == null )
     			{
		    		this.m_E_SpeedText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Sprite_BackGround/Down/Attr/E_Speed");
     			}
     			return this.m_E_SpeedText;
     		}
     	}

		public UnityEngine.UI.Text EMaxHpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EMaxHpText == null )
     			{
		    		this.m_EMaxHpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Sprite_BackGround/Down/Attr/EMaxHp");
     			}
     			return this.m_EMaxHpText;
     		}
     	}

		public UnityEngine.UI.Button EButton_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CloseButton == null )
     			{
		    		this.m_EButton_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/Down/EButton_Close");
     			}
     			return this.m_EButton_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CloseImage == null )
     			{
		    		this.m_EButton_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Down/EButton_Close");
     			}
     			return this.m_EButton_CloseImage;
     		}
     	}

		public UnityEngine.UI.Slider E_SliderSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SliderSlider == null )
     			{
		    		this.m_E_SliderSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"Sprite_BackGround/Exp/E_Slider");
     			}
     			return this.m_E_SliderSlider;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_eskeyboardslot?.Dispose();
			this.m_eskeyboardslot = null;
			this.m_esmouseslot?.Dispose();
			this.m_esmouseslot = null;
			this.m_esheadsetdslot?.Dispose();
			this.m_esheadsetdslot = null;
			this.m_esclothesslot?.Dispose();
			this.m_esclothesslot = null;
			this.m_espantsslot?.Dispose();
			this.m_espantsslot = null;
			this.m_esshoesslot?.Dispose();
			this.m_esshoesslot = null;
			this.m_EPhysicalAttackText = null;
			this.m_E_SpellAttackText = null;
			this.m_EPhysicalDefenseText = null;
			this.m_E_SpellDefenseText = null;
			this.m_E_SpeedText = null;
			this.m_EMaxHpText = null;
			this.m_EButton_CloseButton = null;
			this.m_EButton_CloseImage = null;
			this.m_E_SliderSlider = null;
			this.uiTransform = null;
		}

		private ESItem m_eskeyboardslot = null;
		private ESItem m_esmouseslot = null;
		private ESItem m_esheadsetdslot = null;
		private ESItem m_esclothesslot = null;
		private ESItem m_espantsslot = null;
		private ESItem m_esshoesslot = null;
		private UnityEngine.UI.Text m_EPhysicalAttackText = null;
		private UnityEngine.UI.Text m_E_SpellAttackText = null;
		private UnityEngine.UI.Text m_EPhysicalDefenseText = null;
		private UnityEngine.UI.Text m_E_SpellDefenseText = null;
		private UnityEngine.UI.Text m_E_SpeedText = null;
		private UnityEngine.UI.Text m_EMaxHpText = null;
		private UnityEngine.UI.Button m_EButton_CloseButton = null;
		private UnityEngine.UI.Image m_EButton_CloseImage = null;
		private UnityEngine.UI.Slider m_E_SliderSlider = null;
		public Transform uiTransform = null;
	}
}
