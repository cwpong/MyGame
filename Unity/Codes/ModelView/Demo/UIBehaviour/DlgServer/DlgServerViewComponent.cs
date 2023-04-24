
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgServerViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.LoopVerticalScrollRect ELoopScrollList_ServerLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_ELoopScrollList_ServerLoopVerticalScrollRect == null )
     			{
		    		this.m_ELoopScrollList_ServerLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Sprite_BackGround/Image/ELoopScrollList_Server");
     			}
     			return this.m_ELoopScrollList_ServerLoopVerticalScrollRect;
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
		    		this.m_EButton_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_Confirm");
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
		    		this.m_EButton_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EButton_Confirm");
     			}
     			return this.m_EButton_ConfirmImage;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_ELoopScrollList_ServerLoopVerticalScrollRect = null;
			this.m_EButton_ConfirmButton = null;
			this.m_EButton_ConfirmImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_ELoopScrollList_ServerLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_EButton_ConfirmButton = null;
		private UnityEngine.UI.Image m_EButton_ConfirmImage = null;
		public Transform uiTransform = null;
	}
}
