using System.Collections.Generic;
using Core.Gameplay.EnemyUnits;
using UnityEngine;

namespace Core.Gameplay.Configs
{
    [CreateAssetMenu(fileName = "EnemyUnitsConfig", menuName = "Configs/Core/Gameplay/EnemyUnitsConfig", order = 0)]
    public class EnemyUnitsConfig : ScriptableObject
    {
        [SerializeField] private List<EnemyUnitsStruct> _enemyUnitsStructs;

        public GameObject GetEnemyUnitGameObject(EnemyUnitType targetEnemyUnitType)
        {
            var enemyUnitGameObject = _enemyUnitsStructs
                .Find(x => x.EnemyUnitType == targetEnemyUnitType).EnemyUnitBase.gameObject;

            return enemyUnitGameObject;
        }
    }
}