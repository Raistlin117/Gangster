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
        private readonly CurrencyHandler _currencyHandler;
        private readonly PlantIndicator _plantIndicator;
        private PlayerUnitType _playerSelectedUnitType;
        private int _playerSelectedUnitPrice;
        private bool _playerUnitSelected = false;

        public PlayerUnitPlantHandler(PlayerUnitsProvider playerUnitsProvider, CurrencyHandler currencyHandler,
            PlantIndicator plantIndicator)
        {
            _playerUnitsProvider = playerUnitsProvider;
            _currencyHandler = currencyHandler;
            _plantIndicator = plantIndicator;
        }
        
        private void OnPlayerUnitSelected(PlayerUnitType unitType, int price)
        {
            if (!_currencyHandler.CanBuy(price)) return;
            
            _playerSelectedUnitType = unitType;
            _playerSelectedUnitPrice = price;
            _playerUnitSelected = true;
            _plantIndicator.SetActive(true);
        }

        private void OnPlantPlaceSelected(PlantPlace plantPlace)
        {
            if(!_playerUnitSelected) return;
            
            PlantPlayerUnit(plantPlace);
        }

        private void PlantPlayerUnit(PlantPlace plantPlace)
        {
            var playerUnit = _playerUnitsProvider.GetPlayerUnit(_playerSelectedUnitType);

            playerUnit.transform.SetParent(plantPlace.transform);
            playerUnit.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
            _currencyHandler.Subtract(_playerSelectedUnitPrice);
            
            ClearSelected();
        }

        private void ClearSelected()
        {
            _playerSelectedUnitType = PlayerUnitType.None;
            _playerSelectedUnitPrice = 0;
            _playerUnitSelected = false;
            _plantIndicator.SetActive(false);
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