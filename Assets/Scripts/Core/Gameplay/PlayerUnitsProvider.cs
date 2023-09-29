using Core.Gameplay.Configs;
using Core.Gameplay.PlayerUnits;
using UnityEngine;

namespace Core.Gameplay
{
    public class PlayerUnitsProvider
    {
        private readonly PlayerUnitsConfig _playerUnitsConfig;
        private readonly MonoBehaviourProvider _monoBehaviourProvider;

        public PlayerUnitsProvider(PlayerUnitsConfig playerUnitsConfig, MonoBehaviourProvider monoBehaviourProvider)
        {
            _playerUnitsConfig = playerUnitsConfig;
            _monoBehaviourProvider = monoBehaviourProvider;
        }
        
        public GameObject GetPlayerUnit(PlayerUnitType playerUnitType)
        {
            var playerUnitGameObject = _playerUnitsConfig.GetPlayerUnitGameObject(playerUnitType);

            return _monoBehaviourProvider.GetInstantiate(playerUnitGameObject);
        }
    }
}