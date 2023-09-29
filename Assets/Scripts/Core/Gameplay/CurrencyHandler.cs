namespace Core.Gameplay
{
    public class CurrencyHandler
    {
        private readonly CurrencyIndicator _currencyIndicator;

        public CurrencyHandler(CurrencyIndicator currencyIndicator)
        {
            _currencyIndicator = currencyIndicator;
        }
        public int CurrentGameplayCurrency { get; private set; }

        public void Add(int amount)
        {
            CurrentGameplayCurrency += amount;
            UpdateIndicator(CurrentGameplayCurrency);
        }

        public void Set(int value)
        {
            CurrentGameplayCurrency = value;
            UpdateIndicator(CurrentGameplayCurrency);
        }

        public bool Subtract(int amount)
        {
            if (CurrentGameplayCurrency - amount < 0) return false;
            
            CurrentGameplayCurrency -= amount;
            UpdateIndicator(CurrentGameplayCurrency);
            return true;
        }

        private void UpdateIndicator(int currency)
        {
            _currencyIndicator.SetCurrencyText(currency.ToString());
        }
    }
}