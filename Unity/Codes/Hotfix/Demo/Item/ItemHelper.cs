using System;

namespace ET
{
    public static class ItemHelper
    {
        public static void Clear(Scene ZoneScene, ItemOwner itemOwner)
        {
            if (itemOwner == ItemOwner.Bag)
            {
                ZoneScene?.GetComponent<BagComponent>()?.Clear();
            }
            else if (itemOwner == ItemOwner.Role)
            {
                ZoneScene?.GetComponent<EquipmentsComponent>()?.Clear();
            }
        }

        public static Item GetItem(Scene ZoneScene, long itemId, ItemOwner ItemOwner)
        {
            if (ItemOwner == ItemOwner.Bag)
            {
                return ZoneScene.GetComponent<BagComponent>().GetItemById(itemId);
            }
            else if (ItemOwner == ItemOwner.Role)
            {
                return ZoneScene.GetComponent<EquipmentsComponent>().GetItemById(itemId);
            }

            return null;
        }

        public static void AddItem(Scene ZoneScene, Item item, ItemOwner itemOwner)
        {
            if (itemOwner == ItemOwner.Bag)
            {
                ZoneScene.GetComponent<BagComponent>().AddItem(item);
            }
            else if (itemOwner == ItemOwner.Role)
            {
                ZoneScene.GetComponent<EquipmentsComponent>().AddEquipItem(item);
            }
        }

        public static void RemoveItemById(Scene ZoneScene, long itemId, ItemOwner ItemOwner)
        {
            Item item = GetItem(ZoneScene, itemId, ItemOwner);
            if (ItemOwner == ItemOwner.Bag)
            {
                ZoneScene.GetComponent<BagComponent>().RemoveItem(item);
            }
            else if (ItemOwner == ItemOwner.Role)
            {
                ZoneScene.GetComponent<EquipmentsComponent>().UnloadEquipItem(item);
            }
        }

        public static void RemoveItem(Scene ZoneScene, Item item, ItemOwner ItemOwner)
        {
            if (ItemOwner == ItemOwner.Bag)
            {
                ZoneScene.GetComponent<BagComponent>().RemoveItem(item);
            }
            else if (ItemOwner == ItemOwner.Role)
            {
                ZoneScene.GetComponent<EquipmentsComponent>().UnloadEquipItem(item);
            }
        }
    }
}