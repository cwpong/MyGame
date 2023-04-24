using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ET
{
    /// <summary>
    /// 战斗状态
    /// </summary>
    public enum BattleState
    {
        Idle,
        NextTurn,
        Action,
        WaitActionOver,
        GameOver
    }

    /// <summary>
    /// 战场
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class BattleSceneComponent : Entity, IAwake, IDestroy
    {
        public long owenrId = 0;
        public BattleState CurSate;
        public int CurRound;
        public MultiMap<UnitType, Unit> MultiMapFighters = new MultiMap<UnitType, Unit>(); // 存放着所有的战场对象

        public OneBattleRecord OneBattleRecord = new OneBattleRecord();
        public List<OneBattleRecord> BattleRecords = new List<OneBattleRecord>();
    }
}
