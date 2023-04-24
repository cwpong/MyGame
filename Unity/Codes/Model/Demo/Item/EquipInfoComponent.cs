using System;
using System.Collections.Generic;
#if SERVER
using MongoDB.Bson.Serialization.Attributes;
#endif


namespace ET
{
    [ComponentOf(typeof(Item))]
    [ChildType(typeof(AttributeEntry))]
#if SERVER
    public class EquipInfoComponent : Entity,IAwake,IDestroy,ISerializeToEntity,IDeserialize // 也是为了将数据存储到数据库
#else
    public class EquipInfoComponent : Entity, IAwake, IDestroy
#endif
    {
        public bool IsInited = false;

        /// <summary>
        /// 装备评分
        /// </summary>
        public int Score = 0;

        /// <summary>
        /// 装备等级，还没做关卡系统 先随记吧
        /// </summary>
        public int Lv = 1;

        /// <summary>
        /// 装备词条列表
        /// </summary>
#if SERVER
        [BsonIgnore]
#endif
        public List<AttributeEntry> EntryList = new List<AttributeEntry>();
    }
}