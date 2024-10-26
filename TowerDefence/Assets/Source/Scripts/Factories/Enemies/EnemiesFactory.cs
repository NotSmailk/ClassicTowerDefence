using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Enemies;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Factories
{
    public class EnemiesFactory : IEnemiesFactory
    {
        private Dictionary<string, EnemyView> _map;
        private Transform _content;

        [Inject] private DiContainer _container;
        [Inject] private AddressablesAssetsLoader _addressablesAssetsLoader;

        public EnemiesFactory(Transform content)
        {
            _map = new Dictionary<string, EnemyView>();
            _content = content;
        }

        public async Task InitDictionary(LevelDataConfig data)
        {
            foreach (var waveCfg in data.Waves)
            {
                foreach (var detail in waveCfg.Details)
                {
                    if (_map.ContainsKey(detail.Data.Id))
                        continue;

                    EnemyView instance = await _addressablesAssetsLoader.LoadComponent<EnemyView>(detail.Data.Id);
                    _map.Add(detail.Data.Id, instance);
                }
            }
        }

        public EnemyController Get(EnemyDataConfig config)
        {
            var instance = _container.InstantiatePrefabForComponent<EnemyView>(_map[config.Id], _content);
            instance.transform.position = _content.position;
            return instance.BuildContoller(_container, config);
        }
    }
}
