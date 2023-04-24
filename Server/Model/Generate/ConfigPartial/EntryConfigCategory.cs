using System.Collections.Generic;

namespace ET
{
    public partial class EntryConfigCategory
    {
        private Dictionary<int, MultiMap<int, EntryConfig>> EntryConfigsDict = new Dictionary<int, MultiMap<int, EntryConfig>>();
        private List<EntryConfig> entryConfigs = new List<EntryConfig>();

        public EntryConfig GetRandomEntryConfigByLevel(int entryType, int level)
        {
            if (!this.EntryConfigsDict.ContainsKey(entryType))
            {
                return null;
            }

            MultiMap<int, EntryConfig> entryConfigsMap = this.EntryConfigsDict[entryType];
            if (!entryConfigsMap.ContainsKey(level))
            {
                return null;
            }

            var configList = entryConfigsMap[level];
            int index = RandomHelper.RandomNumber(0, configList.Count);
            return configList[index];
        }

        public EntryConfig GetRandomCfg()
        {
            if (entryConfigs.Count == 0)
            {
                entryConfigs.AddRange(this.dict.Values);
            }

            return RandomHelper.RandomArray(entryConfigs);
        }
    }
}