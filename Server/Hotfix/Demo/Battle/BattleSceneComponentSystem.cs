using MongoDB.Driver.Core.Events;
using System.Collections.Generic;

namespace ET
{
    public class BattleSceneComponentDestroySystem : DestroySystem<BattleSceneComponent>
    {
        public override void Destroy(BattleSceneComponent self)
        {
            //foreach (var fighter in self.Fighters)
            //    self.DomainScene().GetComponent<UnitComponent>().Remove(fighter);

            // TODO 这样清理不知道对不对
            foreach (var fighters in self.MultiMapFighters)
            {
                foreach (var fighter in fighters.Value)
                {
                    fighter.Dispose();
                }
            }

            self.MultiMapFighters.Clear();
            self.CurRound = 0;
            //self.Fighters.Clear();
            self.CurSate = BattleState.Idle;
            self.OneBattleRecord = null;
            self.BattleRecords.Clear();
        }
    }

    [FriendClass(typeof(BattleSceneComponent))]
    public static class BattleSceneComponentSystem
    {
        public static void FighterJoin(this BattleSceneComponent self, Unit unit)
        {
            self.MultiMapFighters.Add(unit.Type, unit);
        }

        public static int GetCurRound(this BattleSceneComponent self)
        {
            return self.CurRound;
        }

        /// <summary>
        /// 生成战报
        /// </summary>
        public static void GenerateBattleResult(this BattleSceneComponent self)
        {
            if(self.GetComponent<FSMComponent>() == null)
                self.AddComponent<FSMComponent>();

            self.GetComponent<FSMComponent>().GetMachine().AddNode<FSMBattleStartCheck>();
            self.GetComponent<FSMComponent>().GetMachine().AddNode<FSMFighterTurn>();
            self.GetComponent<FSMComponent>().GetMachine().Run<FSMBattleStartCheck>();
        }

        /// <summary>
        /// 因为目前我方只有一个，所以判断一个死亡就行
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool CheckPlayerAllDied(this BattleSceneComponent self)
        {
            bool allDie = true;
            if (self.MultiMapFighters.TryGetValue(UnitType.Player, out var players))
            {
                foreach (var player in players)
                {
                    var numericComponent = player.GetComponent<NumericComponent>();
                    if (numericComponent == null)
                    {
                        Log.Error($"ID = {player}的怪兽方身上没有数值组件");
                        return true;
                    }

                    if (numericComponent.GetAsInt(NumericType.IsAlive) == 1)
                    {
                        allDie = false;
                        break;
                    }
                }
            }

            return allDie;
        }

        public static bool CheckMonsterAllDied(this BattleSceneComponent self)
        {
            bool allDie = true;
            if (self.MultiMapFighters.TryGetValue(UnitType.Monster, out var monsters))
            {
                foreach (var monster in monsters)
                {
                    var numericComponent = monster.GetComponent<NumericComponent>();
                    if (numericComponent == null)
                    {
                        Log.Error($"ID = {monster}的怪兽方身上没有数值组件");
                        return true;
                    }

                    if (numericComponent.GetAsInt(NumericType.IsAlive) == 1)
                    {
                        allDie = false;
                        break;
                    }
                }
            }

            return allDie;
        }

        /// <summary>
        /// 获取所有存活的战场对象
        /// </summary>
        /// <returns></returns>
        public static List<Unit> GetAliveFighters(this BattleSceneComponent self)
        {
            var list = new List<Unit>();
            foreach (var fighters in self.MultiMapFighters)
            {
                foreach (var fighter in fighters.Value)
                {
                    var numericComponent = fighter.GetComponent<NumericComponent>();
                    if (numericComponent == null)
                    {
                        Log.Error($"ID = {fighter} 身上没有数值组件");
                        continue;
                    }

                    if (numericComponent.GetAsInt(NumericType.IsAlive) == 1)
                        list.Add(fighter);
                }
            }

            return list;
        }

        /// <summary>
        /// 是否都出手过了(这里是不是需要考虑初始时的状态)
        /// </summary>
        /// <returns></returns>
        public static bool IsAllActionOver(this BattleSceneComponent self)
        {
            bool isAllActionOver = true;
            var aliveFighters = self.GetAliveFighters();
            foreach (var fighter in aliveFighters)
            {
                var fighterComponent = fighter.GetComponent<FighterComponent>();
                if (fighterComponent == null)
                {
                    Log.Error($"ID = {fighter.Id}的战场对象没有数值组件");
                    continue;
                }

                if (!fighterComponent.HasAction())
                {
                    isAllActionOver = false;
                    break;
                }
            }

            return isAllActionOver;
        }

        /// <summary>
        /// 清空所有战场对象的状态
        /// </summary>
        /// <param name="self"></param>
        public static void StepNextRound(this BattleSceneComponent self)
        {
            self.CurRound++;
            var aliveFighters = self.GetAliveFighters();
            foreach (var fighter in aliveFighters)
            {
                var fighterComponent = fighter.GetComponent<FighterComponent>();
                if (fighterComponent == null)
                {
                    Log.Error($"ID = {fighter.Id}的战场对象没有数值组件");
                    continue;
                }

                fighterComponent.ResetAction();
            }
        }

        public static List<Unit> GetFightersByType(this BattleSceneComponent self, UnitType type)
        {
            if (self.MultiMapFighters.TryGetValue(type, out var fighters))
            {
                return fighters;
            }

            return null;
        }

        public static void InserBattleRecord(this BattleSceneComponent self, OneBattleRecord record)
        {
            self.BattleRecords.Add(record);
        }

        public static List<OneBattleRecord> GetBattleRecord(this BattleSceneComponent self)
        {
            return self.BattleRecords;
        }

        /// <summary>
        /// 当前的一条技能，换人出手时要清空
        /// </summary>
        /// <returns></returns>
        public static OneBattleRecord GetCurBattleRecord(this BattleSceneComponent self)
        {
            return self.OneBattleRecord;
        }

        /// <summary>
        /// 重置回合记录
        /// </summary>
        /// <param name="self"></param>
        /// TODO 写个重置的方法
        public static void ResetCurBattleRecord(this BattleSceneComponent self)
        {
            self.OneBattleRecord = new OneBattleRecord();
        }
    }
}
