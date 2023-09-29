using System.Collections.Generic;
using UnityEngine;

namespace Core.UI.PlayerUnits
{
    public class UIPlayerUnitsScroller : MonoBehaviour
    {
        [SerializeField] private UIPlayerUnit[] _uiPlayerUnits;
        
        public void Setup(List<UIPlayerUnitData> uiPlayerUnitsData)
        {
            SetPlayerUnitsData(uiPlayerUnitsData);
        }

        private void SetPlayerUnitsData(List<UIPlayerUnitData> uiPlayerUnitsData)
        {
            for (int i = 0; i < _uiPlayerUnits.Length; i++)
            {
                if (uiPlayerUnitsData.Count <= i)
                {
                    _uiPlayerUnits[i].gameObject.SetActive(false);
                    continue;
                }
                
                _uiPlayerUnits[i].Setup(uiPlayerUnitsData[i]);
            }
        }
    }
}