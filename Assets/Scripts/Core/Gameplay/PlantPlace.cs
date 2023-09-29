using Core.Gameplay.SignalScripts;
using UnityEngine;
using Utils;

namespace Core.Gameplay
{
    public class PlantPlace : MonoBehaviour
    {
        public bool CanPlant() => transform.childCount == 0;

        private void OnMouseUpAsButton()
        {
            if(!CanPlant()) return;
            
            Signals.Get<PlantPlaceSelectedSignal>().Dispatch(this);
        }
    }
}