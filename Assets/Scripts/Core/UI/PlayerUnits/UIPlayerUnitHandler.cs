using System;
using System.Collections.Generic;
using Core.Gameplay;
using Core.UI.PlayerUnits.Configs;
using Core.UI.SignalScripts;
using Utils;
using VContainer.Unity;

namespace Core.UI.PlayerUnits
{
    public class UIPlayerUnitHandler : IStartable, IDisposable
    {
        private readonly UIPlayerUnitsConfig _uiPlayerUnitsConfig;
        private readonly UIPlayerUnitsScroller _uiPlayerUnitsScroller;
        private readonly LevelHandler _levelHandler;

        public UIPlayerUnitHandler(UIPlayerUnitsConfig uiPlayerUnitsConfig, UIPlayerUnitsScroller uiPlayerUnitsScroller,
            LevelHandler levelHandler)
        {
            _uiPlayerUnitsConfig = uiPlayerUnitsConfig;
            _uiPlayerUnitsScroller = uiPlayerUnitsScroller;
            _levelHandler = levelHandler;
        }

        private void OnPlayButtonPressed()
        {
            SetPlayerUnitScroller();
        }

        private void SetPlayerUnitScroller()
        {
            var unitsData = GetAvailableUnitsData();
            _uiPlayerUnitsScroller.Setup(unitsData);
        }

        private List<UIPlayerUnitData> GetAvailableUnitsData()
        {
            int currentLevel = _levelHandler.GetCurrentLevel();
            
            var availableData = _uiPlayerUnitsConfig.UIPlayerUnitData
                .FindAll(x => x.AvailableFromLevel <= currentLevel);

            return availableData;
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
            Signals.Get<PlayButtonPressedSignal>().AddListener(OnPlayButtonPressed);
        }

        private void Unsubscribe()
        {
            Signals.Get<PlayButtonPressedSignal>().RemoveListener(OnPlayButtonPressed);
        }
    }
}