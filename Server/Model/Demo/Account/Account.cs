/// 账号数据

namespace ET
{
    public enum AccountType
    {
        General = 0,

        BlackList = 1, // 黑名单
    }

    public class Account : Entity, IAwake
    {
        public string Str_AccountName { get; set; }  // 账户名

        public string Str_Password { get; set; } // 账户密码

        public long Long_CreateTime { get; set; }    // 账户创建时间

        public int Int_AccountType { get; set; } // 账户类型
    }
}
