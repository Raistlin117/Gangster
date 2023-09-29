using Core.Gameplay.Configs;
using Core.Gameplay.EnemyUnits;
using UnityEngine;

namespace Core.Gameplay
{
    public class EnemyUnitsProvider
    {
        private readonly MonoBehaviourProvider _monoBehaviourProvider;
        private readonly EnemyUnitsConfig _enemyUnitsConfig;

        public EnemyUnitsProvider(MonoBehaviourProvider monoBehaviourProvider, EnemyUnitsConfig enemyUnitsConfig)
        {
            _monoBehaviourProvider = monoBehaviourProvider;
            _enemyUnitsConfig = enemyUnitsConfig;
        }
        
        public GameObject GetEnemyUnit(EnemyUnitType enemyUnitType)
        {
            var playerUnitGameObject = _enemyUnitsConfig.GetEnemyUnitGameObject(enemyUnitType);

            return _monoBehaviourProvider.GetInstantiate(playerUnitGameObject);
        }
    }
}