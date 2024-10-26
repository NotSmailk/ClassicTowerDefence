using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers;
using Assets.Source.Scripts.Game.Systems;
using Zenject;

namespace Assets.Source.Scripts.UI.TowerUpgradePanel
{
	public class TowerUpgradePanelController
	{
		private TowerUpgradePanelModel _model;
		private TowerUpgradePanelView _view;

		[Inject] private TowerPurchaseSystem _purchaseSystem;

		public TowerUpgradePanelController(TowerUpgradePanelModel model, TowerUpgradePanelView view)
		{
			_model = model;
			_view = view;

			_view.AddListener(ClickUpgradeTower);
		}

		public void ActivatePanel(TowerUpgradeDataConfig config, TowerController tower)
		{
			_model.TowerToUpgrade = tower;
			_model.Config = config;
			_view.UpdateInfo(config);
			_view.ShowPanel(true);
		}

		public void DeactivatePanel()
		{
			_view.ShowPanel(false);
		}

		public void ClickUpgradeTower()
		{
			_purchaseSystem.TryUpgradeTower(_model.Config, _model.TowerToUpgrade);
			_view.ShowPanel(false);
		}
	}
}
