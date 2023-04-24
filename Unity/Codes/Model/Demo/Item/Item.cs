using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
#if SERVER
    public class Item : Entity, IAwake<int>, IDestroy, ISerializeToEntity // 实现这个接口才能序列化到实体中
#else
    public class Item : Entity, IAwake<int>, IDestroy
#endif
    {
        /// <summary>
        /// 配置表ID
        /// </summary>
        public int CfgId = 0;

        /// <summary>
        /// 品质
        /// </summary>
        public ItemQuality Quality = 0;

#if SERVER
        // 配置信息不用存到数据库
        [BsonIgnore] 
#endif
        public ItemConfig Config => ItemConfigCategory.Instance.Get(CfgId);
    }
}
