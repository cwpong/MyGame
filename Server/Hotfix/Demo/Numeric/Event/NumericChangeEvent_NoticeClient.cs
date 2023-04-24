using ET.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class NumericChangeEvent_NoticeClient : AEventClass<EventType.NumbericChange>
    {
        protected override void Run(object a)
        {
            var args = a as EventType.NumbericChange;
            if (!(args.Parent is Unit unit))
                return;

            //只允许通知玩家Unit
            if (unit.Type != UnitType.Player)
                return;

            unit.GetComponent<NumericNoticeComponent>()?.NoticeImmediately(args);
        }
    }
}
