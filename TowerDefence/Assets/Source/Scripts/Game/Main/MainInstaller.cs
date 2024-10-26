using Assets.Source.Scripts.Factories.LevelButtons;
using Assets.Source.Scripts.UI.LevelSelector;
using Assets.Source.Scripts.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Game.Main
{
	public class MainInstaller : MonoInstaller
	{
		[SerializeField] private MainMenuView _mainMenuView;
		[SerializeField] private LevelSelectorView _levelSelectorView;

		public override void InstallBindings()
		{
			InstallFactories();
			InstallUI();
		}

		public void InstallFactories()
		{
			Container.Bind<ILevelButtonFactory>().To<LevelButtonFactory>().AsSingle().WithArguments(_levelSelectorView.Content);
		}

		public void InstallUI()
		{
			Container.BindInterfacesAndSelfTo<LevelSelectorController>().AsSingle().WithArguments(_levelSelectorView, new LevelSelectorModel()).NonLazy();
			Container.BindInterfacesAndSelfTo<MainMenuController>().AsSingle().WithArguments(_mainMenuView, new MainMenuModel()).NonLazy();
		}
	}
}
