using Assets.Source.Scripts.Data;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Enemies.SpiderClass
{
	public class SpiderClassController : EnemyController
    {
        public SpiderClassController(EnemyView view, EnemyDataConfig data)
        {
			this.view = view;
			this.model = new SpiderClassModel(data);
			this.model.OnHealthpointsChanged += OnHealtChanged;
			timer = new Utilities.CountdownTimer(model.attackCooldown);

			view.transform.rotation = GetTileType().Rotation();
		}

		public override void ApplyDamage(int damage)
		{
			if (Random.Range(0, 90) < 10)
			{
				Debug.Log($"{view.name} dodged");
				return;
			}

			Debug.Log($"{view.name} taken damage: {damage}");
			model.ApplyDamage(damage);
		}
    }
}
