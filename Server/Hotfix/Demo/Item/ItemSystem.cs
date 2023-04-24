namespace ET
{
    public class ItemAwakeSystem : AwakeSystem<Item, int>
    {
        public override void Awake(Item self, int configID)
        {
            self.CfgId = configID;
        }
    }


    public class ItemDestorySystem : DestroySystem<Item>
    {
        public override void Destroy(Item self)
        {
            self.Quality = 0;
            self.CfgId = 0;
        }
    }


    [FriendClass(typeof(Item))]
    public static class ItemSystem
    {
        public static ItemInfo ToMessage(this Item self, bool isAllInfo = true)
        {
            ItemInfo itemInfo = new ItemInfo();
            itemInfo.ItemUid = self.Id;
            itemInfo.ItemConfigId = self.CfgId;
            itemInfo.ItemQuality = (int)self.Quality;

            // 是否要将Item身上所有的组件信息传给客户端 默认是
            if (!isAllInfo)
                return itemInfo;

            EquipInfoComponent equipInfoComponent = self.GetComponent<EquipInfoComponent>();
            if (equipInfoComponent != null)
            {
                itemInfo.EquipInfo = equipInfoComponent.ToMessage();
            }

            return itemInfo;
        }

    }
}