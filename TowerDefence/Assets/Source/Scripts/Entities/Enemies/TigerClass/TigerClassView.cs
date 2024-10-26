using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Enemies.SpiderClass;
using Zenject;

namespace Assets.Source.Scripts.Entities.Enemies.TigerClass
{
    public class TigerClassView : EnemyView
    {
        public override EnemyController BuildContoller(DiContainer container, EnemyDataConfig config)
        {
            return container.Instantiate<TigerClassController>(new object[] { this, config });
        }
    }
}
