using System;
using UnityEngine;

namespace Core.Gameplay
{
    public class LoseCondition : MonoBehaviour
    {
        [SerializeField] private GameObject loosePopUp;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                loosePopUp.SetActive(true);
            }
        }
    }
}