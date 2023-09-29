using System.Collections.Generic;
using UnityEngine;

namespace Core.UI.PlayerUnits.Configs
{
    [CreateAssetMenu(fileName = "UIPlayerUnitConfig", menuName = "Configs/Core/UI/UIPlayerUnitConfig", order = 0)]
    public class UIPlayerUnitsConfig : ScriptableObject
    {
        [SerializeField] private List<UIPlayerUnitData> _uiPlayerUnitData;

        public List<UIPlayerUnitData> UIPlayerUnitData => _uiPlayerUnitData;
    }
}