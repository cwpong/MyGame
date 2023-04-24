using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using ProtoBuf;

namespace ET
{
    [ProtoContract]
    [Config]
    public partial class SkillConfigCategory : ProtoObject, IMerge
    {
        public static SkillConfigCategory Instance;
		
        [ProtoIgnore]
        [BsonIgnore]
        private Dictionary<int, SkillConfig> dict = new Dictionary<int, SkillConfig>();
		
        [BsonElement]
        [ProtoMember(1)]
        private List<SkillConfig> list = new List<SkillConfig>();
		
        public SkillConfigCategory()
        {
            Instance = this;
        }
        
        public void Merge(object o)
        {
            SkillConfigCategory s = o as SkillConfigCategory;
            this.list.AddRange(s.list);
        }
		
        public override void EndInit()
        {
            foreach (SkillConfig config in list)
            {
                config.EndInit();
                this.dict.Add(config.Id, config);
            }            
            this.AfterEndInit();
        }
		
        public SkillConfig Get(int id)
        {
            this.dict.TryGetValue(id, out SkillConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (SkillConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, SkillConfig> GetAll()
        {
            return this.dict;
        }

        public SkillConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

    [ProtoContract]
	public partial class SkillConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		[ProtoMember(1)]
		public int Id { get; set; }
		/// <summary>技能目标个数</summary>
		[ProtoMember(4)]
		public int TargetRange { get; set; }
		/// <summary>目标对象</summary>
		[ProtoMember(5)]
		public int TargetObject { get; set; }
		/// <summary>添加的buff类型</summary>
		[ProtoMember(6)]
		public int[] AddBuffs { get; set; }
		/// <summary>buff生效回合</summary>
		[ProtoMember(7)]
		public int[] BuffsBegindRound { get; set; }
		/// <summary>添加的状态类型</summary>
		[ProtoMember(8)]
		public int[] AddStates { get; set; }
		/// <summary>影响技能的数值类型</summary>
		[ProtoMember(9)]
		public int SkillType { get; set; }
		/// <summary>物攻倍率</summary>
		[ProtoMember(10)]
		public int PhysicalAttackRate { get; set; }
		/// <summary>法攻倍率</summary>
		[ProtoMember(11)]
		public int SpellAttackRate { get; set; }
		/// <summary>物防倍率</summary>
		[ProtoMember(12)]
		public int PhysicalDefenseRate { get; set; }
		/// <summary>法防倍率</summary>
		[ProtoMember(13)]
		public int SpellDefenseRate { get; set; }
		/// <summary>速度倍率</summary>
		[ProtoMember(14)]
		public int SpeedRate { get; set; }
		/// <summary>气血倍率</summary>
		[ProtoMember(15)]
		public int MaxHpRate { get; set; }

	}
}
