using Core.Gameplay.Configs;
using UnityEngine;
using Utils;
using VContainer;

namespace Core.Gameplay.PlayerUnits.MoneyMachine
{
    public class PlayerUnitMoneyMachine : PlayerUnitBase
    {
        [SerializeField] private int _monyAmount = 50;
        [SerializeField] private int _frequency = 20;// не ну это совсем конечно прикол)
        public override PlayerUnitType GetPlayerUnitType() => PlayerUnitType.MoneyMachine;
        private const string Enemy = "Enemy";

        private void Start()
        {
            InvokeRepeating(nameof(MoneyGenerate), _frequency, _frequency); //ужас
        }

        private void MoneyGenerate()
        {
            Signals.Get<AddMoney>().Dispatch(_monyAmount);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Enemy))
            {
                Destroy(gameObject);
            }
        }
    }
}