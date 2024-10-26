using Assets.Source.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Installers
{
    [CreateAssetMenu(menuName = "Installers/ProjectScriptables", fileName = "ProjectScriptableObjectsInstaller")]
    public class ProjectScriptableObjectsInstaller : ScriptableObjectInstaller<ProjectScriptableObjectsInstaller>
    {
        [SerializeField] private TilesDataConfig _tilesConfig;
        [SerializeField] private AvailableTowersData _availableTowers;
        [SerializeField] private AvailableLevelsData _availableLevels;
        [SerializeField] private SceneNamesData _sceneNamesData;

		public override void InstallBindings()
        {
            Container.Bind<TilesDataConfig>().FromScriptableObject(_tilesConfig).AsSingle().Lazy();
            Container.Bind<AvailableTowersData>().FromScriptableObject(_availableTowers).AsSingle().Lazy();
            Container.Bind<AvailableLevelsData>().FromScriptableObject(_availableLevels).AsSingle().Lazy();
            Container.Bind<SceneNamesData>().FromScriptableObject(_sceneNamesData).AsSingle().Lazy();
        }
    }
}
