using Core.Gameplay.PlayerUnits;
using Core.UI.SignalScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Core.UI.PlayerUnits
{
    public class UIPlayerUnit : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _price;

        public PlayerUnitType PlayerUnitType { get; private set; }
        public int Price { get; private set; }

        public void Setup(UIPlayerUnitData uiPlayerUnitData)
        {
            _icon.sprite = uiPlayerUnitData.Sprite;
            Price = uiPlayerUnitData.Price;
            _price.text = uiPlayerUnitData.Price.ToString();
            PlayerUnitType = uiPlayerUnitData.PlayerUnitType;
        }

        public void OnPlayerUnitPressed()
        {
            // тут мне не нравится что делаю с сигналом, тут надо было создать какой то один обработчик и дальше связать с другими частями
            Signals.Get<PlayerUnitSelectedSignal>().Dispatch(PlayerUnitType, Price);
        }
    }
}