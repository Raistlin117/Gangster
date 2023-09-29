using System;
using Core.Gameplay.PlayerUnits;
using Core.Gameplay.SignalScripts;
using Core.UI.SignalScripts;
using UnityEngine;
using Utils;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class PlayerUnitPlantHandler : IStartable, IDisposable
    {
        private readonly PlayerUnitsProvider _playerUnitsProvider;
        private PlayerUnitType _playerSelectedUnitType;
        private int _playerSelectedUnitPrice;
        private bool _selected = false;

        public PlayerUnitPlantHandler(PlayerUnitsProvider playerUnitsProvider)
        {
            _playerUnitsProvider = playerUnitsProvider;
        }
        
        private void OnPlayerUnitSelected(PlayerUnitType unitType, int price)
        {
            _playerSelectedUnitType = unitType;
            _playerSelectedUnitPrice = price;
            _selected = true;
        }

        private void OnPlantPlaceSelected(PlantPlace plantPlace)
        {
            PlantPlayerUnit(plantPlace);
        }

        private void PlantPlayerUnit(PlantPlace plantPlace)
        {
            var playerUnit = _playerUnitsProvider.GetPlayerUnit(_playerSelectedUnitType);

            playerUnit.transform.SetParent(plantPlace.transform);
            playerUnit.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
        }

        public void Start()
        {
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            Signals.Get<PlayerUnitSelectedSignal>().AddListener(OnPlayerUnitSelected);
            Signals.Get<PlantPlaceSelectedSignal>().AddListener(OnPlantPlaceSelected);
        }

        private void Unsubscribe()
        {
            Signals.Get<PlayerUnitSelectedSignal>().RemoveListener(OnPlayerUnitSelected);
            Signals.Get<PlantPlaceSelectedSignal>().RemoveListener(OnPlantPlaceSelected);
        }
    }
}