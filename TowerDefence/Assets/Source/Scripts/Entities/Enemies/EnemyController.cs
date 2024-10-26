using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Tiles;
using Assets.Source.Scripts.UI.GameDataPanel;
using Assets.Source.Scripts.Utilities;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Entities.Enemies
{
    public abstract class EnemyController
    {
		public delegate void EnemyDestoyed(EnemyController controller);
		public event EnemyDestoyed OnEnemyDestoyed;

		protected EnemyView view;
		protected EnemyModel model;
		protected CountdownTimer timer;

		[Inject] protected GameDataController gameDataController;

		protected const int TilesLayer = 1 << 8;

		public string Name
		{
			get => view.name;
			set => view.name = value;
		}
		public int Reward => model.reward;
		public Vector3 Velocity => (view.transform.forward - view.transform.position).normalized * model.speed;
		public Vector3 Position => view.transform.position;
		public bool Alive => model.healthpoints > 0;

		public virtual void GameUpdate()
		{
			TileType type = GetTileType();
			MoveView(type);
			Attack(type);
		}

		public virtual void ApplyDamage(int damage)
		{
			model.ApplyDamage(damage);
		}

		protected virtual void OnHealtChanged(int health)
		{
			if (health <= 0)
			{
				OnEnemyDestoyed?.Invoke(this);
				GameObject.Destroy(view.gameObject);
			}
		}

		protected virtual TileType GetTileType()
		{
			if (Physics.Raycast(view.transform.position, -view.transform.up, out RaycastHit hit, 1f, TilesLayer))
			{
				if (hit.collider.gameObject.TryGetComponent(out TileView tileView))
				{
					return tileView.Type;
				}
			}

			return TileType.None;
		}

		protected virtual void MoveView(TileType type)
		{
			if (type.Equals(TileType.Player) || type.Equals(TileType.None))
				return;

			Quaternion newRot = Quaternion.Slerp(view.transform.rotation, type.Rotation(), 10f * Time.deltaTime);
			Vector3 newPos = view.transform.position + view.transform.forward * model.speed * Time.deltaTime;
			view.transform.SetPositionAndRotation(newPos, newRot);
		}

		protected virtual void Attack(TileType type)
		{
			if (type.Equals(TileType.Player))
			{
				if (timer.Over)
				{
					gameDataController.TakeDamage(model.damage);

					timer.Stop();
					timer.Start(model.attackCooldown);
				}

				timer.Tick(Time.deltaTime);
			}
		}
	}
}
