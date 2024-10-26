using Assets.Source.Scripts.Data;

namespace Assets.Source.Scripts.Entities.Towers.MachineGun
{
	public class MachineGunModel : TowerModel
    {
        public MachineGunModel(TowerDataConfig config)
        {
			Damage = config.Damage;
			Firerate = config.Firerate;
			TowerLevel = 0;
			Upgrades = config.Upgrades;
            DetectionRange = config.Radius;
            Buffer = new UnityEngine.Collider[1];
            ProjectileSpeed = 3f;
            EnemyHitCount = config.EnemyCount;
            WeaponId = config.WeaponId;
        }
    }
}
