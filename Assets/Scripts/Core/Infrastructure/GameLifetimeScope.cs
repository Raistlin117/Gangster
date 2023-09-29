using Core.Gameplay;
using Core.Gameplay.Configs;
using Core.UI;
using Core.UI.PlayerUnits;
using Core.UI.PlayerUnits.Configs;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Core.Infrastructure
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Components")]
        [SerializeField] private UIPlayerUnitsConfig _uiPlayerUnitsConfig;
        [SerializeField] private UIPlayerUnitsScroller _uiPlayerUnitsScroller;
        [SerializeField] private MonoBehaviourProvider _monoBehaviourProvider;
        [SerializeField] private PlayerUnitsConfig _playerUnitsConfig;
        [SerializeField] private LevelConfigs _levelConfigs;
        [SerializeField] private PlantIndicator _plantIndicator;
        [SerializeField] private CurrencyIndicator _currencyIndicator;
        [SerializeField] private EnemyUnitsConfig _enemyUnitsConfig;
        [SerializeField] private EnemySpawnerComponent _enemySpawnerComponent;
        [SerializeField] private UIMenuScreen _menuScreen;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<LevelHandler>(Lifetime.Singleton);
            builder.Register<PlayerUnitsProvider>(Lifetime.Singleton);
            builder.Register<CurrencyHandler>(Lifetime.Singleton);
            builder.Register<EnemySpawnHandler>(Lifetime.Singleton);
            builder.Register<EnemyUnitsProvider>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameLoop>();
            builder.RegisterEntryPoint<UIPlayerUnitHandler>();
            builder.RegisterEntryPoint<PlayerUnitPlantHandler>();

            builder.RegisterInstance(_uiPlayerUnitsConfig);
            builder.RegisterInstance(_playerUnitsConfig);
            builder.RegisterInstance(_levelConfigs);
            builder.RegisterInstance(_enemyUnitsConfig);
            
            builder.RegisterComponent(_monoBehaviourProvider);
            builder.RegisterComponent(_uiPlayerUnitsScroller);
            builder.RegisterComponent(_plantIndicator);
            builder.RegisterComponent(_currencyIndicator);
            builder.RegisterComponent(_enemySpawnerComponent);
            builder.RegisterComponent(_menuScreen);

        }
    }
}