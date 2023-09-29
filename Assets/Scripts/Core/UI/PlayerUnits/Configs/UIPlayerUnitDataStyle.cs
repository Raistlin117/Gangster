using System;
using Core.Gameplay.PlayerUnits;
using UnityEngine;

namespace Core.UI.PlayerUnits.Configs
{
    [Serializable]
    public class UIPlayerUnitDataStyle
    {
        public PlayerUnitType PlayerUnitType;
        public float Price;
        public Sprite Sprite;
        public int AvailableLevel;
    }
}