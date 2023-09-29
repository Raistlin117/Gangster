using System;
using Core.Gameplay.PlayerUnits;
using UnityEngine;

namespace Core.UI.PlayerUnits
{
    [Serializable]
    public class UIPlayerUnitData
    {
        [SerializeField] private PlayerUnitType _playerUnitType;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _price;
        [SerializeField] private int _availableFromLevel;

        public int Price => _price;
        public PlayerUnitType PlayerUnitType => _playerUnitType;
        public Sprite Sprite => _sprite;
        public int AvailableFromLevel => _availableFromLevel;
    }
}