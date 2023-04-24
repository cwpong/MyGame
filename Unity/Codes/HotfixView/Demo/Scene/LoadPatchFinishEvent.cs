using ET.EventType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Codes.HotfixView.Demo.Scene
{
    public class LoadPatchFinishEvent : AEvent<EventType.LoadPatchFinish>
    {
        protected override void Run(EventType.LoadPatchFinish arg)
        {
            var zoneScene = arg.ZoneScene;
            zoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Patch);
            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);
        }
    }
}
