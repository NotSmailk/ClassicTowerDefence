using Assets.Source.Scripts.Data;
using System;

namespace Assets.Source.Scripts.Entities.Enemies.TigerClass
{
    public class TigerClassModel : EnemyModel
    {
		public int Armor { get; private set; }

        public TigerClassModel(EnemyDataConfig data)
        {
            healthpoints = data.Healthpoints;
            damage = data.Damage;
            speed = data.Speed;
            reward = data.Reward;
			Armor = 3;
			attackCooldown = 1;
		}

		public override void ApplyDamage(int damage)
		{
			healthpoints -= damage;

			if (healthpoints < 0)
				healthpoints = 0;

			base.ApplyDamage(damage);
		}
	}
}
