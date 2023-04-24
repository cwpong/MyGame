
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Server : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Server BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Image EImg_BgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EImg_BgImage == null )
     				{
		    			this.m_EImg_BgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImg_Bg");
     				}
     				return this.m_EImg_BgImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImg_Bg");
     			}
     		}
     	}

		public UnityEngine.UI.Text EText_ServerNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EText_ServerNameText == null )
     				{
		    			this.m_EText_ServerNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EImg_Bg/EText_ServerName");
     				}
     				return this.m_EText_ServerNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EImg_Bg/EText_ServerName");
     			}
     		}
     	}

		public UnityEngine.UI.Button EButton_SelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_SelectButton == null )
     				{
		    			this.m_EButton_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Select");
     				}
     				return this.m_EButton_SelectButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EButton_Select");
     			}
     		}
     	}

		public UnityEngine.UI.Image EButton_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if (this.isCacheNode)
     			{
     				if( this.m_EButton_SelectImage == null )
     				{
		    			this.m_EButton_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Select");
     				}
     				return this.m_EButton_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EButton_Select");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImg_BgImage = null;
			this.m_EText_ServerNameText = null;
			this.m_EButton_SelectButton = null;
			this.m_EButton_SelectImage = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Image m_EImg_BgImage = null;
		private UnityEngine.UI.Text m_EText_ServerNameText = null;
		private UnityEngine.UI.Button m_EButton_SelectButton = null;
		private UnityEngine.UI.Image m_EButton_SelectImage = null;
		public Transform uiTransform = null;
	}
}
