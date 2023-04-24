﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.Account.Handler
{
    [ActorMessageHandler]
    public class A2L_LoginAccountRequestHandler : AMActorRpcHandler<Scene, A2L_LoginAccountRequest, L2A_LoginAccountResponse>
    {
        protected override async ETTask Run(Scene scene, A2L_LoginAccountRequest request, L2A_LoginAccountResponse response, Action reply)
        {
            var accountId = request.AccountId;

            using (await CoroutineLockComponent.Instance.Wait(CoroutineLockType.LoginAccount, accountId.GetHashCode()))
            {
                if(!scene.GetComponent<LoginInfoRecordComponent>().IsExist(accountId))
                {
                    reply();
                    return;
                }
            }

            // 获取网关配置
            var zone = scene.GetComponent<LoginInfoRecordComponent>().Get(accountId);
            var gateConfig = RealmGateAddressHelper.GetGate(zone, accountId);

            // 踢在线玩家下线
            var g2LDisconnectGateUnit = (G2L_DisconnectGateUnit) await MessageHelper.CallActor(gateConfig.InstanceId, new L2G_DisconnectGateUnit() { AccountId = accountId });
            response.Error = g2LDisconnectGateUnit.Error;
            reply();
        }
    }
}
