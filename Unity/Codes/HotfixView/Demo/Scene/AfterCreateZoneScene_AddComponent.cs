namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override  void Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<RedDotComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();

            // TODO �ȸ�
            zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Patch);
            //zoneScene.GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_Login);
        }
    }
}