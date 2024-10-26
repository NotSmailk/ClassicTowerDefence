using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Source.Scripts.UI.MainMenu
{
	public class MainMenuView : MonoBehaviour
	{
		[SerializeField] private Button _playButton;
		[SerializeField] private Button _quitButton;

		public void AddListenerPlay(UnityAction call)
		{
			_playButton.onClick.AddListener(call);
		}

		public void AddListenerQuit(UnityAction call)
		{
			_quitButton.onClick.AddListener(call);
		}
	}
}
