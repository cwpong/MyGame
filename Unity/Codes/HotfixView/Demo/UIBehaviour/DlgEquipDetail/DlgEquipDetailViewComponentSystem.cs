
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class DlgEquipDetailViewComponentAwakeSystem : AwakeSystem<DlgEquipDetailViewComponent> 
	{
		public override void Awake(DlgEquipDetailViewComponent self)
		{
			self.uiTransform = self.GetParent<UIBaseWindow>().uiTransform;
		}
	}


	[ObjectSystem]
	public class DlgEquipDetailViewComponentDestroySystem : DestroySystem<DlgEquipDetailViewComponent> 
	{
		public override void Destroy(DlgEquipDetailViewComponent self)
		{
			self.DestroyWidget();
		}
	}
}
