
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgPatchViewComponentAwakeSystem : AwakeSystem<DlgPatchViewComponent> 
	{
		public override void Awake(DlgPatchViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgPatchViewComponentDestroySystem : DestroySystem<DlgPatchViewComponent> 
	{
		public override void Destroy(DlgPatchViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
