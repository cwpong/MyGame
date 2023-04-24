using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public enum RoleInfoState
    {
        Normal = 0,
        Freeze = 1,
    }

    [ComponentOf(typeof(Unit))]
#if SERVER
    public class RoleInfo : Entity, IAwake, ITransfer, IUnitCache
#else
    public class RoleInfo : Entity, IAwake
#endif
    {
        public string Str_Name;
        public int Int_ServerId;
        public int Int_State;
        public long Long_AccountId; // 所属账号ID
        public long Long_LastLoginTime;
        public long Long_CreateTime;
        public long Long_RoleId;  // 角色ID

        // 游戏内数据

        // 人物等级
        public int RoleLv;
        // 人物总经验
        public long RoleExp;

        // 属性相关
        public long PhysicalAttack;
        public long SpellAttack;
        public long PhysicalDefense;
        public long SpellDefense;
        public long Speed;
        public long MaxHp;
    }
}
