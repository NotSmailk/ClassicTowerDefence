using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Enemies.BugClass;
using Zenject;

namespace Assets.Source.Scripts.Entities.Enemies.SpiderClass
{
    public class SpiderClassView : EnemyView
    {
        public override EnemyController BuildContoller(DiContainer container, EnemyDataConfig config)
        {
            return container.Instantiate<SpiderClassController>(new object[] { this, config });
        }
    }
}
