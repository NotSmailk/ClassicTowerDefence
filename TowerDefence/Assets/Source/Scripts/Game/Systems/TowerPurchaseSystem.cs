using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers;
using Assets.Source.Scripts.Factories.Towers;
using Assets.Source.Scripts.UI.BuildTowerPanel;
using Assets.Source.Scripts.UI.GameDataPanel;
using Assets.Source.Scripts.UI.TowerUpgradePanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Game.Systems
{
    public class TowerPurchaseSystem
    {
        [Inject] private BuildTowerPanelController _buildTower;
        [Inject] private TowerUpgradePanelController _towerUpgrade;
        [Inject] private DiContainer _diContainer;
        [Inject] private ITowersFactory _towersFactory;
        [Inject] private TowerEntityHandlerSystem _towerEntityHandlerSystem;
        [Inject] private GameDataController _gameDataController;
        
        public void TryBuildTower(TowerDataConfig config, Vector3 position)
        {
            if (_gameDataController.TakeCurrency(config.Price))
            {
				var tower = _towersFactory.Get(config, position);
                _towerEntityHandlerSystem.RegisterController(tower);
			}
        }

        public void TryUpgradeTower(TowerUpgradeDataConfig config, TowerController controller)
        {
            if (_gameDataController.TakeCurrency(config.Price))
            {
                controller.UpgradeTower();
            }
        }
    }
}
