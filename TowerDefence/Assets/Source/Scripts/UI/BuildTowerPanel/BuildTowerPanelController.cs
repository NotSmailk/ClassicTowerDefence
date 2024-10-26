using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Tiles;
using Zenject;
using UnityEngine;
using Assets.Source.Scripts.Factories.Towers;
using Assets.Source.Scripts.Game.Systems;


namespace Assets.Source.Scripts.UI.BuildTowerPanel
{
    public class BuildTowerPanelController : IInitializable
    {
        private BuildTowerPanelModel _model;
        private BuildTowerPanelView _view;
        private TileController _selectedTile;
        private Vector3 _tilePosition;

        [Inject] private DiContainer _container;
        [Inject] private AvailableTowersData _availablesTowersData;
        [Inject] private AddressablesAssetsLoader _loader;
        [Inject] private TowerPurchaseSystem _purchaseSystem;
        [Inject] private ITowersFactory _towersFactory;

        public BuildTowerPanelController(BuildTowerPanelView view, BuildTowerPanelModel model)
        {
            _model = model;
            _view = view;

            _view.Show(false);
        }

        public void CreateButton(TowerDataConfig config)
        {
            var button = _container.InstantiatePrefabForComponent<BuildTowerButton>(_model.buttonPrefab)
                .Init(config)
                .AddListener(RequestBuildTower);

            _model.buttons.Add(button);
            _view.AddButton(button);
        }

        public void ActivatePanel(TileController controller, Vector3 position)
        {
            _selectedTile?.Deselect();
            _selectedTile = controller;
            _tilePosition = position;
            _selectedTile.Select();
            _view.Show(true);
        }

        public void DeactivatePanel()
        {
            _selectedTile?.Deselect();
            _selectedTile = null;
            _view.Show(false);
        }

        public void RequestBuildTower(TowerDataConfig config)
        {
            _tilePosition.y += 0.5f;
            _purchaseSystem.TryBuildTower(config, _tilePosition);
            DeactivatePanel();
        }

        public async void Initialize()
        {
            _model.buttonPrefab = await _loader.LoadComponent<BuildTowerButton>(_availablesTowersData.TowerButtonId);

            foreach (var config in _availablesTowersData.Towers)
            {
                CreateButton(config);
            }
        }
    }
}
