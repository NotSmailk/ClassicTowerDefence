using Assets.Source.Scripts.Data;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Enemies.TigerClass
{
	public class TigerClassController : EnemyController
    {
        public TigerClassController(EnemyView view, EnemyDataConfig data)
        {
			this.view = view;
			this.model = new TigerClassModel(data);
			this.model.OnHealthpointsChanged += OnHealtChanged;
			timer = new Utilities.CountdownTimer(model.attackCooldown);

			view.transform.rotation = GetTileType().Rotation();
		}

		public override void ApplyDamage(int damage)
		{
			int absortion = ((TigerClassModel)model).Armor - Random.Range(0, ((TigerClassModel)model).Armor);
			damage -= absortion;

			if (damage < 0)
				damage = 0;

			Debug.Log($"{view.name} taken damage: {damage}");
			model.ApplyDamage(damage);
		}
	}
}
