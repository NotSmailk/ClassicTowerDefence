using Assets.Source.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Scripts.Entities.Towers.Tesla
{
    public class TeslaModel : TowerModel
    {
		public TeslaModel(TowerDataConfig config)
		{
			Damage = config.Damage;
			Firerate = config.Firerate;
			TowerLevel = 0;
			Upgrades = config.Upgrades;
			DetectionRange = config.Radius;
			Buffer = new UnityEngine.Collider[config.EnemyCount];
			EnemyHitCount = config.EnemyCount;
			WeaponId = config.WeaponId;
		}
	}
}
