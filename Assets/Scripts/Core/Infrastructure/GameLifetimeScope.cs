using Core.Gameplay;
using Core.Gameplay.Configs;
using Core.UI.PlayerUnits;
using Core.UI.PlayerUnits.Configs;
using UnityEngine;
using UnityEngine.Serialization;
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

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<LevelHandler>(Lifetime.Singleton);
            builder.Register<PlayerUnitsProvider>(Lifetime.Singleton);

            builder.RegisterEntryPoint<GameLoop>();
            builder.RegisterEntryPoint<UIPlayerUnitHandler>();
            builder.RegisterEntryPoint<PlayerUnitPlantHandler>();

            builder.RegisterInstance(_uiPlayerUnitsConfig);
            builder.RegisterInstance(_playerUnitsConfig);
            
            builder.RegisterComponent(_monoBehaviourProvider);
            builder.RegisterComponent(_uiPlayerUnitsScroller);

        }
    }
}