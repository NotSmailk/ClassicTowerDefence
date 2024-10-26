using Assets.Source.Scripts.Data;
using Zenject;

namespace Assets.Source.Scripts.Entities.Enemies.BugClass
{
    public class BugClassView : EnemyView
    {
		public override EnemyController BuildContoller(DiContainer container, EnemyDataConfig config)
        {
            return container.Instantiate<BugClassController>(new object[]{ this, config });
        }
    }
}