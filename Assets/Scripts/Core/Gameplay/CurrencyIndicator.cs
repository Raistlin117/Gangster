using TMPro;
using UnityEngine;

namespace Core.Gameplay
{
    public class CurrencyIndicator : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _currencyText;

        public void SetCurrencyText(string text)
        {
            _currencyText.text = text;
        }
    }
}