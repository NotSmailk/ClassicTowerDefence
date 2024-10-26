using Assets.Source.Scripts.Data;
using UnityEngine;

namespace Assets.Source.Scripts.Entities.Enemies.BugClass
{
	public class BugClassController : EnemyController
    {
        public BugClassController(EnemyView view, EnemyDataConfig data)
        {
            this.view = view;
			this.model = new BugClassModel(data);
            this.model.OnHealthpointsChanged += OnHealtChanged;
			timer = new Utilities.CountdownTimer(model.attackCooldown);

            view.transform.rotation = GetTileType().Rotation();
		}

		public override void ApplyDamage(int damage)
		{
			Debug.Log($"{view.name} taken damage: {damage}");
			model.ApplyDamage(damage);
		}
    }
}
