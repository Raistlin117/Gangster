using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "LevelConfigs", menuName = "Configs/Core/Gameplay/LevelConfigs", order = 0)]
    public class LevelConfigs : ScriptableObject
    {
        [SerializeField] private List<LevelConfigsData> _levelConfigsData;

        public LevelConfigsData GetLevelData(int level)
        {
            return _levelConfigsData.Find(x => x.Id == level);
        }
    }
}