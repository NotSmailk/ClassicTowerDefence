using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers;

namespace Assets.Source.Scripts.UI.TowerUpgradePanel
{
	public class TowerUpgradePanelModel
	{
		public TowerUpgradeDataConfig Config { get; set; }
		public TowerController TowerToUpgrade { get; set; }
	}
}
