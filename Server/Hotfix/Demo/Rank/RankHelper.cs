﻿namespace ET
{
    [FriendClassAttribute(typeof(ET.RankInfo))]
    [FriendClassAttribute(typeof(ET.RoleInfo))]
    public static class RankHelper
    {
        // 用来通知某个类型的排行
        public static void AddOrUpdateLevelRank(Unit unit)
        {
            using (RankInfo rankInfo = unit.DomainScene().AddChild<RankInfo>())
            {
                rankInfo.UnitId = unit.Id;
                rankInfo.Name = unit.GetComponent<RoleInfo>().Str_Name;
                //rankInfo.Count = unit.GetComponent<NumericComponent>().GetAsInt(NumericType.Level);

                Map2Rank_AddOrUpdateRankInfo message = new Map2Rank_AddOrUpdateRankInfo();
                message.RankInfo = rankInfo;
                long instanceId = StartSceneConfigCategory.Instance.GetBySceneName(unit.DomainZone(), "Rank").InstanceId;
                MessageHelper.SendActor(instanceId, message);
            }
        }
    }
}