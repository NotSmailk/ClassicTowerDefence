using Assets.Source.Scripts.Data;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Enemies.TyrantClass
{
	public class TyrantClassController : EnemyController
    {
        public TyrantClassController(EnemyView view, EnemyDataConfig data)
        {
			this.view = view;
			this.model = new TyrantClassModel(data);
			this.model.OnHealthpointsChanged += OnHealtChanged;
			timer = new Utilities.CountdownTimer(model.attackCooldown);

			view.transform.rotation = GetTileType().Rotation();
		}

		public override void ApplyDamage(int damage)
		{
			damage /= 2;
			Debug.Log($"{view.name} taken damage: {damage}");
			model.ApplyDamage(damage);
		}
	}
}
