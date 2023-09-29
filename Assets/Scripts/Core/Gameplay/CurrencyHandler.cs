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

        public void Subtract(int amount)
        {
            CurrentGameplayCurrency -= amount;
            UpdateIndicator(CurrentGameplayCurrency);
        }

        public bool CanBuy(int amount)
        {
            return CurrentGameplayCurrency - amount > 0;
        }

        private void UpdateIndicator(int currency)
        {
            _currencyIndicator.SetCurrencyText(currency.ToString());
        }
    }
}