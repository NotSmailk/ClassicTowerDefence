using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers;
using Assets.Source.Scripts.Tiles;
using Assets.Source.Scripts.UI.BuildTowerPanel;
using Assets.Source.Scripts.UI.TowerUpgradePanel;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Game.Systems
{
	public class LevelInterfaceSystem
	{
		[Inject] private TowerUpgradePanelController _towerUpgrade;
		[Inject] private BuildTowerPanelController _buildTowerPanelController;

		public void ActivateUpgradePanel(TowerUpgradeDataConfig config, TowerController tower)
		{
			_towerUpgrade.ActivatePanel(config, tower);
			_buildTowerPanelController.DeactivatePanel();
		}

		public void ActivateBuildPanel(TileController controller, Vector3 position)
		{
			_buildTowerPanelController.ActivatePanel(controller, position);
			_towerUpgrade.DeactivatePanel();
		}

		public void DeactivatePanels()
		{
			_buildTowerPanelController.DeactivatePanel();
			_towerUpgrade.DeactivatePanel();
		}
	}
}
