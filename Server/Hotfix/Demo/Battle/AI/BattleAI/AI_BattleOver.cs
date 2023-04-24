//namespace ET.Demo.Battle.AI.BattleAI
//{
//    [FriendClass(typeof(AIComponent))]
//    public class AI_BattleOver : AAIHandler
//    {
//        public override int Check(AIComponent aiComponent, AIConfig aiConfig)
//        {
//            var battleScene = aiComponent.Parent as BattleSceneComponent;
//            if (battleScene == null)
//            {
//                // 这里是异常情况了, 虽然认为节点执行，但是还是要做一个异常处理，现在不知道怎么处理 先打个日志
//                Log.Error("战场不存在了");
//                return 0;
//            }

//            if (battleScene.GetCurState() == BattleState.Idle)
//            {
//                Log.Warning($"开始行动 当前回合是{battleScene.GetCurRound()}");
//                return 0;
//            }

//            // 有一方死亡了 则认为游戏结束
//            if (battleScene.CheckPlayerAllDied() || battleScene.CheckMonsterAllDied())
//            {
//                if (battleScene.CheckPlayerAllDied())
//                    Log.Warning($"我方阵营全部死亡 游戏结束");
//                else
//                    Log.Warning($"敌方阵营全部死亡 游戏结束");

//                TimerComponent.Instance.Remove(ref aiComponent.Timer);
//                return 0;
//            }

//            return 1;
//        }

//        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
//        {
//            (aiComponent.Parent as BattleSceneComponent).SetCurState(BattleState.Action);
//            await ETTask.CompletedTask;
//        }
//    }
//}
