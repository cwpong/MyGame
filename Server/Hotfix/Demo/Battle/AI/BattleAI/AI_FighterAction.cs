//using NLog.Filters;

//namespace ET.Demo.Battle.AI.BattleAI
//{
//    [FriendClass(typeof(BattleSceneComponent))]
//    internal class AI_FighterAction : AAIHandler
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

//            if (battleScene.IsAllActionOver())
//            {
//                Log.Warning("全部出手完毕 新的回合开始");
//                battleScene.StepNextRound();
//                battleScene.SetCurState(BattleState.NextTurn);
//                // 重置状态
//                return 0;
//            }
//            else if (battleScene.GetCurState() == BattleState.Action)
//            {
//                //Log.Warning("可以使用技能");
//                return 0;
//            }
//            else if (battleScene.GetCurState() == BattleState.WaitActionOver)
//            {
//                //Log.Warning("有战场对象在使用技能 等待使用完毕");
//                return 1;
//            }
            
//            return 0;
//        }

//        public override async ETTask Execute(AIComponent aiComponent, AIConfig aiConfig, ETCancellationToken cancellationToken)
//        {
//            var battleScene = aiComponent.Parent as BattleSceneComponent;
//            if (battleScene == null)
//            {
//                // 这里是异常情况了, 虽然认为节点执行，但是还是要做一个异常处理，现在不知道怎么处理 先打个日志
//                Log.Error("战场不存在了");
//                return;
//            }

//            if (!battleScene.IsAllActionOver())
//            {
//                var aliveFighters = battleScene.GetAliveFighters();

//                // 这里状态已经变了
//                for (int i = 0; i < aliveFighters.Count; ++i)
//                {
//                    var fighter = aliveFighters[i];
//                    if (!fighter.GetComponent<FighterComponent>().HasAction())
//                    {
//                        battleScene.SetCurState(BattleState.Idle);
//                        battleScene.ResetCurBattleRecord();
//                        // 换人出手 清空一下战场的记录
//                        fighter.GetComponent<FighterComponent>().DoAction(null) ;
//                        break;
//                    }
//                }

//                battleScene.SetCurState(BattleState.WaitActionOver);
//                await ETTask.CompletedTask;
//            }
//        }
//    }
//}
