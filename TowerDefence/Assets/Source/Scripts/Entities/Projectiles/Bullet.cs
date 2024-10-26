using Assets.Source.Scripts.Entities.Enemies;
using Assets.Source.Scripts.Entities.Towers;
using Assets.Source.Scripts.Utilities;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Projectiles
{
	public class Bullet : Projectile
	{
		private SphereCollider _sphereCollider;

		public override void Launch(TowerModel model, Vector3 start, Vector3 target)
		{
			transform.position = start;
			transform.LookAt(target);
			targetMask = model.TargetMask;
			projectileSpeed = model.ProjectileSpeed;
			damage = model.Damage;
			enemyCount = model.EnemyHitCount;
			targetPosition = target;
			duration = 3f;

			_sphereCollider = GetComponent<SphereCollider>();

			StartCoroutine(Lifetime());
		}

		public override IEnumerator Lifetime()
		{
			Vector3 delta = (targetPosition - transform.position) * projectileSpeed;
			CountdownTimer timer = new CountdownTimer(duration);

			while (!timer.Over)
			{
				if (Physics.SphereCast(transform.position, _sphereCollider.radius, transform.position, out RaycastHit hit, targetMask))
				{
					if (hit.collider.gameObject.TryGetComponent(out EnemyView view))
					{
						var controller = enemies.GetController(view.name);
						controller.ApplyDamage(damage);

						enemyCount--;

						if (enemyCount <= 0)
							break;
					}
				}

				transform.position += delta * Time.deltaTime;
				timer.Tick(Time.deltaTime);
				yield return null;
			}

			timer.Stop();
			Destroy(gameObject);
		}
	}
}
