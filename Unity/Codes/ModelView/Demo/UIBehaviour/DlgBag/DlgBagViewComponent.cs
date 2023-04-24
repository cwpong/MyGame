
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgBagViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Image ELoopScrollList_ItemImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ItemImage == null )
     			{
		    		this.m_ELoopScrollList_ItemImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/ELoopScrollList_Item");
     			}
     			return this.m_ELoopScrollList_ItemImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_ItemLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ItemLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ItemLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/ELoopScrollList_Item");
     			}
     			return this.m_ELoopScrollList_ItemLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.ToggleGroup ETagGroupToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETagGroupToggleGroup == null )
     			{
		    		this.m_ETagGroupToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Sprite_BackGround/ETagGroup");
     			}
     			return this.m_ETagGroupToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle EEquipToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EEquipToggle == null )
     			{
		    		this.m_EEquipToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Sprite_BackGround/ETagGroup/EEquip");
     			}
     			return this.m_EEquipToggle;
     		}
     	}

		public UnityEngine.UI.Toggle EConsumablesToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EConsumablesToggle == null )
     			{
		    		this.m_EConsumablesToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Sprite_BackGround/ETagGroup/EConsumables");
     			}
     			return this.m_EConsumablesToggle;
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
		    		this.m_EButton_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_Close");
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
		    		this.m_EButton_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_Close");
     			}
     			return this.m_EButton_CloseImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_TestButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TestButton == null )
     			{
		    		this.m_EButton_TestButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_Test");
     			}
     			return this.m_EButton_TestButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_TestImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TestImage == null )
     			{
		    		this.m_EButton_TestImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_Test");
     			}
     			return this.m_EButton_TestImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELoopScrollList_ItemImage = null;
			this.m_ELoopScrollList_ItemLoopVerticalScrollRect = null;
			this.m_ETagGroupToggleGroup = null;
			this.m_EEquipToggle = null;
			this.m_EConsumablesToggle = null;
			this.m_EButton_CloseButton = null;
			this.m_EButton_CloseImage = null;
			this.m_EButton_TestButton = null;
			this.m_EButton_TestImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_ELoopScrollList_ItemImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_ItemLoopVerticalScrollRect = null;
		private UnityEngine.UI.ToggleGroup m_ETagGroupToggleGroup = null;
		private UnityEngine.UI.Toggle m_EEquipToggle = null;
		private UnityEngine.UI.Toggle m_EConsumablesToggle = null;
		private UnityEngine.UI.Button m_EButton_CloseButton = null;
		private UnityEngine.UI.Image m_EButton_CloseImage = null;
		private UnityEngine.UI.Button m_EButton_TestButton = null;
		private UnityEngine.UI.Image m_EButton_TestImage = null;
		public Transform uiTransform = null;
	}
}
