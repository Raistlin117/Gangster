using TMPro;
using UnityEngine;

namespace Core.Gameplay.EnemyUnits
{
    public abstract class EnemyUnitBase : MonoBehaviour
    {
        [SerializeField] internal int _hp = 300;
        [SerializeField] internal TextMeshProUGUI _hpIndicator;
        public abstract EnemyUnitType GetEnemyUnitType();

        public void GetDamage(int amount)
        {
            if(_hp - amount <= 0) Destroy(gameObject); //надо в пул засунуть и ваще много чего еще надо сделать

            _hp -= amount;
            _hpIndicator.text = _hp.ToString();
        }
    }
}