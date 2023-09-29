using System;
using DG.Tweening;
using UnityEngine;

namespace Core.Gameplay.EnemyUnits.StreetThug
{
    public class EnemyUnitStreetThugComponent : EnemyUnitBase
    {
        [SerializeField] private float _duration = 25;
        public override EnemyUnitType GetEnemyUnitType() => EnemyUnitType.StreetThug;

        private void Start()
        {
            _hpIndicator.text = _hp.ToString();
            
            transform.DOMove(transform.position - Vector3.up * 8, _duration).SetEase(Ease.Linear); //говно
        }
    }
}