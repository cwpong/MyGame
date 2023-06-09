﻿using Microsoft.CodeAnalysis.CSharp.Syntax;
using MongoDB.Driver.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET.Demo.Account
{
    [Timer(TimerType.PlayerOfflineOutTine)]
    public class PlayerOfflineOutTime : ATimer<PlayerOfflineOutTimeComponent>
    {
        public override void Run(PlayerOfflineOutTimeComponent self)
        {
            try
            {
                self.KickPlayer();
            }
            catch(Exception e)
            {
                Log.Error($"playerOffline timer error : {self.Id} + {e}");
            }
        }
    }

    [ObjectSystem]
    public class PlayerOfflineOutTimeComponentDestroySystem : DestroySystem<PlayerOfflineOutTimeComponent>
    {
        public override void Destroy(PlayerOfflineOutTimeComponent self)
        {
            TimerComponent.Instance.Remove(ref self.Timer);
        }
    }

    [ObjectSystem]
    public class PlayerOfflineOutTimeComponentAwakeSystem : AwakeSystem<PlayerOfflineOutTimeComponent>
    {
        public override void Awake(PlayerOfflineOutTimeComponent self)
        {
            self.Timer = TimerComponent.Instance.NewOnceTimer(TimeHelper.ServerNow() + 10000, TimerType.PlayerOfflineOutTine, self);
        }
    }

    public static class PlayerOfflineOutTimeComponentSystem
    {
        public static void KickPlayer(this PlayerOfflineOutTimeComponent self)
        {
            DisconnectHelper.KickPlayer(self.GetParent<Player>()).Coroutine();
        }
    }
}
