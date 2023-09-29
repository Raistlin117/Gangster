using Core.Gameplay.PlayerUnits;
using UnityEngine;

namespace Core.Gameplay.Configs
{
    public abstract class PlayerUnitBase : MonoBehaviour
    {
        public abstract PlayerUnitType GetPlayerUnitType();
    }
}