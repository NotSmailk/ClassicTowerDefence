using TMPro;
using UnityEngine;

namespace Assets.Source.Scripts.UI.GameDataPanel
{
    public class GameDataView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _healthpointText;
        [SerializeField] private TextMeshProUGUI _currencyText;

        public void UpdateHealthpoints(int helathpoints)
        {
            _healthpointText.text = $"HP: {helathpoints}";
        }

        public void UpdateCurrency(int currency)
        {
            _currencyText.text = $"Curr:{currency}";
        }
    }
}
