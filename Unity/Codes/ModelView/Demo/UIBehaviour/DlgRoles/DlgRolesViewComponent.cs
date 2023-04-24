
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgRolesViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EGBackGroundRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EGBackGroundRectTransform == null )
     			{
		    		this.m_EGBackGroundRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EGBackGround");
     			}
     			return this.m_EGBackGroundRectTransform;
     		}
     	}

		public UnityEngine.UI.Image ELoopScrollList_RolesImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_RolesImage == null )
     			{
		    		this.m_ELoopScrollList_RolesImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EGBackGround/ELoopScrollList_Roles");
     			}
     			return this.m_ELoopScrollList_RolesImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_RolesLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_RolesLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_RolesLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EGBackGround/ELoopScrollList_Roles");
     			}
     			return this.m_ELoopScrollList_RolesLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button EButton_CreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateButton == null )
     			{
		    		this.m_EButton_CreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Down/EButton_Create");
     			}
     			return this.m_EButton_CreateButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_CreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_CreateImage == null )
     			{
		    		this.m_EButton_CreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Down/EButton_Create");
     			}
     			return this.m_EButton_CreateImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_DeleteButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_DeleteButton == null )
     			{
		    		this.m_EButton_DeleteButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Down/EButton_Delete");
     			}
     			return this.m_EButton_DeleteButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_DeleteImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_DeleteImage == null )
     			{
		    		this.m_EButton_DeleteImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Down/EButton_Delete");
     			}
     			return this.m_EButton_DeleteImage;
     		}
     	}

		public UnityEngine.UI.Button EButton_BeginButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BeginButton == null )
     			{
		    		this.m_EButton_BeginButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Down/EButton_Begin");
     			}
     			return this.m_EButton_BeginButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_BeginImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BeginImage == null )
     			{
		    		this.m_EButton_BeginImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Down/EButton_Begin");
     			}
     			return this.m_EButton_BeginImage;
     		}
     	}

		public UnityEngine.UI.InputField EInput_NameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_NameInputField == null )
     			{
		    		this.m_EInput_NameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EInput_Name");
     			}
     			return this.m_EInput_NameInputField;
     		}
     	}

		public UnityEngine.UI.Image EInput_NameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EInput_NameImage == null )
     			{
		    		this.m_EInput_NameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EInput_Name");
     			}
     			return this.m_EInput_NameImage;
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
     			if( this.m_ELabel_NameText == null )
     			{
		    		this.m_ELabel_NameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EInput_Name/ELabel_Name");
     			}
     			return this.m_ELabel_NameText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EGBackGroundRectTransform = null;
			this.m_ELoopScrollList_RolesImage = null;
			this.m_ELoopScrollList_RolesLoopVerticalScrollRect = null;
			this.m_EButton_CreateButton = null;
			this.m_EButton_CreateImage = null;
			this.m_EButton_DeleteButton = null;
			this.m_EButton_DeleteImage = null;
			this.m_EButton_BeginButton = null;
			this.m_EButton_BeginImage = null;
			this.m_EInput_NameInputField = null;
			this.m_EInput_NameImage = null;
			this.m_ELabel_NameText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EGBackGroundRectTransform = null;
		private UnityEngine.UI.Image m_ELoopScrollList_RolesImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_RolesLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_CreateButton = null;
		private UnityEngine.UI.Image m_EButton_CreateImage = null;
		private UnityEngine.UI.Button m_EButton_DeleteButton = null;
		private UnityEngine.UI.Image m_EButton_DeleteImage = null;
		private UnityEngine.UI.Button m_EButton_BeginButton = null;
		private UnityEngine.UI.Image m_EButton_BeginImage = null;
		private UnityEngine.UI.InputField m_EInput_NameInputField = null;
		private UnityEngine.UI.Image m_EInput_NameImage = null;
		private UnityEngine.UI.Text m_ELabel_NameText = null;
		public Transform uiTransform = null;
	}
}
