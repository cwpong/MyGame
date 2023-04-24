namespace ET
{
    // 同步道具数据
    public class M2C_AllItemsListHandler : AMHandler<M2C_AllItemsList>
    {
        protected override void Run(Session session, M2C_AllItemsList message)
        {
            // 先清空
            ItemHelper.Clear(session.ZoneScene(), (ItemOwner)message.ItemOwner);

            for (int i = 0; i < message.ItemInfoList.Count; i++)
            {
                Item item = ItemFactory.Create(session.ZoneScene(), message.ItemInfoList[i]);
                ItemHelper.AddItem(session.ZoneScene(), item, (ItemOwner)message.ItemOwner);
            }
        }
    }
}