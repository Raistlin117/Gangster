using System;
using System.Collections.Generic;
using Core.Gameplay.PlayerUnits;
using UnityEngine;

namespace Core.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "PlayerUnitsConfig", menuName = "Configs/Core/Gameplay/PlayerUnitsConfig", order = 0)]
    public class PlayerUnitsConfig : ScriptableObject
    {
        [SerializeField] private List<PlayerUnitsStruct> _playerUnits;

        public List<PlayerUnitsStruct> PlayerUnits => _playerUnits;

        public GameObject GetPlayerUnitGameObject(PlayerUnitType playerUnitType)
        {
            var targetGameObject = _playerUnits
                .Find(x => x.PlayerUnitType == playerUnitType).PlayerUnitBase.gameObject;
            
            return targetGameObject;
        }
    }
}