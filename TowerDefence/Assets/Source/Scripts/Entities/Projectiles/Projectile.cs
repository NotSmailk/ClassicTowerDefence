using Assets.Source.Scripts.Entities.Enemies;
using Assets.Source.Scripts.Entities.Towers;
using Assets.Source.Scripts.Game.Systems;
using Assets.Source.Scripts.Utilities;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Entities.Projectiles
{
	public abstract class Projectile : MonoBehaviour
	{
		protected float projectileSpeed;
		protected int damage;
		protected int enemyCount;
		protected LayerMask targetMask;
		protected Vector3 targetPosition;
		protected CountdownTimer timer;
		protected float duration;

		public EnemyController EnemyController { get; set; }

		[Inject] protected EnemyEntityHandlerSystem enemies;

		public abstract void Launch(TowerModel model, Vector3 start, Vector3 target);
		public abstract IEnumerator Lifetime();
	}
}
