﻿using Assets.Source.Scripts.Entities.Towers;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Projectiles
{
	public class Shell : Projectile
	{
		public override void Launch(TowerModel model, Vector3 start, Vector3 target)
		{
			transform.position = start;
			transform.LookAt(target);
			targetMask = model.TargetMask;
			projectileSpeed = model.ProjectileSpeed;
			damage = model.Damage;
			enemyCount = model.EnemyHitCount;
			targetPosition = target;

			StartCoroutine(Lifetime());
		}

		public override IEnumerator Lifetime()
		{
			float delta = Vector3.Distance(targetPosition, transform.position) / projectileSpeed;

			while (Vector3.Distance(transform.position, targetPosition) > 0f)
			{
				transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta * 10 * Time.deltaTime);
				yield return null;
			}

			Collider[] colliders = new Collider[enemyCount];
			if (Physics.OverlapSphereNonAlloc(transform.position, 1f, colliders, targetMask) > 0)
			{
				foreach (Collider collider in colliders)
				{
					if (collider == null) continue;

					var controller = enemies.GetController(collider.name);
					controller.ApplyDamage(damage);
				}
			}

			Destroy(gameObject);
		}
	}
}
