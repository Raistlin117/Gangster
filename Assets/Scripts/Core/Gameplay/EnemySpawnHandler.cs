using System;
using Core.Gameplay.Configs;
using Core.UI.SignalScripts;
using Utils;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class EnemySpawnHandler : IStartable, IDisposable, ITickable
    {
        private readonly EnemySpawnerComponent _enemySpawnerComponent;
        private readonly LevelConfigs _levelConfigs;
        private readonly EnemyUnitsConfig _enemyUnitsConfig;
        private readonly EnemyUnitsProvider _enemyUnitsProvider;

        public EnemySpawnHandler(EnemySpawnerComponent enemySpawnerComponent, LevelConfigs levelConfigs,
            EnemyUnitsConfig enemyUnitsConfig, EnemyUnitsProvider enemyUnitsProvider)
        {
            _enemySpawnerComponent = enemySpawnerComponent;
            _levelConfigs = levelConfigs;
            _enemyUnitsConfig = enemyUnitsConfig;
            _enemyUnitsProvider = enemyUnitsProvider;
        }
        
        public void Tick()
        {
            
        }

        private void OnPLayButtonPressed()
        {
            
        }

        public void Start()
        {
            Signals.Get<PlayButtonPressedSignal>().AddListener(OnPLayButtonPressed);
        }

        public void Dispose()
        {
            Signals.Get<PlayButtonPressedSignal>().RemoveListener(OnPLayButtonPressed);
        }
    }
}