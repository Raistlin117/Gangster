using System;
using Core.Gameplay.Configs;
using UnityEngine;

namespace Core.Gameplay.PlayerUnits.Thug
{
    public class PlayerUnitThugComponent : PlayerUnitBase
    {
        private const string Enemy = "Enemy";
        public override PlayerUnitType GetPlayerUnitType() => PlayerUnitType.Thug;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Enemy))
            {
                Destroy(gameObject);
            }
        }
    }
}