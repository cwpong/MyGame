
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_ItemDestroySystem : DestroySystem<Scroll_Item_Item> 
	{
		public override void Destroy( Scroll_Item_Item self )
		{
			self.DestroyWidget();
		}
	}
}
