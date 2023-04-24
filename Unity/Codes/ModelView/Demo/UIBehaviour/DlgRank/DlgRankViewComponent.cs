
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRankViewComponent : Entity,IAwake,IDestroy 
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
		    		this.m_EButton_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Content/EButton_Close");
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
		    		this.m_EButton_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/EButton_Close");
     			}
     			return this.m_EButton_CloseImage;
     		}
     	}

		public UnityEngine.UI.Image ELoopScroll_RankImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScroll_RankImage == null )
     			{
		    		this.m_ELoopScroll_RankImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Content/ELoopScroll_Rank");
     			}
     			return this.m_ELoopScroll_RankImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScroll_RankLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScroll_RankLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScroll_RankLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Content/ELoopScroll_Rank");
     			}
     			return this.m_ELoopScroll_RankLoopVerticalScrollRect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EBtn_MaskCloseButton = null;
			this.m_EBtn_MaskCloseImage = null;
			this.m_EButton_CloseButton = null;
			this.m_EButton_CloseImage = null;
			this.m_ELoopScroll_RankImage = null;
			this.m_ELoopScroll_RankLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EBtn_MaskCloseButton = null;
		private UnityEngine.UI.Image m_EBtn_MaskCloseImage = null;
		private UnityEngine.UI.Button m_EButton_CloseButton = null;
		private UnityEngine.UI.Image m_EButton_CloseImage = null;
		private UnityEngine.UI.Image m_ELoopScroll_RankImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScroll_RankLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
