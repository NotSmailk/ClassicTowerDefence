using Assets.Source.Scripts.Data;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Towers
{
	public abstract class TowerModel
    {
		public string WeaponId { get; set; }
		public int Damage { get; protected set; }
		public float Firerate { get; protected set; }
		public float ProjectileSpeed { get; set; }
		public int TowerLevel { get; set; }
        public TowerUpgradeDataConfig[] Upgrades { get; set; }
        public float DetectionRange { get; protected set; }
        public LayerMask TargetMask { get; protected set; } = 1 << 9;
		public int BufferedCount { get; set; }
		public int EnemyHitCount { get; set; }
        public Collider[] Buffer { get; set; }

		public virtual void UpgradeTower()
		{
			if (TowerLevel < Upgrades.Length)
			{
				Damage += Upgrades[TowerLevel].DamageIncreaseValue;
				DetectionRange += Upgrades[TowerLevel].RangeIncreaseValue;
				Firerate += Upgrades[TowerLevel].FirerateIncreaseValue;
				TowerLevel++;
			}
		}
	}
}
