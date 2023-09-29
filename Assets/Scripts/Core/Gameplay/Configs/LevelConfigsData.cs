using System;
using System.Collections.Generic;

namespace Core.Gameplay.Configs
{
    [Serializable]
    public class LevelConfigsData
    {
        public int Id;
        public int Lines;
        public int StartCurrency;
        public int EnemyCount; //ужас
        public List<WaveData> WaveData;
    }
}