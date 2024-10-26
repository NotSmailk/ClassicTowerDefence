using Assets.Source.Scripts.Entities.Enemies;
using Assets.Source.Scripts.Utilities;
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

				float distance = Vector3.Distance(_view.transform.position, enemy.Position);
				Vector3 targetCenter = AimAssist.FirstOrderIntercept(_view.transform.position, Vector3.zero, _model.ProjectileSpeed, enemy.Position, enemy.Velocity);

				_view.RotateTowerTo(targetCenter);

				if (shootCooldown.Over)
				{
					shootCooldown.Stop();
					var projectile = projectileFactory.Get(_model.WeaponId);
					projectile.Launch(_model, _view.Tower.position, targetCenter);
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
