namespace ET
{
    public class RankInfo : Entity, IAwake, IDestroy
    {
        public long UnitId; // 对应RoleId
        public string Name;
        public int Lv;
    }
}