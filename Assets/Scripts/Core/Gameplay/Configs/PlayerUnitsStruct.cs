using System;
using Core.Gameplay.PlayerUnits;

namespace Core.Gameplay.Configs
{
    [Serializable]
    public struct PlayerUnitsStruct
    {
        public PlayerUnitType PlayerUnitType;
        public PlayerUnitBase PlayerUnitBase;
    }
}