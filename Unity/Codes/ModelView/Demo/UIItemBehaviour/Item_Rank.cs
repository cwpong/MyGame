
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class Scroll_Item_Rank : Entity,IAwake,IDestroy,IUIScrollItem 
	{
		public long DataId {get;set;}
		private bool isCacheNode = false;
		public void SetCacheMode(bool isCache)
		{
			this.isCacheNode = isCache;
		}

		public Scroll_Item_Rank BindTrans(Transform trans)
		{
			this.uiTransform = trans;
			return this;
		}

		public UnityEngine.UI.Text ETextNameText
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
     				if( this.m_ETextNameText == null )
     				{
		    			this.m_ETextNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bg/ETextName");
     				}
     				return this.m_ETextNameText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bg/ETextName");
     			}
     		}
     	}

		public UnityEngine.UI.Text ETextRankText
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
     				if( this.m_ETextRankText == null )
     				{
		    			this.m_ETextRankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bg/ETextRank");
     				}
     				return this.m_ETextRankText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bg/ETextRank");
     			}
     		}
     	}

		public UnityEngine.UI.Text ETextLvText
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
     				if( this.m_ETextLvText == null )
     				{
		    			this.m_ETextLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bg/ETextLv");
     				}
     				return this.m_ETextLvText;
     			}
     			else
     			{
		    		return UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Bg/ETextLv");
     			}
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ETextNameText = null;
			this.m_ETextRankText = null;
			this.m_ETextLvText = null;
			this.uiTransform = null;
			this.DataId = 0;
		}

		private UnityEngine.UI.Text m_ETextNameText = null;
		private UnityEngine.UI.Text m_ETextRankText = null;
		private UnityEngine.UI.Text m_ETextLvText = null;
		public Transform uiTransform = null;
	}
}
