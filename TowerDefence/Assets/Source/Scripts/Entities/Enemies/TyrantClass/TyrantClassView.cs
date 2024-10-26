using Assets.Source.Scripts.Data;
using Zenject;

namespace Assets.Source.Scripts.Entities.Enemies.TyrantClass
{
    public class TyrantClassView : EnemyView
    {
        public override EnemyController BuildContoller(DiContainer container, EnemyDataConfig config)
        {
            return container.Instantiate<TyrantClassController>(new object[] { this, config });
        }
    }
}
