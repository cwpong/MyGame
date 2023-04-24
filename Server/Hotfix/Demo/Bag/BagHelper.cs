namespace ET
{
    public static class BagHelper
    {
        /// <summary>
        /// 通过配置创建装备
        /// </summary>
        /// <returns></returns>
        public static bool AddItemByConfig(Unit unit, int config)
        {
            var bagComponent = unit.GetComponent<BagComponent>();
            if (bagComponent == null)
                return false;

            if (!bagComponent.IsCanAddItemByConfigId(config))
                return false;

            return bagComponent.AddItemByConfigId(config);
        }
    }
}
