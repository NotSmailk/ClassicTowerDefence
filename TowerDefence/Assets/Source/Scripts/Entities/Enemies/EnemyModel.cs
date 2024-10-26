using System;

namespace Assets.Source.Scripts.Entities.Enemies
{
    public abstract class EnemyModel
    {
        public int healthpoints;
        public int damage;
        public int speed;
        public int reward;
        public int attackCooldown;

		public event Action<int> OnHealthpointsChanged;

		public virtual void ApplyDamage(int damage)
		{
			OnHealthpointsChanged?.Invoke(healthpoints);
		}
    }
}
