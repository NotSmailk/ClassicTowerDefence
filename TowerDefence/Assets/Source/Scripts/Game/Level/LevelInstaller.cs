using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Factories;
using Assets.Source.Scripts.Factories.Projectiles;
using Assets.Source.Scripts.Factories.Towers;
using Assets.Source.Scripts.Game.Systems;
using Assets.Source.Scripts.UI.BuildTowerPanel;
using Assets.Source.Scripts.UI.GameDataPanel;
using Assets.Source.Scripts.UI.LevelEndPanel;
using Assets.Source.Scripts.UI.TowerUpgradePanel;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Game
{
	public class LevelInstaller : MonoInstaller
    {
        [SerializeField] private Transform _tileContent;
        [SerializeField] private Transform _enemiesContent;
        [SerializeField] private Transform _towersContent;
        [SerializeField] private Transform _projectilesContent;
        [SerializeField] private BuildTowerPanelView _buildTowerPanelView;
        [SerializeField] private TowerUpgradePanelView _upgradePanelView;
        [SerializeField] private GameDataView _gameDataView;
        [SerializeField] private LevelEndView _levelEndView;

        [Inject] private TilesDataConfig _tilesConfig;
        [Inject] private PlayerDataConfig _playerDataConfig;

        public override void InstallBindings()
        {
            InstallFactories();
            InstallSystems();
            InstallUI();
        }

        private void InstallSystems()
        {
            Container.BindInterfacesAndSelfTo<MapInitializationSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemySpawnSystem>().AsSingle().WithArguments(_enemiesContent);
            Container.BindInterfacesAndSelfTo<EnemyEntityHandlerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerEntityHandlerSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<TowerPurchaseSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelInterfaceSystem>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameObjectClickerSystem>().AsSingle();
        }

        private void InstallFactories()
        {
            Container.Bind<ITilesFactory>().To<TilesFactory>().AsSingle().WithArguments(_tileContent);
            Container.Bind<IEnemiesFactory>().To<EnemiesFactory>().AsSingle().WithArguments(_enemiesContent);
            Container.Bind<ITowersFactory>().To<TowersFactory>().AsSingle().WithArguments(_towersContent);
            Container.Bind<IProjectileFactory>().To<ProjectileFactory>().AsSingle().WithArguments(_projectilesContent);
        }

        private void InstallUI()
        {
            Container.BindInterfacesAndSelfTo<BuildTowerPanelController>().AsSingle().WithArguments(_buildTowerPanelView, new BuildTowerPanelModel());
            Container.BindInterfacesAndSelfTo<TowerUpgradePanelController>().AsSingle().WithArguments(_upgradePanelView, new TowerUpgradePanelModel());
            Container.BindInterfacesAndSelfTo<GameDataController>().AsSingle().WithArguments(_gameDataView, new GameDataModel(_playerDataConfig)).NonLazy();
            Container.BindInterfacesAndSelfTo<LevelEndController>().AsSingle().WithArguments(_levelEndView, new LevelEndModel()).NonLazy();
        }
    }
}