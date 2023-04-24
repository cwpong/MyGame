namespace ET
{
    [FriendClass(typeof(Item))]
    public static class ItemHelper
    {
        public static void RandomQuality(this Item item)
        {
            int rate = RandomHelper.RandomNumber(0, 10000);
            if (rate < 4000)
            {
                item.Quality = ItemQuality.Common;
            }
            else if (rate < 7000)
            {
                item.Quality = ItemQuality.Fine;
            }
            else if (rate < 8500)
            {
                item.Quality = ItemQuality.Outstanding;
            }
            else if (rate < 9500)
            {
                item.Quality = ItemQuality.Epic;
            }
            else if (rate < 10000)
            {
                item.Quality = ItemQuality.Legend;
            }
        }
    }
}