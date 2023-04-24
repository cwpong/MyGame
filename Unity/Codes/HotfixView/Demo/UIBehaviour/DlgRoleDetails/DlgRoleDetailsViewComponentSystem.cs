
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgRoleDetailsViewComponentAwakeSystem : AwakeSystem<DlgRoleDetailsViewComponent> 
	{
		public override void Awake(DlgRoleDetailsViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgRoleDetailsViewComponentDestroySystem : DestroySystem<DlgRoleDetailsViewComponent> 
	{
		public override void Destroy(DlgRoleDetailsViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
