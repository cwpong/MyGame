using System.Collections.Generic;

namespace ET
{
    public class BattleSceneComponentDestroySystem : DestroySystem<BattleSceneComponent>
    {
        public override void Destroy(BattleSceneComponent self)
        {
            foreach (var figher in self.DictFighters)
            {
                figher.Value.Dispose();
            }

            self.DictFighters.Clear();
        }
    }

    [FriendClass(typeof(BattleSceneComponent))]
    public static class BattleSceneComponentSystem
    {
        public static void FighterJoin(this BattleSceneComponent self, Unit fighter)
        {
            self.DictFighters[fighter.Id] = fighter;
        }

        public static Unit GetFighter(this BattleSceneComponent self, long id)
        {
            if (self.DictFighters.TryGetValue(id, out var fighter))
            {
                return fighter;
            }

            return null;
        }

        public static List<Unit> GetFightersByType(this BattleSceneComponent self, UnitType type)
        {
            var list = new List<Unit>();
            foreach (var fighter in self.DictFighters)
            {
                if (fighter.Value.Type == type)
                    list.Add(fighter.Value);
            }

            return list;
        }

        public static List<Unit> GetAllFighters(this BattleSceneComponent self)
        {
            var list = new List<Unit>();
            list.AddRange(self.DictFighters.Values);
            return list;
        }
    }
}
