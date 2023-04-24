
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgPatchViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Text ELabel_TipsText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELabel_TipsText == null )
     			{
		    		this.m_ELabel_TipsText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image/Content/ELabel_Tips");
     			}
     			return this.m_ELabel_TipsText;
     		}
     	}

		public UnityEngine.UI.Button EButton_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ConfirmButton == null )
     			{
		    		this.m_EButton_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image/Content/EButton_Confirm");
     			}
     			return this.m_EButton_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ConfirmImage == null )
     			{
		    		this.m_EButton_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image/Content/EButton_Confirm");
     			}
     			return this.m_EButton_ConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_CancelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CancelButton == null )
     			{
		    		this.m_EButton_CancelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Image/Content/EButton_Cancel");
     			}
     			return this.m_EButton_CancelButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CancelImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CancelImage == null )
     			{
		    		this.m_EButton_CancelImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Image/Content/EButton_Cancel");
     			}
     			return this.m_EButton_CancelImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELabel_TipsText = null;
			this.m_EButton_ConfirmButton = null;
			this.m_EButton_ConfirmImage = null;
			this.m_EButton_CancelButton = null;
			this.m_EButton_CancelImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_ELabel_TipsText = null;
		private UnityEngine.UI.Button m_EButton_ConfirmButton = null;
		private UnityEngine.UI.Image m_EButton_ConfirmImage = null;
		private UnityEngine.UI.Button m_EButton_CancelButton = null;
		private UnityEngine.UI.Image m_EButton_CancelImage = null;
		public Transform uiTransform = null;
	}
}
