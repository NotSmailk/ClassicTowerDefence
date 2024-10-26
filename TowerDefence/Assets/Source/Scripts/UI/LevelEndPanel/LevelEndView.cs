using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Source.Scripts.UI.LevelEndPanel
{
	public class LevelEndView : MonoBehaviour
	{
		[SerializeField] private RectTransform _panel;
		[SerializeField] private TextMeshProUGUI _resultText;
		[SerializeField] private Button _retryButton;
		[SerializeField] private Button _quitToMenuButton;
		[SerializeField] private Button _nextLevelButton;

		public void AddListenerRetry(UnityAction call) => _retryButton.onClick.AddListener(call);
		public void AddListenerQuitToMenu(UnityAction call) => _quitToMenuButton.onClick.AddListener(call);
		public void AddListenerNextLevel(UnityAction call) => _nextLevelButton.onClick.AddListener(call);

		public void ActivatePanel(string result, bool nextLevel)
		{
			_resultText.text = result;
			_panel.gameObject?.SetActive(true);
			_nextLevelButton.gameObject?.SetActive(nextLevel);
		}

		public void HidePanel()
		{
			_panel.gameObject?.SetActive(false);
		}
	}
}
