namespace ET
{
	// 这个可弄个配置表生成 设置的话是从第二条后开始设置
    public static class NumericType
    {
	    public const int Max = 10000;

	    public const int Hp = 1001;
	    public const int HpBase = Hp * 10 + 1;

		// 物理攻击
		public const int PhysicalAttack = 1000;
        public const int PhysicalAttackBase = PhysicalAttack * 10 + 1;
        public const int PhysicalAttackAdd = PhysicalAttack * 10 + 2;
        public const int PhysicalAttackPct = PhysicalAttack * 10 + 3;
        public const int PhysicalAttackFinalAdd = PhysicalAttack * 10 + 4;
        public const int PhysicalAttackFinalPct = PhysicalAttack * 10 + 5;

		// 法术攻击
		public const int SpellAttack = 1001;
        public const int SpellAttackBase = SpellAttack * 10 + 1;
        public const int SpellAttackAdd = SpellAttack * 10 + 2;
        public const int SpellAttackPct = SpellAttack * 10 + 3;
        public const int SpellAttackFinalAdd = SpellAttack * 10 + 4;
        public const int SpellAttackFinalPct = SpellAttack * 10 + 5;

		// 物理防御
		public const int PhysicalDefense = 1002;
        public const int PhysicalDefenseBase = PhysicalDefense * 10 + 1;
        public const int PhysicalDefenseAdd = PhysicalDefense * 10 + 2;
        public const int PhysicalDefensePct = PhysicalDefense * 10 + 3;
        public const int PhysicalDefenseFinalAdd = PhysicalDefense * 10 + 4;
        public const int PhysicalDefenseFinalPct = PhysicalDefense * 10 + 5;

		// 法术防御
		public const int SpellDefense = 1003;
        public const int SpellDefenseBase = SpellDefense * 10 + 1;
        public const int SpellDefenseAdd = SpellDefense * 10 + 2;
        public const int SpellDefensPct = SpellDefense * 10 + 3;
        public const int SpellDefenseFinalAdd = SpellDefense * 10 + 4;
        public const int SpellDefenseFinalPct = SpellDefense * 10 + 5;

        // 速度
        public const int Speed = 1004;
        public const int SpeedBase = Speed * 10 + 1;
        public const int SpeedAdd = Speed * 10 + 2;
        public const int SpeedPct = Speed * 10 + 3;
        public const int SpeedFinalAdd = Speed * 10 + 4;
        public const int SpeedFinalPct = Speed * 10 + 5;

        // 气血
        public const int MaxHp = 1005;
        public const int MaxHpBase = MaxHp * 10 + 1;
        public const int MaxHpAdd = MaxHp * 10 + 2;
        public const int MaxHpPct = MaxHp * 10 + 3;
        public const int MaxHpFinalAdd = MaxHp * 10 + 4;
        public const int MaxHpFinalPct = MaxHp * 10 + 5;

        // 人物身上的一些数据
        public const int RoleLv = 3001;

        // ------------------------------- 战场相关
        public const int IsAlive = 5001;    // 是否存活 0 否 1 是

        // 战场属性数据 不会作为玩家属性，战斗时从玩家身上的数据拷贝过来就行, 后面考虑用其他方式吧这样感觉也不太合理
        // 物理攻击
        public const int BattlePhysicalAttack = 4000;
        public const int BattlePhysicalAttackBase = BattlePhysicalAttack * 10 + 1;
        public const int BattlePhysicalAttackAdd = BattlePhysicalAttack * 10 + 2;
        public const int BattlePhysicalAttackPct = BattlePhysicalAttack * 10 + 3;
        public const int BattlePhysicalAttackFinalAdd = BattlePhysicalAttack * 10 + 4;
        public const int BattlePhysicalAttackFinalPct = BattlePhysicalAttack * 10 + 5;

        // 法术攻击
        public const int BattleSpellAttack = 4001;
        public const int BattleSpellAttackBase = BattleSpellAttack * 10 + 1;
        public const int BattleSpellAttackAdd = BattleSpellAttack * 10 + 2;
        public const int BattleSpellAttackPct = BattleSpellAttack * 10 + 3;
        public const int BattleSpellAttackFinalAdd = BattleSpellAttack * 10 + 4;
        public const int BattleSpellAttackFinalPct = BattleSpellAttack * 10 + 5;

        // 物理防御
        public const int BattlePhysicalDefense = 4002;
        public const int BattlePhysicalDefenseBase = BattlePhysicalDefense * 10 + 1;
        public const int BattlePhysicalDefenseAdd = BattlePhysicalDefense * 10 + 2;
        public const int BattlePhysicalDefensePct = BattlePhysicalDefense * 10 + 3;
        public const int BattlePhysicalDefenseFinalAdd = BattlePhysicalDefense * 10 + 4;
        public const int BattlePhysicalDefenseFinalPct = BattlePhysicalDefense * 10 + 5;

        // 法术防御
        public const int BattleSpellDefense = 4003;
        public const int BattleSpellDefenseBase = BattleSpellDefense * 10 + 1;
        public const int BattleSpellDefenseAdd = BattleSpellDefense * 10 + 2;
        public const int BattleSpellDefensPct = BattleSpellDefense * 10 + 3;
        public const int BattleSpellDefenseFinalAdd = BattleSpellDefense * 10 + 4;
        public const int BattleSpellDefenseFinalPct = BattleSpellDefense * 10 + 5;

        // 速度
        public const int BattleSpeed = 4004;
        public const int BattleSpeedBase = BattleSpeed * 10 + 1;
        public const int BattleSpeedAdd = BattleSpeed * 10 + 2;
        public const int BattleSpeedPct = BattleSpeed * 10 + 3;
        public const int BattleSpeedFinalAdd = BattleSpeed * 10 + 4;
        public const int BattleSpeedFinalPct = BattleSpeed * 10 + 5;

        // 气血
        public const int BattleMaxHp = 4005;
        public const int BattleMaxHpBase = BattleMaxHp * 10 + 1;
        public const int BattleMaxHpAdd = BattleMaxHp * 10 + 2;
        public const int BattleMaxHpPct = BattleMaxHp * 10 + 3;
        public const int BattleMaxHpFinalAdd = BattleMaxHp * 10 + 4;
        public const int BattleMaxHpFinalPct = BattleMaxHp * 10 + 5;

    }
}
