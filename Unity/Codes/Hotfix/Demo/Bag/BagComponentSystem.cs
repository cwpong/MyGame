namespace ET
{

    public class BagComponentDestorySystem : DestroySystem<BagComponent>
    {
        public override void Destroy(BagComponent self)
        {
            self.Clear();
        }
    }

    [FriendClass(typeof(BagComponent))]
    public static class BagComponentSystem
    {
        /// <summary>
        /// 是否达到最大负载
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsMaxLoad(this BagComponent self)
        {
            return false;
            //NumericComponent numericComponent = UnitHelper.GetMyUnitNumericComponent(self.ZoneScene().CurrentScene());
            //return self.Rid2ItemDict.Count == numericComponent[NumericType.MaxBagCapacity];
        }


        public static void Clear(this BagComponent self)
        {
            ForeachHelper.Foreach(self.Rid2ItemDict, (long id, Item item) =>
            {
                item?.Dispose();
            });
            self.Rid2ItemDict.Clear();
            self.Type2Items.Clear();
        }


        public static int GetItemCountByItemType(this BagComponent self, ItemType itemType)
        {
            if (!self.Type2Items.ContainsKey((int)itemType))
                return 0;

            return self.Type2Items[(int)itemType].Count;
        }


        public static void AddItem(this BagComponent self, Item item)
        {
            // 更改父节点
            self.AddChild(item);
            self.Rid2ItemDict.Add(item.Id, item);
            self.Type2Items.Add(item.Config.Type, item);
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            if (item == null)
            {
                Log.Error("bag item is null");
                return;
            }

            self.Rid2ItemDict.Remove(item.Id);
            self.Type2Items.Remove(item.Config.Type, item);
            item?.Dispose();
        }

        public static Item GetItemById(this BagComponent self, long itemId)
        {
            if (self.Rid2ItemDict.TryGetValue(itemId, out Item item))
            {
                return item;
            }
            return null;
        }
    }
}