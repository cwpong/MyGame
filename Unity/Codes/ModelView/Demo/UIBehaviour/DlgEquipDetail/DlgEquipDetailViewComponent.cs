
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgEquipDetailViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EBtn_MaskCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_MaskCloseButton == null )
     			{
		    		this.m_EBtn_MaskCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EBtn_MaskClose");
     			}
     			return this.m_EBtn_MaskCloseButton;
     		}
     	}

		public UnityEngine.UI.Image EBtn_MaskCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_MaskCloseImage == null )
     			{
		    		this.m_EBtn_MaskCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBtn_MaskClose");
     			}
     			return this.m_EBtn_MaskCloseImage;
     		}
     	}

		public ESItem ESItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_esitem == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Content/ESItem");
		    	   this.m_esitem = this.AddChild<ESItem,Transform>(subTrans);
     			}
     			return this.m_esitem;
     		}
     	}

		public UnityEngine.UI.Text EText_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EText_NameText == null )
     			{
		    		this.m_EText_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/EText_Name");
     			}
     			return this.m_EText_NameText;
     		}
     	}

		public UnityEngine.UI.Text EText_DescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EText_DescText == null )
     			{
		    		this.m_EText_DescText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/EText_Desc");
     			}
     			return this.m_EText_DescText;
     		}
     	}

		public UnityEngine.UI.Image ETAttrRootImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ETAttrRootImage == null )
     			{
		    		this.m_ETAttrRootImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/ETAttrRoot");
     			}
     			return this.m_ETAttrRootImage;
     		}
     	}

		public UnityEngine.UI.Button EBtn_OpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_OpButton == null )
     			{
		    		this.m_EBtn_OpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/Op/EBtn_Op");
     			}
     			return this.m_EBtn_OpButton;
     		}
     	}

		public UnityEngine.UI.Image EBtn_OpImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_OpImage == null )
     			{
		    		this.m_EBtn_OpImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/Op/EBtn_Op");
     			}
     			return this.m_EBtn_OpImage;
     		}
     	}

		public UnityEngine.UI.Text EText_OpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EText_OpText == null )
     			{
		    		this.m_EText_OpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/Op/EBtn_Op/EText_Op");
     			}
     			return this.m_EText_OpText;
     		}
     	}

		public UnityEngine.UI.Button EBtn_SellButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_SellButton == null )
     			{
		    		this.m_EBtn_SellButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/Op/EBtn_Sell");
     			}
     			return this.m_EBtn_SellButton;
     		}
     	}

		public UnityEngine.UI.Image EBtn_SellImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_SellImage == null )
     			{
		    		this.m_EBtn_SellImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/Op/EBtn_Sell");
     			}
     			return this.m_EBtn_SellImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_Text == null )
     			{
		    		this.m_ELabel_Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Content/Op/EBtn_Sell/ELabel_");
     			}
     			return this.m_ELabel_Text;
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
		    		this.m_EButton_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Close");
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
		    		this.m_EButton_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Close");
     			}
     			return this.m_EButton_CloseImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EBtn_MaskCloseButton = null;
			this.m_EBtn_MaskCloseImage = null;
			this.m_esitem?.Dispose();
			this.m_esitem = null;
			this.m_EText_NameText = null;
			this.m_EText_DescText = null;
			this.m_ETAttrRootImage = null;
			this.m_EBtn_OpButton = null;
			this.m_EBtn_OpImage = null;
			this.m_EText_OpText = null;
			this.m_EBtn_SellButton = null;
			this.m_EBtn_SellImage = null;
			this.m_ELabel_Text = null;
			this.m_EButton_CloseButton = null;
			this.m_EButton_CloseImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EBtn_MaskCloseButton = null;
		private UnityEngine.UI.Image m_EBtn_MaskCloseImage = null;
		private ESItem m_esitem = null;
		private UnityEngine.UI.Text m_EText_NameText = null;
		private UnityEngine.UI.Text m_EText_DescText = null;
		private UnityEngine.UI.Image m_ETAttrRootImage = null;
		private UnityEngine.UI.Button m_EBtn_OpButton = null;
		private UnityEngine.UI.Image m_EBtn_OpImage = null;
		private UnityEngine.UI.Text m_EText_OpText = null;
		private UnityEngine.UI.Button m_EBtn_SellButton = null;
		private UnityEngine.UI.Image m_EBtn_SellImage = null;
		private UnityEngine.UI.Text m_ELabel_Text = null;
		private UnityEngine.UI.Button m_EButton_CloseButton = null;
		private UnityEngine.UI.Image m_EButton_CloseImage = null;
		public Transform uiTransform = null;
	}
}
