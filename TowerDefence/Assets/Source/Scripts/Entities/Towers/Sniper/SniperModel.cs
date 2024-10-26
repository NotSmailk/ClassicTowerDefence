using Assets.Source.Scripts.Data;

namespace Assets.Source.Scripts.Entities.Towers.Sniper
{
	public class SniperModel : TowerModel
	{
		public SniperModel(TowerDataConfig config)
		{
			Damage = config.Damage;
			Firerate = config.Firerate;
			TowerLevel = 0;
			Upgrades = config.Upgrades;
			DetectionRange = config.Radius;
			Buffer = new UnityEngine.Collider[1];
			EnemyHitCount = config.EnemyCount;
			WeaponId = config.WeaponId;
			ProjectileSpeed = 5f;
		}
	}
}
