using Assets.Source.Scripts.Data;

namespace Assets.Source.Scripts.Entities.Enemies.SpiderClass
{
	public class SpiderClassModel : EnemyModel
    {
        public SpiderClassModel(EnemyDataConfig data)
        {
            healthpoints = data.Healthpoints;
            damage = data.Damage;
            speed = data.Speed;
            reward = data.Reward;
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
