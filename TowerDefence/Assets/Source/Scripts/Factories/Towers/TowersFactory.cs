using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Factories.Towers
{
    public class TowersFactory : ITowersFactory
    {
        private Transform _content;
        private Dictionary<string, TowerView> _map;

        [Inject] private DiContainer _container;
        
        private AddressablesAssetsLoader _loader;

        [Inject]
        private async void Construct(AvailableTowersData data, AddressablesAssetsLoader loader)
        {
            _loader = loader;
            _map = new Dictionary<string, TowerView>();
            foreach (var tower in data.Towers)
            {
                if (_map.ContainsKey(tower.Id))
                    continue;

                var view = await _loader.LoadComponent<TowerView>(tower.Id);

                _map.Add(tower.Id, view);
            }
        }

        public TowersFactory(Transform content)
        {
            _content = content;
        }

        public TowerController Get(TowerDataConfig config, Vector3 position)
        {
            var instance = _container.InstantiatePrefabForComponent<TowerView>(_map[config.Id], _content);
            instance.transform.position = position;
            return instance.CreateController(_container, config);
        }
    }
}
