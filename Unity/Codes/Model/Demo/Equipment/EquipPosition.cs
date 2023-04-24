namespace ET
{
    /// <summary>
    /// 装备装配部位
    /// </summary>
    public enum EquipPosition
    {
        None = 0,      //不可装备
        Keyboard = 1,  //键盘
        Mouse = 2,     //鼠标
        Headset = 3,   //耳机
        Cap =4,        //帽子
        Clothes = 5,   //衣服
        Pants = 6,     //裤子
        Shoes = 7,     //鞋子
    }

    /// <summary>
    /// 装备操作指令
    /// </summary>
    public enum EquipOp
    {
        Load,   //穿戴
        Unload, //卸下
    }


}