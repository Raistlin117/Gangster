using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "PlayerUnitsConfig", menuName = "Configs/Core/Gameplay/PlayerUnitsConfig", order = 0)]
    public class PlayerUnitsConfig : ScriptableObject
    {
        [SerializeField] private List<PlayerUnitsStruct> _playerUnits;

        public List<PlayerUnitsStruct> PlayerUnits => _playerUnits;
    }
}