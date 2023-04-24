
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Role : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Role BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Button EImg_SelectButton
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
     				if( this.m_EImg_SelectButton == null )
     				{
		    			this.m_EImg_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EImg_Select");
     				}
     				return this.m_EImg_SelectButton;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EImg_Select");
     			}
     		}
     	}

		public UnityEngine.UI.Image EImg_SelectImage
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
     				if( this.m_EImg_SelectImage == null )
     				{
		    			this.m_EImg_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImg_Select");
     				}
     				return this.m_EImg_SelectImage;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImg_Select");
     			}
     		}
     	}

		public UnityEngine.UI.Text ELabel_NameText
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
     				if( this.m_ELabel_NameText == null )
     				{
		    			this.m_ELabel_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Name");
     				}
     				return this.m_ELabel_NameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"ELabel_Name");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImg_SelectButton = null;
			this.m_EImg_SelectImage = null;
			this.m_ELabel_NameText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Button m_EImg_SelectButton = null;
		private UnityEngine.UI.Image m_EImg_SelectImage = null;
		private UnityEngine.UI.Text m_ELabel_NameText = null;
		public Transform uiTransform = null;
	}
}
