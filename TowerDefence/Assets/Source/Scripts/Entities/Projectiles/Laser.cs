using Assets.Source.Scripts.Entities.Enemies;
using Assets.Source.Scripts.Entities.Towers;
using System.Collections;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Projectiles
{
	[RequireComponent(typeof(LineRenderer))]
	public class Laser : Projectile
	{
		private LineRenderer _lineRenderer;
		private TowerModel _towerModel;

		public override void Launch(TowerModel model, Vector3 start, Vector3 target)
		{
			_towerModel = model;
			transform.position = start;
			transform.LookAt(target);
			targetPosition = target;
			duration = 1f;
			damage = model.Damage;

			_lineRenderer = GetComponent<LineRenderer>();
			StartCoroutine(Lifetime());
		}

		public override IEnumerator Lifetime()
		{
			_lineRenderer.positionCount = 2;
			_lineRenderer.SetPosition(0, transform.position);

			EnemyController?.ApplyDamage(damage);

			while (duration > 0)
			{
				if (!EnemyController.Alive)
					break;

				_lineRenderer.SetPosition(1, EnemyController.Position);

				yield return null;
				duration -= Time.deltaTime;
			}

			Destroy(gameObject);
		}
	}
}
