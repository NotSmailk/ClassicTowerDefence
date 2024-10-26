using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Factories.LevelButtons;
using Assets.Source.Scripts.Game.Systems;
using Zenject;

namespace Assets.Source.Scripts.UI.LevelSelector
{
	public class LevelSelectorController
	{
		private LevelSelectorModel _model;
		private LevelSelectorView _view;

		private ILevelButtonFactory _buttonFactory;
		private AvailableLevelsData _availableLevelsData;
		private SceneSwitcherSystem _sceneSwitcherSystem;

		[Inject] private SceneNamesData _sceneNamesData;

		[Inject]
		private void Construct(AvailableLevelsData availableLevelsData, ILevelButtonFactory buttonFactory, SceneSwitcherSystem sceneSwitcher)
		{
			_buttonFactory = buttonFactory;
			_buttonFactory.OnFactoryInitialized += OnFactoryInitialized;
			_sceneSwitcherSystem = sceneSwitcher;
			_availableLevelsData = availableLevelsData;
		}

		public LevelSelectorController(LevelSelectorView view, LevelSelectorModel model)
		{
			_model = model;
			_view = view;
			_view.gameObject.SetActive(false);
		}
		
		public void OpenPanel()
		{
			_view.gameObject.SetActive(true);
		}

		private void OnFactoryInitialized()
		{
			foreach (var level in _availableLevelsData.Levels)
				AddLevel(level);
		}

		private void AddLevel(LevelDataConfig levelData)
		{
			LevelButton button = _buttonFactory.Get();
			button.AddListener(() => LoadScene(levelData));
			button.Text = $"{_availableLevelsData.Levels.IndexOf(levelData) + 1}";
			_model.buttons.Add(button);
			_view.AddButton(button);
		}

		private void LoadScene(LevelDataConfig levelData)
		{
			_sceneSwitcherSystem.SwitchScene(_sceneNamesData.Level);
			_availableLevelsData.SetCurrentLevel(levelData);
		}
	}
}
