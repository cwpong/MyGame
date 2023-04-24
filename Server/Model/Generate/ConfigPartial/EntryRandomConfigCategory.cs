using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public partial class EntryRandomConfigCategory
    {
        public List<EntryRandomConfig> entryRandomConfigs = new List<EntryRandomConfig>();

        public EntryRandomConfig GetRandomCfg()
        {
            if (entryRandomConfigs.Count == 0)
            {
                entryRandomConfigs.AddRange(this.dict.Values);
            }

            return RandomHelper.RandomArray(entryRandomConfigs);
        }
    }
}
