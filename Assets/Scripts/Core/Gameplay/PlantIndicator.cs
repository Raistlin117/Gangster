using UnityEngine;

namespace Core.Gameplay
{
    public class PlantIndicator : MonoBehaviour
    {
        [SerializeField] private GameObject _indicator;

        public void SetActive(bool isActive)
        {
            _indicator.SetActive(isActive);
        }
    }
}