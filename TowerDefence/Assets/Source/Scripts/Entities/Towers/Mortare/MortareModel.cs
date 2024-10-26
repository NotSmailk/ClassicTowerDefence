using Assets.Source.Scripts.Data;

namespace Assets.Source.Scripts.Entities.Towers.Mortare
{
	public class MortareModel : TowerModel
	{
		public MortareModel(TowerDataConfig config)
		{
			Damage = config.Damage;
			Firerate = config.Firerate;
			TowerLevel = 0;
			Upgrades = config.Upgrades;
			DetectionRange = config.Radius;
			Buffer = new UnityEngine.Collider[1];
			EnemyHitCount = config.EnemyCount;
			WeaponId = config.WeaponId;
			ProjectileSpeed = 3f;
		}
	}
}
