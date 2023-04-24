
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgMainViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button EButton_RoleButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RoleButton == null )
     			{
		    		this.m_EButton_RoleButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Role");
     			}
     			return this.m_EButton_RoleButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_RoleImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RoleImage == null )
     			{
		    		this.m_EButton_RoleImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Role");
     			}
     			return this.m_EButton_RoleImage;
     		}
     	}

		public UnityEngine.RectTransform EButton_RoleRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RoleRectTransform == null )
     			{
		    		this.m_EButton_RoleRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Role");
     			}
     			return this.m_EButton_RoleRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_BagButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BagButton == null )
     			{
		    		this.m_EButton_BagButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Bag");
     			}
     			return this.m_EButton_BagButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_BagImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BagImage == null )
     			{
		    		this.m_EButton_BagImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Bag");
     			}
     			return this.m_EButton_BagImage;
     		}
     	}

		public UnityEngine.RectTransform EButton_BagRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_BagRectTransform == null )
     			{
		    		this.m_EButton_BagRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Bag");
     			}
     			return this.m_EButton_BagRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_MakeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_MakeButton == null )
     			{
		    		this.m_EButton_MakeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Make");
     			}
     			return this.m_EButton_MakeButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_MakeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_MakeImage == null )
     			{
		    		this.m_EButton_MakeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Make");
     			}
     			return this.m_EButton_MakeImage;
     		}
     	}

		public UnityEngine.RectTransform EButton_MakeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_MakeRectTransform == null )
     			{
		    		this.m_EButton_MakeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Make");
     			}
     			return this.m_EButton_MakeRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_TaskButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TaskButton == null )
     			{
		    		this.m_EButton_TaskButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Task");
     			}
     			return this.m_EButton_TaskButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_TaskImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TaskImage == null )
     			{
		    		this.m_EButton_TaskImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Task");
     			}
     			return this.m_EButton_TaskImage;
     		}
     	}

		public UnityEngine.RectTransform EButton_TaskRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_TaskRectTransform == null )
     			{
		    		this.m_EButton_TaskRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Task");
     			}
     			return this.m_EButton_TaskRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_RankButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RankButton == null )
     			{
		    		this.m_EButton_RankButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Rank");
     			}
     			return this.m_EButton_RankButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_RankImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RankImage == null )
     			{
		    		this.m_EButton_RankImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Rank");
     			}
     			return this.m_EButton_RankImage;
     		}
     	}

		public UnityEngine.RectTransform EButton_RankRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_RankRectTransform == null )
     			{
		    		this.m_EButton_RankRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Rank");
     			}
     			return this.m_EButton_RankRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EButton_ChatButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChatButton == null )
     			{
		    		this.m_EButton_ChatButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Chat");
     			}
     			return this.m_EButton_ChatButton;
     		}
     	}

		public UnityEngine.UI.Image EButton_ChatImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChatImage == null )
     			{
		    		this.m_EButton_ChatImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Chat");
     			}
     			return this.m_EButton_ChatImage;
     		}
     	}

		public UnityEngine.RectTransform EButton_ChatRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EButton_ChatRectTransform == null )
     			{
		    		this.m_EButton_ChatRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Sprite_BackGround/Botton/GameObject/EButton_Chat");
     			}
     			return this.m_EButton_ChatRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EBeginBattleBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBeginBattleBtnButton == null )
     			{
		    		this.m_EBeginBattleBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Sprite_BackGround/EBeginBattleBtn");
     			}
     			return this.m_EBeginBattleBtnButton;
     		}
     	}

		public UnityEngine.UI.Image EBeginBattleBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBeginBattleBtnImage == null )
     			{
		    		this.m_EBeginBattleBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Sprite_BackGround/EBeginBattleBtn");
     			}
     			return this.m_EBeginBattleBtnImage;
     		}
     	}

		public UnityEngine.RectTransform EBeginBattleBtnRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBeginBattleBtnRectTransform == null )
     			{
		    		this.m_EBeginBattleBtnRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Sprite_BackGround/EBeginBattleBtn");
     			}
     			return this.m_EBeginBattleBtnRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EButton_RoleButton = null;
			this.m_EButton_RoleImage = null;
			this.m_EButton_RoleRectTransform = null;
			this.m_EButton_BagButton = null;
			this.m_EButton_BagImage = null;
			this.m_EButton_BagRectTransform = null;
			this.m_EButton_MakeButton = null;
			this.m_EButton_MakeImage = null;
			this.m_EButton_MakeRectTransform = null;
			this.m_EButton_TaskButton = null;
			this.m_EButton_TaskImage = null;
			this.m_EButton_TaskRectTransform = null;
			this.m_EButton_RankButton = null;
			this.m_EButton_RankImage = null;
			this.m_EButton_RankRectTransform = null;
			this.m_EButton_ChatButton = null;
			this.m_EButton_ChatImage = null;
			this.m_EButton_ChatRectTransform = null;
			this.m_EBeginBattleBtnButton = null;
			this.m_EBeginBattleBtnImage = null;
			this.m_EBeginBattleBtnRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_EButton_RoleButton = null;
		private UnityEngine.UI.Image m_EButton_RoleImage = null;
		private UnityEngine.RectTransform m_EButton_RoleRectTransform = null;
		private UnityEngine.UI.Button m_EButton_BagButton = null;
		private UnityEngine.UI.Image m_EButton_BagImage = null;
		private UnityEngine.RectTransform m_EButton_BagRectTransform = null;
		private UnityEngine.UI.Button m_EButton_MakeButton = null;
		private UnityEngine.UI.Image m_EButton_MakeImage = null;
		private UnityEngine.RectTransform m_EButton_MakeRectTransform = null;
		private UnityEngine.UI.Button m_EButton_TaskButton = null;
		private UnityEngine.UI.Image m_EButton_TaskImage = null;
		private UnityEngine.RectTransform m_EButton_TaskRectTransform = null;
		private UnityEngine.UI.Button m_EButton_RankButton = null;
		private UnityEngine.UI.Image m_EButton_RankImage = null;
		private UnityEngine.RectTransform m_EButton_RankRectTransform = null;
		private UnityEngine.UI.Button m_EButton_ChatButton = null;
		private UnityEngine.UI.Image m_EButton_ChatImage = null;
		private UnityEngine.RectTransform m_EButton_ChatRectTransform = null;
		private UnityEngine.UI.Button m_EBeginBattleBtnButton = null;
		private UnityEngine.UI.Image m_EBeginBattleBtnImage = null;
		private UnityEngine.RectTransform m_EBeginBattleBtnRectTransform = null;
		public Transform uiTransform = null;
	}
}
