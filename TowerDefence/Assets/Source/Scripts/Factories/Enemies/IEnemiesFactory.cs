using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Enemies;
using System.Threading.Tasks;

namespace Assets.Source.Scripts.Factories
{
    public interface IEnemiesFactory
    {
        public EnemyController Get(EnemyDataConfig config);
        public Task InitDictionary(LevelDataConfig data);
    }
}
