using System.Collections.Generic;


namespace ET
{
    public partial class ItemConfigCategory
    {
        private List<ItemConfig> equipItemList = new List<ItemConfig>();
        /// <summary>
        /// 随机生成一个装备Item配置
        /// </summary>
        /// <returns></returns>
        public ItemConfig GetRandomEquipItemCfg()
        {
            if (equipItemList.Count == 0)
            {
                foreach (var cfg in this.dict)
                {
                    if (cfg.Value.Type == (int)ItemType.Equip)
                    {
                        equipItemList.Add(cfg.Value);
                    }
                }
            }

            var random = RandomHelper.RandomArray(equipItemList);
            return random;
        }
    }
}
