
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[EnableMethod]
	public  class ESFighterItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EFightSpineRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EFightSpineRectTransform == null )
     			{
		    		this.m_EFightSpineRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EFightSpine");
     			}
     			return this.m_EFightSpineRectTransform;
     		}
     	}

        // EUI好像不支持这个
		//public Spine.SkeletonData EFightSpineSkeletonGraphic
  //   	{
  //   		get
  //   		{
  //   			if (this.uiTransform == null)
  //   			{
  //   				Log.Error("uiTransform is null.");
  //   				return null;
  //   			}
  //   			if( this.m_EFightSpineSkeletonGraphic == null )
  //   			{
		//    		this.m_EFightSpineSkeletonGraphic = UIFindHelper.FindDeepChild<Spine.Skeleton as Transform>(this.uiTransform.gameObject,"EFightSpine");
  //   			}
  //   			return this.m_EFightSpineSkeletonGraphic;
  //   		}
  //   	}

		public UnityEngine.UI.Slider EHpSliderSlider
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EHpSliderSlider == null )
     			{
		    		this.m_EHpSliderSlider = UIFindHelper.FindDeepChild<UnityEngine.UI.Slider>(this.uiTransform.gameObject,"EHpSlider");
     			}
     			return this.m_EHpSliderSlider;
     		}
     	}

		public UnityEngine.RectTransform EHpSliderRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EHpSliderRectTransform == null )
     			{
		    		this.m_EHpSliderRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EHpSlider");
     			}
     			return this.m_EHpSliderRectTransform;
     		}
     	}

		public UnityEngine.UI.Text EDamageTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EDamageTextText == null )
     			{
		    		this.m_EDamageTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EDamageText");
     			}
     			return this.m_EDamageTextText;
     		}
     	}

		public UnityEngine.RectTransform EDamageTextRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EDamageTextRectTransform == null )
     			{
		    		this.m_EDamageTextRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EDamageText");
     			}
     			return this.m_EDamageTextRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EFightSpineRectTransform = null;
			//this.m_EFightSpineSkeletonGraphic = null;
			this.m_EHpSliderSlider = null;
			this.m_EHpSliderRectTransform = null;
			this.m_EDamageTextText = null;
			this.m_EDamageTextRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EFightSpineRectTransform = null;
		//private Spine.SkeletonData m_EFightSpineSkeletonGraphic = null;
		private UnityEngine.UI.Slider m_EHpSliderSlider = null;
		private UnityEngine.RectTransform m_EHpSliderRectTransform = null;
		private UnityEngine.UI.Text m_EDamageTextText = null;
		private UnityEngine.RectTransform m_EDamageTextRectTransform = null;
		public Transform uiTransform = null;
	}
}
