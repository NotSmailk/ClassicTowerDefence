using Assets.Source.Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Source.Scripts.UI.TowerUpgradePanel
{
	public class TowerUpgradePanelView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _priceText;
		[SerializeField] private Button _upgradeButton;
		[SerializeField] private Image _icon;

		public void UpdateInfo(TowerUpgradeDataConfig config = null)
		{
			_upgradeButton.interactable = config != null;

			if (!_upgradeButton.interactable)
				return;

			_priceText.text = $"{config.Price}";
		}

		public void AddListener(UnityAction action)
		{
			_upgradeButton.onClick.AddListener(action);
		}

		public void ShowPanel(bool show)
		{
			gameObject.SetActive(show);
		}
	}
}
