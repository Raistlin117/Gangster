namespace Core.Gameplay
{
    public class CurrencyHandler
    {
        public int CurrentGameplayCurrency { get; private set; }

        public void Add(int amount)
        {
            CurrentGameplayCurrency += amount;
        }

        public void Set(int value)
        {
            CurrentGameplayCurrency = value;
        }

        public bool Subtract(int amount)
        {
            if (CurrentGameplayCurrency - amount < 0) return false;
            
            CurrentGameplayCurrency -= amount;
            return true;
        }
    }
}