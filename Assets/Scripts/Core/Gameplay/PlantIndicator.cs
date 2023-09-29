using Core.Gameplay.PlayerUnits;
using Core.Gameplay.SignalScripts;
using Core.UI.SignalScripts;
using UnityEngine;
using Utils;

namespace Core.Gameplay
{
    public class PlantIndicator : MonoBehaviour
    {
        [SerializeField] private GameObject _indicator;
        
        private void OnEnable()
        {
            Signals.Get<PlayerUnitSelectedSignal>().AddListener(OnUnitSelected);
            Signals.Get<PlantPlaceSelectedSignal>().AddListener(OnPlantPlaceSelected);
        }

        private void OnDisable()
        {
            Signals.Get<PlayerUnitSelectedSignal>().AddListener(OnUnitSelected);
            Signals.Get<PlantPlaceSelectedSignal>().AddListener(OnPlantPlaceSelected);
        }

        private void OnPlantPlaceSelected(PlantPlace plantPlace)
        {
            _indicator.SetActive(false);
        }

        private void OnUnitSelected(PlayerUnitType playerUnitType, int price)
        {
            _indicator.SetActive(true);
        }
    }
}