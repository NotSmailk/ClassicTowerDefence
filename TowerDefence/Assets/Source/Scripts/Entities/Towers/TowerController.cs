using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Factories.Projectiles;
using Assets.Source.Scripts.Game.Systems;
using Assets.Source.Scripts.UI.TowerUpgradePanel;
using Assets.Source.Scripts.Utilities;
using Zenject;

namespace Assets.Source.Scripts.Entities.Towers
{
	public abstract class TowerController
    {
        protected CountdownTimer shootCooldown;

        [Inject] protected EnemyEntityHandlerSystem enemies;
        [Inject] protected LevelInterfaceSystem levelInterface;
        [Inject] protected IProjectileFactory projectileFactory;

        public abstract void GameUpdate();
        public abstract void UpgradeTower();

		protected abstract bool FintTargets();
	}
}
