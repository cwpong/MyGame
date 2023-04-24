
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESItemAwakeSystem : AwakeSystem<ESItem,Transform> 
	{
		public override void Awake(ESItem self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESItemDestroySystem : DestroySystem<ESItem> 
	{
		public override void Destroy(ESItem self)
		{
			self.DestroyWidget();
		}
	}
}
