using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Game.Systems;
using Zenject;

namespace Assets.Source.Scripts.Installers
{
	public class ProjectSystemsInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			Container.BindInterfacesAndSelfTo<AddressablesAssetsLoader>().AsSingle();
			Container.BindInterfacesAndSelfTo<SceneSwitcherSystem>().AsSingle();
		}
	}
}
