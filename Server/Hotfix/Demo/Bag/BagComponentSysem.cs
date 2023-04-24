
using System.Collections.Generic;

namespace ET
{
    public class BagComponentDestroySystem : DestroySystem<BagComponent>
    {
        public override void Destroy(BagComponent self)
        {
            foreach (var item in self.Rid2ItemDict.Values)
            {
                item?.Dispose();
            }
            self.Rid2ItemDict.Clear();
            self.Type2Items.Clear();
        }
    }

    public class BagComponentDeserializeSystem : DeserializeSystem<BagComponent>
    {
        public override void Deserialize(BagComponent self)
        {
            foreach (Entity entity in self.Children.Values)
            {
                // 将数据库中的Item取出
                self.AddContainer(entity as Item);
            }
        }
    }

    [FriendClass(typeof(Item))]
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
            //return self.Rid2ItemDict.Count == self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity];
        }

        public static bool AddContainer(this BagComponent self, Item item)
        {
            if (self.Rid2ItemDict.ContainsKey(item.Id))
            {
                return false;
            }

            self.Rid2ItemDict.Add(item.Id, item);
            self.Type2Items.Add(item.Config.Type, item);
            return true;
        }

        public static void RemoveContainer(this BagComponent self, Item item)
        {
            self.Rid2ItemDict.Remove(item.Id);
            self.Type2Items.Remove(item.Config.Type, item);
        }


        public static bool AddItemByConfigId(this BagComponent self, int configId, int count = 1)
        {
            if (!ItemConfigCategory.Instance.Contain(configId))
                return false;

            if (count <= 0)
                return false;

            for (int i = 0; i < count; i++)
            {
                Item newItem = ItemFactory.Create(self, configId);

                if (!self.AddItem(newItem))
                {
                    Log.Error("添加物品失败！");
                    newItem?.Dispose();
                    return false;
                }
            }

            return true;
        }

        public static void GetItemListByConfigId(this BagComponent self, int configID, List<Item> list)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(configID);
            foreach (Item goods in self.Type2Items[itemConfig.Type])
            {
                if (goods.CfgId == configID)
                {
                    list.Add(goods);
                }
            }
        }


        public static bool IsCanAddItem(this BagComponent self, Item item)
        {
            if (item == null || item.IsDisposed)
            {
                return false;
            }

            if (!ItemConfigCategory.Instance.Contain(item.CfgId))
            {
                return false;
            }

            if (self.IsMaxLoad())
            {
                return false;
            }

            if (self.Rid2ItemDict.ContainsKey(item.Id))
            {
                return false;
            }

            if (item.Parent == self)
            {
                return false;
            }
            return true;
        }


        public static bool IsCanAddItemByConfigId(this BagComponent self, int configID)
        {
            if (!ItemConfigCategory.Instance.Contain(configID))
            {
                return false;
            }

            if (self.IsMaxLoad())
            {
                return false;
            }

            return true;
        }

        public static bool IsCanAddItemList(this BagComponent self, List<Item> goodsList)
        {
            if (goodsList.Count <= 0)
            {
                return false;
            }

            //if (self.Rid2ItemDict.Count + goodsList.Count > self.GetParent<Unit>().GetComponent<NumericComponent>()[NumericType.MaxBagCapacity])
            //{
            //    return false;
            //}

            foreach (var item in goodsList)
            {
                if (item == null || item.IsDisposed)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool AddItemList(this BagComponent self, List<Item> itemsList)
        {
            if (itemsList.Count <= 0)
            {
                return true;
            }

            foreach (Item newItem in itemsList)
            {
                if (!self.AddItem(newItem))
                {
                    newItem?.Dispose();
                    return false;
                }
            }
            return true;
        }

        public static bool AddItem(this BagComponent self, Item item)
        {
            if (item == null || item.IsDisposed)
            {
                Log.Error("item is null!");
                return false;
            }

            if (self.IsMaxLoad())
            {
                Log.Error("bag is IsMaxLoad!");
                return false;
            }

            if (!self.AddContainer(item))
            {
                Log.Error("Add Container is Error!");
                return false;
            }

            if (item.Parent != self)
            {
                // 这样Item实体就能被存储了
                self.AddChild(item);
            }

            ItemUpdateNoticeHelper.SyncAddItem(self.GetParent<Unit>(), item, self.message);
            return true;
        }

        public static void RemoveItem(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            item.Dispose();
        }

        /// <summary>
        /// 不需要释放的
        /// </summary>
        /// <param name="self"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static Item RemoveItemNoDispose(this BagComponent self, Item item)
        {
            self.RemoveContainer(item);
            ItemUpdateNoticeHelper.SyncRemoveItem(self.GetParent<Unit>(), item, self.message);
            return item;
        }


        public static bool IsItemExist(this BagComponent self, long itemId)
        {
            self.Rid2ItemDict.TryGetValue(itemId, out Item item);
            return item != null && !item.IsDisposed;
        }


        public static Item GetItemById(this BagComponent self, long itemId)
        {
            self.Rid2ItemDict.TryGetValue(itemId, out Item item);
            return item;
        }

    }
}