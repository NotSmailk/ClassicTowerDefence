using Assets.Source.Scripts.Entities.Enemies;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Entities.Towers.MachineGun
{
	public class MachineGunController : TowerController
	{
		private MachineGunModel _model;
		private MachineGunView _view;

		public MachineGunController(MachineGunView view, MachineGunModel model)
		{
			_view = view;
			_model = model;

			shootCooldown = new Utilities.CountdownTimer(1f / _model.Firerate);

			_view.OnTowerClick += OnTowerClick;
		}

		public override void GameUpdate()
		{
			if (FintTargets())
			{
				Collider target = _model.Buffer[0];
				EnemyController enemy = enemies.GetController(target.name);

				if (enemy == null)
					return;

				Vector3 targetVelocity = enemy.Velocity;
				Vector3 targetPosition = target.transform.position;

				Vector3 turretPosition = _view.Tower.position;
				Vector3 turretVelocity = _view.Tower.forward * _model.ProjectileSpeed;

				Vector3 relativePos = targetPosition - turretPosition;
				Vector3 relativeVelocity = targetVelocity - turretVelocity;

				float timeToCollide = Vector3.Dot(relativePos, relativeVelocity) / relativeVelocity.sqrMagnitude;
				Vector3 collisionPoint = targetPosition + targetVelocity * timeToCollide;

				_view.RotateTowerTo(collisionPoint);

				if (shootCooldown.Over)
				{
					shootCooldown.Stop();
					var projectile = projectileFactory.Get(_model.WeaponId);
					projectile.Launch(_model, _view.Tower.position, collisionPoint);
					shootCooldown.Start(1f / _model.Firerate);
				}

				shootCooldown.Tick(Time.deltaTime);
			}
		}

		protected override bool FintTargets()
		{
			_model.BufferedCount = Physics.OverlapSphereNonAlloc(_view.transform.position, _model.DetectionRange, _model.Buffer, _model.TargetMask);
			return _model.BufferedCount > 0;
		}

		public override void UpgradeTower()
		{
			_model.UpgradeTower();
		}

		private void OnTowerClick()
		{
			if (_model.TowerLevel >= _model.Upgrades.Length)
				return;

			levelInterface.ActivateUpgradePanel(_model.Upgrades[_model.TowerLevel], this);
		}
	}
}
