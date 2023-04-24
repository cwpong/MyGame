using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    /// <summary>
    /// 道具类型
    /// </summary>
    public enum ItemType
    {
        Equip = 0,          // 装备
        Consumables = 1,    // 消耗品
    }

    /// <summary>
    /// 道具操作指令
    /// </summary>
    public enum ItemOp
    {
        Add = 0,    // 增加
        Remove = 1, // 移除
    }

    /// <summary>
    /// 道具属主
    /// </summary>
    public enum ItemOwner
    {
        Role = 0,   // 主角，表示已装备
        Bag = 1,    // 背包
    }

    public enum ItemQuality
    {
        Common = 0,     // 普通
        Fine = 1,       // 精致
        Outstanding = 2,// 卓越
        Epic = 3,       // 史诗
        Legend = 4,     // 传奇
    }
}
