﻿using System;

namespace ET
{
    public class G2M_RequestExitGameHandler : AMActorLocationRpcHandler<Unit, G2M_RequestExitGame, M2G_RequestExitGame>
    {
        protected override async ETTask Run(Unit unit, G2M_RequestExitGame request, M2G_RequestExitGame response, Action reply)
        {
            // TODO 保存玩家数据到数据库，执行相关下线操作
            unit.GetComponent<UnitDBSaveComponent>().SaveChange();
            reply();

            // 释放unit
            await unit.RemoveLocation();
            var unitComponent = unit.DomainScene().GetComponent<UnitComponent>();
            unitComponent.Remove(unit.Id);

            await ETTask.CompletedTask;
        }
    }
}
