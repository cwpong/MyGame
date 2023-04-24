using System;

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
        public static void FromMessage(this Item self, ItemInfo itemInfo)
        {
            self.Id = itemInfo.ItemUid;
            self.CfgId = itemInfo.ItemConfigId;
            self.Quality = (ItemQuality)itemInfo.ItemQuality;

            if (itemInfo.EquipInfo != null)
            {
                EquipInfoComponent equipInfoComponent = self.GetComponent<EquipInfoComponent>();

                if (equipInfoComponent == null)
                {
                    equipInfoComponent = self.AddComponent<EquipInfoComponent>();
                }
                equipInfoComponent.FromMessage(itemInfo.EquipInfo);
            }
        }

    }
}