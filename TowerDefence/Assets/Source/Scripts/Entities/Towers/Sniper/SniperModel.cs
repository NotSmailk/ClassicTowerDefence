﻿using Assets.Source.Scripts.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		}
	}
}
