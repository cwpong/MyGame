using System.Collections.Generic;
using System.Threading;
using System.Timers;

namespace ET
{
	 [ComponentOf(typeof(UIBaseWindow))]
	public  class DlgRank :Entity,IAwake,IUILogic
	{

		public DlgRankViewComponent View { get => this.Parent.GetComponent<DlgRankViewComponent>();}
		public Dictionary<int, Scroll_Item_Rank> ScrollItemRanks = new Dictionary<int, Scroll_Item_Rank>();
        public long Timer = 0;
    }
}
