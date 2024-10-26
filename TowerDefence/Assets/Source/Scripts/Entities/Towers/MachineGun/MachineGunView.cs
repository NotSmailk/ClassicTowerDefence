using Assets.Source.Scripts.Data;
using Zenject;

namespace Assets.Source.Scripts.Entities.Towers.MachineGun
{
	public class MachineGunView : TowerView
    {
        public override TowerController CreateController(DiContainer container, TowerDataConfig config)
        {
            return container.Instantiate<MachineGunController>(new object[]{ this, new MachineGunModel(config) });
        }
    }
}
