
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class ESFighterItemAwakeSystem : AwakeSystem<ESFighterItem,Transform> 
	{
		public override void Awake(ESFighterItem self,Transform transform)
		{
			self.uiTransform = transform;
		}
	}


	[ObjectSystem]
	public class ESFighterItemDestroySystem : DestroySystem<ESFighterItem> 
	{
		public override void Destroy(ESFighterItem self)
		{
			self.DestroyWidget();
		}
	}
}
