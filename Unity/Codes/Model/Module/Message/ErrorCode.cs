namespace ET
{
    public static partial class ErrorCode
    {
        public const int ERR_Success = 0;

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常

        public const int ERR_NetWorkError = 200002;    // 网络错误
        public const int ERR_LoginInfoError = 200003;   // 登陆信息错误
        public const int ERR_TokenError = 200004;   // Token错误
        public const int ERR_RoleNameIsNull = 200005;
        public const int ERR_RoleNameSame = 200006;
        public const int ERR_RequestRepeatedly = 200007; // 重复请求
        public const int ERR_RoleNotExist = 200008; // 角色不存在
        public const int ERR_RequestSceneTypeError = 200009;
        public const int ERR_ConnectGateKeyError = 200010;
        public const int ERR_OtherAccountLogin = 200011;
        public const int ERR_SessionPlayerError = 200012;
        public const int ERR_NonePayerError = 200013;
        public const int ERR_PlayerSessionError = 200014;
        public const int ERR_EnterGameError = 200015;
        public const int ERR_ItemNotExist = 200016;  // 道具不存在
        public const int ERR_AddBagItemError = 200017; // 装备失败
        public const int ERR_EquipItemError = 200018;
        public const int ERR_BagMaxLoad = 200019;
    }
}