using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Tiles;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Factories
{
    public class TilesFactory : ITilesFactory
    {
        private Transform _content;
        private Dictionary<TileType, TileView> _tiles;

        [Inject] private DiContainer _container;
        [Inject] private AddressablesAssetsLoader _addressablesAssetsLoader;

        public TilesFactory(Transform content)
        {
            _content = content;
            _tiles = new Dictionary<TileType, TileView>();
        }

        public async Task InitTilesDictionary(Dictionary<TileType, string> map)
        {
            foreach (var key in map.Keys)
            {
                var instance = await _addressablesAssetsLoader.LoadComponent<TileView>(map[key]);
                _tiles.Add(key, instance);
            }
        }

        public TileView Get(TileType type)
        {
            var instance = _container.InstantiatePrefabForComponent<TileView>(_tiles[type], _content);
            return instance;
        }
    }
}
