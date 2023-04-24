
using System;
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EImg_BgBorderImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImg_BgBorderImage == null )
     			{
		    		this.m_EImg_BgBorderImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImg_BgBorder");
     			}
     			return this.m_EImg_BgBorderImage;
     		}
     	}

		public UnityEngine.UI.Image EImg_IconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EImg_IconImage == null )
     			{
		    		this.m_EImg_IconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EImg_BgBorder/EImg_Icon");
     			}
     			return this.m_EImg_IconImage;
     		}
     	}

		public UnityEngine.UI.Text ELabel_CountText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_CountText == null )
     			{
		    		this.m_ELabel_CountText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EImg_BgBorder/ELabel_Count");
     			}
     			return this.m_ELabel_CountText;
     		}
     	}

		public UnityEngine.UI.Button EBtn_SelectButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_SelectButton == null )
     			{
		    		this.m_EBtn_SelectButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EBtn_Select");
     			}
     			return this.m_EBtn_SelectButton;
     		}
     	}

		public UnityEngine.UI.Image EBtn_SelectImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtn_SelectImage == null )
     			{
		    		this.m_EBtn_SelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EBtn_Select");
     			}
     			return this.m_EBtn_SelectImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EImg_BgBorderImage = null;
			this.m_EImg_IconImage = null;
			this.m_ELabel_CountText = null;
			this.m_EBtn_SelectButton = null;
			this.m_EBtn_SelectImage = null;
			this.uiTransform = null;
		}

        private UnityEngine.UI.Image m_EImg_BgBorderImage = null;
		private UnityEngine.UI.Image m_EImg_IconImage = null;
		private UnityEngine.UI.Text m_ELabel_CountText = null;
		private UnityEngine.UI.Button m_EBtn_SelectButton = null;
		private UnityEngine.UI.Image m_EBtn_SelectImage = null;
		public Transform uiTransform = null;
	}
}
