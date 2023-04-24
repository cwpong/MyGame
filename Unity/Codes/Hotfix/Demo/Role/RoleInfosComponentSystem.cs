using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    public class RoleInfosComponentDestroySystem : DestroySystem<RoleInfosComponent>
    {
        public override void Destroy(RoleInfosComponent self)
        {
            foreach (var roleInfo in self.List_RoleInfos)
            {
                roleInfo?.Dispose();
            }

            self.List_RoleInfos.Clear();
            self.CurrentRoleId = 0;
        }
    }

    public static class RoleInfosComponentSystem
    {
    }
}
