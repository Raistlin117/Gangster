using System;
using Core.Gameplay.Configs;
using Core.Gameplay.PlayerUnits.MoneyMachine;
using Core.UI.SignalScripts;
using Utils;
using VContainer.Unity;

namespace Core.Gameplay
{
    public class GameLoop : IDisposable, IStartable
    {
        private readonly LevelConfigs _levelConfigs;
        private readonly CurrencyHandler _currencyHandler;
        private readonly LevelHandler _levelHandler;

        public GameLoop(LevelConfigs levelConfigs, CurrencyHandler currencyHandler, LevelHandler levelHandler)
        {
            _levelConfigs = levelConfigs;
            _currencyHandler = currencyHandler;
            _levelHandler = levelHandler;
        }
        
        public void Start()
        {
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void OnPlayButtonPressed()
        {
            SetStartCurrency();
        }

        private void SetStartCurrency()
        {
            int currentLevel = _levelHandler.GetCurrentLevel();
            int startCurrency = _levelConfigs.GetLevelData(currentLevel).StartCurrency;
            
            _currencyHandler.Set(startCurrency);
        }

        private void OnAddMoney(int amount)
        {
            _currencyHandler.Add(amount);
        }

        private void Subscribe()
        {
            Signals.Get<PlayButtonPressedSignal>().AddListener(OnPlayButtonPressed);
            Signals.Get<AddMoney>().AddListener(OnAddMoney); //изначально этого здесь не было
        }

        private void Unsubscribe()
        {
            Signals.Get<PlayButtonPressedSignal>().RemoveListener(OnPlayButtonPressed);
            Signals.Get<AddMoney>().RemoveListener(OnAddMoney); //изначально этого здесь не было
        }
    }
}