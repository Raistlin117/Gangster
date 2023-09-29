using System;

namespace Core.Gameplay.Configs
{
    [Serializable]
    public class LevelConfigsData
    {
        public int Id;
        public int Lines;
        public int SpawnStartTime;
        public int SpawnEndTime;
        public int WavesCount;
        public int Duration;
        public int StartCurrency;
    }
}