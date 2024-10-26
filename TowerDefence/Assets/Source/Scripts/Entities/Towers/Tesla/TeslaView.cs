using Assets.Source.Scripts.Data;
using Zenject;

namespace Assets.Source.Scripts.Entities.Towers.Tesla
{
	public class TeslaView : TowerView
    {
        public override TowerController CreateController(DiContainer container, TowerDataConfig config)
        {
            return container.Instantiate<TeslaController>(new object[] { this, new TeslaModel(config) });
        }
    }
}
