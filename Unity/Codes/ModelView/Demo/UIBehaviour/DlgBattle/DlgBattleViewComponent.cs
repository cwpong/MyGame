
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ComponentOf(typeof(UIBaseWindow))]
	[EnableMethod]
	public  class DlgBattleViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EPlayerPos0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPlayerPos0RectTransform == null )
     			{
		    		this.m_EPlayerPos0RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/PlayerRoot/EPlayerPos0");
     			}
     			return this.m_EPlayerPos0RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EPlayerPos1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPlayerPos1RectTransform == null )
     			{
		    		this.m_EPlayerPos1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/PlayerRoot/EPlayerPos1");
     			}
     			return this.m_EPlayerPos1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EPlayerPos2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPlayerPos2RectTransform == null )
     			{
		    		this.m_EPlayerPos2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/PlayerRoot/EPlayerPos2");
     			}
     			return this.m_EPlayerPos2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EPlayerPos3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPlayerPos3RectTransform == null )
     			{
		    		this.m_EPlayerPos3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/PlayerRoot/EPlayerPos3");
     			}
     			return this.m_EPlayerPos3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EPlayerPos4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EPlayerPos4RectTransform == null )
     			{
		    		this.m_EPlayerPos4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/PlayerRoot/EPlayerPos4");
     			}
     			return this.m_EPlayerPos4RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EnemyRootRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EnemyRootRectTransform == null )
     			{
		    		this.m_EnemyRootRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/EnemyRoot");
     			}
     			return this.m_EnemyRootRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EEnemy0RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EEnemy0RectTransform == null )
     			{
		    		this.m_EEnemy0RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/EnemyRoot/EEnemy0");
     			}
     			return this.m_EEnemy0RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EEnemy1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EEnemy1RectTransform == null )
     			{
		    		this.m_EEnemy1RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/EnemyRoot/EEnemy1");
     			}
     			return this.m_EEnemy1RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EEnemy2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EEnemy2RectTransform == null )
     			{
		    		this.m_EEnemy2RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/EnemyRoot/EEnemy2");
     			}
     			return this.m_EEnemy2RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EEnemy3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EEnemy3RectTransform == null )
     			{
		    		this.m_EEnemy3RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/EnemyRoot/EEnemy3");
     			}
     			return this.m_EEnemy3RectTransform;
     		}
     	}

		public UnityEngine.RectTransform EEnemy4RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EEnemy4RectTransform == null )
     			{
		    		this.m_EEnemy4RectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/Role/EnemyRoot/EEnemy4");
     			}
     			return this.m_EEnemy4RectTransform;
     		}
     	}

		public UnityEngine.UI.Button EBtnBeginButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtnBeginButton == null )
     			{
		    		this.m_EBtnBeginButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Bg/EBtnBegin");
     			}
     			return this.m_EBtnBeginButton;
     		}
     	}

		public UnityEngine.UI.Image EBtnBeginImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtnBeginImage == null )
     			{
		    		this.m_EBtnBeginImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bg/EBtnBegin");
     			}
     			return this.m_EBtnBeginImage;
     		}
     	}

		public UnityEngine.RectTransform EBtnBeginRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtnBeginRectTransform == null )
     			{
		    		this.m_EBtnBeginRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/EBtnBegin");
     			}
     			return this.m_EBtnBeginRectTransform;
     		}
     	}

		public UnityEngine.UI.Button EBtnExitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtnExitButton == null )
     			{
		    		this.m_EBtnExitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Bg/EBtnExit");
     			}
     			return this.m_EBtnExitButton;
     		}
     	}

		public UnityEngine.UI.Image EBtnExitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtnExitImage == null )
     			{
		    		this.m_EBtnExitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Bg/EBtnExit");
     			}
     			return this.m_EBtnExitImage;
     		}
     	}

		public UnityEngine.RectTransform EBtnExitRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EBtnExitRectTransform == null )
     			{
		    		this.m_EBtnExitRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Bg/EBtnExit");
     			}
     			return this.m_EBtnExitRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EPlayerPos0RectTransform = null;
			this.m_EPlayerPos1RectTransform = null;
			this.m_EPlayerPos2RectTransform = null;
			this.m_EPlayerPos3RectTransform = null;
			this.m_EPlayerPos4RectTransform = null;
			this.m_EnemyRootRectTransform = null;
			this.m_EEnemy0RectTransform = null;
			this.m_EEnemy1RectTransform = null;
			this.m_EEnemy2RectTransform = null;
			this.m_EEnemy3RectTransform = null;
			this.m_EEnemy4RectTransform = null;
			this.m_EBtnBeginButton = null;
			this.m_EBtnBeginImage = null;
			this.m_EBtnBeginRectTransform = null;
			this.m_EBtnExitButton = null;
			this.m_EBtnExitImage = null;
			this.m_EBtnExitRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EPlayerPos0RectTransform = null;
		private UnityEngine.RectTransform m_EPlayerPos1RectTransform = null;
		private UnityEngine.RectTransform m_EPlayerPos2RectTransform = null;
		private UnityEngine.RectTransform m_EPlayerPos3RectTransform = null;
		private UnityEngine.RectTransform m_EPlayerPos4RectTransform = null;
		private UnityEngine.RectTransform m_EnemyRootRectTransform = null;
		private UnityEngine.RectTransform m_EEnemy0RectTransform = null;
		private UnityEngine.RectTransform m_EEnemy1RectTransform = null;
		private UnityEngine.RectTransform m_EEnemy2RectTransform = null;
		private UnityEngine.RectTransform m_EEnemy3RectTransform = null;
		private UnityEngine.RectTransform m_EEnemy4RectTransform = null;
		private UnityEngine.UI.Button m_EBtnBeginButton = null;
		private UnityEngine.UI.Image m_EBtnBeginImage = null;
		private UnityEngine.RectTransform m_EBtnBeginRectTransform = null;
		private UnityEngine.UI.Button m_EBtnExitButton = null;
		private UnityEngine.UI.Image m_EBtnExitImage = null;
		private UnityEngine.RectTransform m_EBtnExitRectTransform = null;
		public Transform uiTransform = null;
	}
}
