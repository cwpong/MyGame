using ET;
using System;
using System.Collections.Generic;
using UnityEngine.Pool;

namespace Global
{
    public class Round
    {
        public class Unit
        {
            public uint Uid { get; set; }
            public int Speed { get; set; }
            public int Progress { get; set; }
            public bool Defeated { get; set; } = false;
        }

        public int Distance { get; private set; }
        public float RoundTime { get; set; } = 1;

        private const int ValidBit = 1000;
        private Dictionary<uint, Unit> m_Units = new Dictionary<uint, Unit>();
        private int SpeedScale = 1;

        public void Clear()
        {
            m_Units.Clear();
            Distance = 0;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Init(List<Unit> units, int maxOriginalSpeed)
        {
            SpeedScale = CalcSpeedScale(maxOriginalSpeed);

            // TODO:m_Units报了重复Key的错误
            if (m_Units.Count > 0)
            {
                Clear();
                Log.Error("m_Units重复Key错误:初始化之前没有清空");
            }

            foreach (var unit in units)
            {
                unit.Speed = Math.Max(unit.Speed / SpeedScale, 1);

                // TODO:m_Units报了重复Key的错误
                if (m_Units.ContainsKey(unit.Uid))
                {
                    Log.Error("m_Units重复Key错误:传进来的参数有重复Key");
                }

                m_Units.Add(unit.Uid, unit);
            }

            Distance = 0;
            foreach (var unit in units)
            {
                // 使用速度最快的单位作为进度距离
                if (unit.Speed > Distance)
                    Distance = unit.Speed;
            }

            // 扩充有效位
            Distance *= ValidBit;
            Distance = System.Math.Max(Distance, 1);
        }

        public void InitProgress()
        {
            var units = new List<Unit>(m_Units.Values);

            var cnt = units.Count;
            for (var i = 0; i < cnt; ++i)
            {
                var unit = units[i];

                // 计算初始进度
                unit.Progress = unit.Speed * ValidBit;
            }
        }

        public void AddUnit(Unit unit)
        {
            unit.Speed = Math.Max(unit.Speed / SpeedScale, 1);
            m_Units.Add(unit.Uid, unit);
        }

        public void RemUnit(uint uid)
        {
            m_Units.Remove(uid);
        }

        /// <summary>
        /// 步进到下一回合
        /// </summary>
        public void StepNextRound()
        {
            var minTime = int.MaxValue;
            foreach (var kv in m_Units)
            {
                var unit = kv.Value;
                if (unit.Defeated)
                    continue;

                // 剩余路程时间
                var t = (Distance - unit.Progress) / unit.Speed;

                if (t < minTime)
                    minTime = t;
            }

            var max = 0;
            // TODO 回收机制
            var endUnits = new List<Unit>();
            foreach (var kv in m_Units)
            {
                var unit = kv.Value;
                if (unit.Defeated)
                    continue;

                // 由于精度丢失，再通过时间计算进度
                unit.Progress += unit.Speed * minTime;
                if (unit.Progress > max)
                {
                    // 更新进度最高单位
                    endUnits.Clear();
                    max = unit.Progress;
                    endUnits.Add(unit);
                }
                else if (unit.Progress == max)
                {
                    // 记录进度相同单位
                    endUnits.Add(unit);
                }
            }

            // 调整进度最高单位到满值
            foreach (var unit in endUnits)
                unit.Progress = Distance;

            //ListPool<Unit>.Release(endUnits);
        }

        /// <summary>
        /// 获取所有单位
        /// </summary>
        public void Dump(List<Unit> units)
        {
            units.AddRange(m_Units.Values);
        }

        /// <summary>
        /// 获取轮到回合执行的单位
        /// </summary>
        public void DumpRoundUnits(List<Unit> units)
        {
            foreach (var unit in m_Units.Values)
            {
                if (unit.Progress == Distance)
                    units.Add(unit);
            }
        }

        /// <summary>
        /// 重置单位到起点
        /// </summary>
        public void StepBack(uint uid)
        {
            if (m_Units.TryGetValue(uid, out var unit))
                unit.Progress = 0;
        }

        /// <summary>
        /// 调整速度
        /// </summary>
        public void ChangeSpeed(uint uid, int speed)
        {
            if (m_Units.TryGetValue(uid, out var unit))
                unit.Speed = Math.Max(speed / SpeedScale, 1);
        }

        /// <summary>
        /// 击败
        /// </summary>
        public void Defeated(uint uid)
        {
            if (m_Units.TryGetValue(uid, out var unit))
            {
                unit.Progress = 0;
                unit.Defeated = true;
            }
        }

        /// <summary>
        /// 复活
        /// </summary>
        public void Relive(uint uid)
        {
            if (m_Units.TryGetValue(uid, out var unit))
            {
                unit.Defeated = false;
            }
        }

        // 获取最小移动时间并修正进度
        private int GetMinTimeAndFixProgress()
        {
            var minTime = int.MaxValue;
            foreach (var kv in m_Units)
            {
                var unit = kv.Value;
                if (unit.Defeated)
                    continue;

                // 剩余路程时间
                var remain = (Distance - unit.Progress) / unit.Speed;
                if (remain == 0)
                {
                    // 由于精度问题修正进度
                    unit.Progress = Distance;
                }

                if (remain < minTime)
                    minTime = remain;
            }

            return minTime;
        }

        public void Update(float dt, out bool end)
        {
            end = false;

            var minTime = GetMinTimeAndFixProgress();

            var t = Math.Min(minTime, (int)(dt * ValidBit / RoundTime));

            foreach (var unit in m_Units.Values)
            {
                if (unit.Defeated)
                    continue;

                unit.Progress += unit.Speed * t;
                if (unit.Progress >= Distance)
                {
                    unit.Progress = Distance;
                    end = true;
                }
            }
        }

        private void LogProgress()
        {
            foreach (var unit in m_Units.Values)
            {
                if (unit.Defeated)
                    continue;

                Log.Debug($"进度 unit {unit.Uid} progress {unit.Progress / (float)Distance}");
            }
        }

        private int CalcSpeedScale(int speed)
        {
            // 2147483647   int最大值
            // 10916300     21/11测试时最大速度
            // 按大于十万开始缩放，缩到万级

            if (speed >= 1000000000)
                return 100000;
            else if (speed >= 100000000)
                return 10000;
            else if (speed >= 10000000)
                return 1000;
            else if (speed >= 1000000)
                return 100;
            else if (speed >= 100000)
                return 10;
            else
                return 1;
        }
    }
}
