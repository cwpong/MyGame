using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    [FriendClass(typeof(RoleInfo))]
    public static class RoleInfoSystem
    {
        public static void FromMessage(this RoleInfo self, RoleInfoProto roleInfoProto)
        {
            self.Id = roleInfoProto.Id;
            self.Str_Name = roleInfoProto.Name;
            self.Int_State = roleInfoProto.State;
            self.Long_AccountId = roleInfoProto.AccountId;
            self.Long_CreateTime = roleInfoProto.CreateTime;
            self.Int_ServerId = roleInfoProto.SeverId;
            self.Long_LastLoginTime = roleInfoProto.LastLoginTime;
            self.Long_RoleId = roleInfoProto.RoleId;

            self.RoleLv = roleInfoProto.RoleLv;
            self.RoleExp = roleInfoProto.RoleExp;
            self.PhysicalAttack = roleInfoProto.PhysicalAttack;
            self.SpellAttack = roleInfoProto.SpellAttack;
            self.PhysicalDefense = roleInfoProto.PhysicalDefense;
            self.SpellDefense = roleInfoProto.SpellDefense;
            self.Speed = roleInfoProto.Speed;
            self.MaxHp = roleInfoProto.MaxHp;
        }

        public static RoleInfoProto ToMessage(this RoleInfo self)
        {
            return new RoleInfoProto
            {
                Id = self.Id,
                Name = self.Str_Name,
                State = self.Int_State,
                AccountId = self.Long_AccountId,
                CreateTime = self.Long_CreateTime,
                SeverId = self.Int_ServerId,
                LastLoginTime = self.Long_LastLoginTime,
                RoleId = self.Long_RoleId,
                RoleLv = self.RoleLv,
                RoleExp = self.RoleExp,
                PhysicalAttack = self.PhysicalAttack,
                SpellAttack = self.SpellAttack,
                PhysicalDefense = self.PhysicalDefense,
                SpellDefense = self.SpellDefense,
                Speed = self.Speed,
                MaxHp = self.MaxHp,
            };
        }
    }
}
