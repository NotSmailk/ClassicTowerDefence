using Assets.Source.Scripts.UI.LevelSelector;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Assets.Source.Scripts.UI.MainMenu
{
	public class MainMenuController
	{
		private MainMenuModel _model;
		private MainMenuView _view;

		[Inject]
		private void Construct(LevelSelectorController controller)
		{
			AddListenerPlay(controller.OpenPanel);
			AddListenerPlay(() => _view.gameObject.SetActive(false));

			AddListnerQuit(Application.Quit);
		}

		public MainMenuController(MainMenuView view, MainMenuModel model)
		{
			_model = model;
			_view = view;
		}

		public void AddListenerPlay(UnityAction call)
		{
			_view.AddListenerPlay(call);
		}

		public void AddListnerQuit(UnityAction call)
		{
			_view.AddListenerQuit(call);
		}
	}
}
