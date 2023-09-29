using System;
using System.Collections;
using System.Collections.Generic;
using Core.Gameplay.Configs;
using Core.Gameplay.EnemyUnits;
using Core.UI.SignalScripts;
using UnityEngine;
using Utils;
using VContainer;
using Random = UnityEngine.Random;

namespace Core.Gameplay
{
    public class EnemySpawnerComponent : MonoBehaviour
    {
        [SerializeField] private List<Transform> _enemySpawnPoints;
        
        private LevelConfigs _levelConfigs;
        private EnemyUnitsProvider _enemyUnitsProvider;

        private WaitForSeconds _startSpawnDelay;
        private LevelHandler _levelHandler;
        private Coroutine _spawnUnitsCoroutine;

        [Inject]
        public void Construct(LevelConfigs levelConfigs,EnemyUnitsProvider enemyUnitsProvider, LevelHandler levelHandler)
        {
            _levelHandler = levelHandler;
            _enemyUnitsProvider = enemyUnitsProvider;
            _levelConfigs = levelConfigs;
        }

        private void OnPlayPressed()
        {
            StartCoroutine(StartSpawnDelayRoutine());
        }

        private IEnumerator StartSpawnDelayRoutine()
        {
            int currentLevel = _levelHandler.GetCurrentLevel();
            var currentLevelData = _levelConfigs.GetLevelData(currentLevel);
            var startSpawnDelay = currentLevelData.WaveData[0].StartTime;
            int enemyCount = currentLevelData.EnemyCount;
            
            yield return new WaitForSeconds(startSpawnDelay);

            for (int i = 0; i < enemyCount; i++)
            {
                Spawn(currentLevelData);
            }
        }

        private void Spawn(LevelConfigsData levelData)
        {
            int spawnLine = Random.Range(0, levelData.Lines);//int random exlusive
            int spawnTime = Random.Range(levelData.WaveData[0].StartTime, levelData.WaveData[^1].EndTime);

            StartCoroutine(SpawnDelay(spawnTime, spawnLine));
        }

        private IEnumerator SpawnDelay(int waitForSeconds, int spawnLine)
        {
            yield return new WaitForSeconds(waitForSeconds);
            
            var enemyUnit = _enemyUnitsProvider.GetEnemyUnit(EnemyUnitType.StreetThug);//must be random
            enemyUnit.transform.position = _enemySpawnPoints[spawnLine].position;
        }

        private void OnEnable()
        {
            Signals.Get<PlayButtonPressedSignal>().AddListener(OnPlayPressed);
        }

        private void OnDisable()
        {
            Signals.Get<PlayButtonPressedSignal>().RemoveListener(OnPlayPressed);
        }
    }
}