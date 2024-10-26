using Assets.Source.Scripts.Entities.Enemies;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Towers.Tesla
{
	public class TeslaController : TowerController
	{
		private TeslaModel _model;
		private TeslaView _view;

		public TeslaController(TeslaView view, TeslaModel model)
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
				if (shootCooldown.Over)
				{
					foreach (var collider in _model.Buffer)
					{
						if (collider == null)
							continue;

						EnemyController enemy = enemies.GetController(collider.name);

						if (enemy == null)
							continue;

						var projectile = projectileFactory.Get(_model.WeaponId);
						projectile.EnemyController = enemy;
						projectile.Launch(_model, _view.Tower.position, collider.transform.position);
					}

					shootCooldown.Stop();
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
