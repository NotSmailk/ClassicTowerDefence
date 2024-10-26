using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Game.Systems;
using Zenject;

namespace Assets.Source.Scripts.UI.LevelEndPanel
{
	public class LevelEndController
	{
		private LevelEndView _view;
		private LevelEndModel _model;

		public bool Paused { get; private set; }

		[Inject]
		private void Construct(AvailableLevelsData availableLevelsData, SceneSwitcherSystem sceneSwitcherSystem, SceneNamesData sceneNamesData)
		{
			_view.AddListenerQuitToMenu(delegate
			{
				sceneSwitcherSystem.SwitchScene(sceneNamesData.Preloader);
			});

			_view.AddListenerNextLevel(delegate
			{
				availableLevelsData.ClearLevel(availableLevelsData.CurrentLevel);
				availableLevelsData.NextLevel();
				sceneSwitcherSystem.ReloadScene();
			});

			_view.AddListenerRetry(delegate
			{
				sceneSwitcherSystem.ReloadScene();
			});
		}

		public LevelEndController(LevelEndView view, LevelEndModel model)
		{
			_model = model;
			_view = view;
			Paused = false;
		}

		public void Defeat()
		{
			_view.ActivatePanel(_model.defeatText, false);
			Paused = true;
		}

		public void Victory()
		{
			_view.ActivatePanel(_model.victoryText, true);
			Paused = true;
		}
	}
}
