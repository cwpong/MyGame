namespace ET
{
    public class FSMBattleStartCheck : IStateNode
    {
#pragma warning disable ET0004
        private StateMachine StateMachine;

        public void OnCreate(StateMachine machine)
        {
            StateMachine = machine;
        }

        public void OnEnter()
        {
            // 处理一些事
            var com = StateMachine.Owner as FSMComponent;
            if (com == null)
            {
                Log.Error($"节点FSMBattleStartCheck所属的FSMComponent 是空的");
                return;
            }

            var battleScene = com.Parent as BattleSceneComponent;
            if (battleScene == null)
            {
                // 这里是异常情况了, 虽然认为节点执行，但是还是要做一个异常处理，现在不知道怎么处理 先打个日志
                Log.Error($"没有BattleSceneComponent");
                return ;
            }

            // 有一方死亡了 则认为游戏结束
            (bool, BattleResult) result = BattleHelper.CheckBattleIsOver(battleScene);
            if (result.Item1)
            {
                Log.Warning($"游戏结束， 战斗结果:{result.Item2}");
                StateMachine = null;
            }
            else
            {
                com.GetMachine().ChangeState<FSMFighterTurn>();
            }
        }

        public void OnExit()
        {
            
        }

        public void OnUpdate()
        {
        }
    }
}
