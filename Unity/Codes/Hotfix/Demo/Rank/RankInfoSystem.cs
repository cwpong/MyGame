namespace ET
{

    public class RankInfoDestroySystem : DestroySystem<RankInfo>
    {
        public override void Destroy(RankInfo self)
        {
            self.UnitId = 0;
            self.Name = null;
            self.Lv = 0;
        }
    }

    [FriendClassAttribute(typeof(ET.RankInfo))]
    public static class RankInfoSystem
    {
        public static void FromMessage(this RankInfo self, RankInfoProto rankInfoProto)
        {
            self.Id = rankInfoProto.Id;
            self.UnitId = rankInfoProto.UnitId;
            self.Name = rankInfoProto.Name;
            self.Lv = rankInfoProto.Lv;
        }

        public static RankInfoProto ToMessage(this RankInfo self)
        {
            RankInfoProto rankInfoProto = new RankInfoProto();
            rankInfoProto.Id = self.Id;
            rankInfoProto.UnitId = self.UnitId;
            rankInfoProto.Name = self.Name;
            rankInfoProto.Lv = self.Lv;
            return rankInfoProto;
        }
    }
}