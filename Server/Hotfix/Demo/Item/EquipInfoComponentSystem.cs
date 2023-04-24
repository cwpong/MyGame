using System.Collections.Generic;

namespace ET
{
    public class EquipInfoComponentAwakeSystem : AwakeSystem<EquipInfoComponent>
    {
        public override void Awake(EquipInfoComponent self)
        {
            self.GenerateEntries();
        }
    }

    public class EquipInfoComponentDestorySystem : DestroySystem<EquipInfoComponent>
    {
        public override void Destroy(EquipInfoComponent self)
        {
            self.IsInited = false;
            self.Score = 0;
            self.Lv = 0;

            foreach (var entry in self.EntryList)
            {
                entry?.Dispose();
            }
            self.EntryList.Clear();
        }
    }

    public class EquipInfoComponentDeserializeSystem : DeserializeSystem<EquipInfoComponent>
    {
        public override void Deserialize(EquipInfoComponent self)
        {
            foreach (var entity in self.Children.Values)
            {
                self.EntryList.Add(entity as AttributeEntry);
            }
        }
    }


    [FriendClass(typeof(Item))]
    [FriendClass(typeof(AttributeEntry))]
    [FriendClass(typeof(EquipInfoComponent))]
    public static class EquipInfoComponentSystem
    {
        // 生成词条
        public static void GenerateEntries(this EquipInfoComponent self)
        {
            if (self.IsInited)
            {
                return;
            }

            // 装备等级先在这里随机生成 后面再调整
            var lv = RandomHelper.RandomArray(new List<int>() { 1, 10, 20, 30, 40, 50, 60 });
            self.Lv = lv;
            self.IsInited = true;
            self.CreateEntry();
        }

        public static void CreateEntry(this EquipInfoComponent self)
        {
            ItemConfig itemConfig = self.GetParent<Item>().Config;

            EntryRandomConfig entryRandomConfig = EntryRandomConfigCategory.Instance.Get(itemConfig.EntryRandomId);

            // 创建普通词条
            // 词条属性 -> 品质 + 装备等级 / 10 + 1
            int entryCount = RandomHelper.RandomNumber((int)self.GetParent<Item>().Quality, self.Lv / 10 + 1);
            // 在词条库里随机取entryCount条词条
            var entryTypeCount = EntryConfigCategory.Instance.GetAll().Count;
            for (int i = 0; i < entryCount; i++)
            {
                var attrType = EntryConfigCategory.Instance.GetRandomCfg();
                if (attrType == null)
                {
                    Log.Error($"找不到属性类型{attrType}");
                    continue;
                }
                AttributeEntry attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.Type = EntryType.Common;
                attributeEntry.Key = attrType.AttributeType;

                // 数值 = 最低（最高）范围 * (装备等级 / 10 + 1 + 装备品质)
                attributeEntry.Value = RandomHelper.RandomNumber(attrType.AttributeMinValue * (self.Lv / 10 + 1 + (int)self.GetParent<Item>().Quality), attrType.AttributeMaxValue * (self.Lv / 10 + 1 + (int)self.GetParent<Item>().Quality));
                self.EntryList.Add(attributeEntry);
                // TODO 评分系统先不加
                //self.Score += entryConfig.EntryScore;
            }

            // TODO 现在只有普通的属性词条
            /*
            //创建特殊词条
            entryCount = RandomHelper.RandomNumber(entryRandomConfig.SpecialEntryRandMinCount, entryRandomConfig.SpecialEntryRandMaxCount);
            for (int i = 0; i < entryCount; i++)
            {
                EntryConfig entryConfig = EntryConfigCategory.Instance.GetRandomEntryConfigByLevel((int)EntryType.Special, entryRandomConfig.SpecialEntryLevel);
                if (entryConfig == null)
                    continue;

                // 这样才会被存进数据库
                AttributeEntry attributeEntry = self.AddChild<AttributeEntry>();
                attributeEntry.Type = EntryType.Special;
                attributeEntry.Key = entryConfig.AttributeType;
                attributeEntry.Value = RandomHelper.RandomNumber(entryConfig.AttributeMinValue, entryConfig.AttributeMaxValue);
                self.EntryList.Add(attributeEntry);
                //self.Score += entryConfig.EntryScore;
            }
            */
        }


        public static EquipInfoProto ToMessage(this EquipInfoComponent self)
        {
            EquipInfoProto equipInfoProto = new EquipInfoProto();
            equipInfoProto.Id = self.Id;
            equipInfoProto.Score = self.Score;
            for (int i = 0; i < self.EntryList.Count; i++)
            {
                equipInfoProto.AttributeEntryProtoList.Add(self.EntryList[i].ToMessage());
            }
            return equipInfoProto;
        }
    }
}