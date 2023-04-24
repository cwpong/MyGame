using UnityEngine;

namespace ET
{
    [FriendClass(typeof(Item))]
    public static class ItemViewHelper
    {
        public static Color GetBgColor(this Item self)
        {
            var quality = self.Quality;
            switch (quality)
            {
                case ItemQuality.Common:
                    return Color.gray;

                case ItemQuality.Fine:
                    return Color.green;

                case ItemQuality.Outstanding:
                    return Color.blue;

                case ItemQuality.Epic:
                    return Color.magenta;

                case ItemQuality.Legend:
                    return Color.red;

                default: 
                    return Color.white;
            }
        }
    }
}
