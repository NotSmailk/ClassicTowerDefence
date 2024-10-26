using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Factories;
using Assets.Source.Scripts.Tiles;
using Assets.Source.Scripts.UI.BuildTowerPanel;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Game.Systems
{
    public class MapInitializationSystem : IInitializable
    {
        [Inject] private LevelInterfaceSystem _buildPanel;
        [Inject] private AvailableLevelsData _levelDataConfig;
        [Inject] private ITilesFactory _tilesFactory;
        [Inject] private TilesDataConfig _tilesConfig;
        [Inject] private AddressablesAssetsLoader _addressesAssetsLoader;
        [Inject] private EnemySpawnSystem _enemySpawnSystem;
        [Inject] private DiContainer _container;

        public async void Initialize()
        {
            await _tilesFactory.InitTilesDictionary(_tilesConfig.Map);
            InitLevelMap();
        }

        private void InitLevelMap()
        {
            var map = _levelDataConfig.CurrentLevel.Path.Map;

            for (int i = 0; i < map.GridSize.y; i++)
            {
                for (int j = 0; j < map.GridSize.x; j++)
                {
                    TileType type = map.GetCell(j, i);
                    var tile = _tilesFactory.Get(type);
                    tile.transform.position = new Vector3(-j, 0f, i);

                    var controller = _container.Instantiate<TileController>(new object[]{ tile, new TileModel(type) });
                    controller.OnTileClickEvent += _buildPanel.ActivateBuildPanel;

                    bool enemySpawn = type.Equals(TileType.EnemySpawnLeft) 
                        || type.Equals(TileType.EnemySpawnDown) 
                        || type.Equals(TileType.EnemySpawnUp)
                        || type.Equals(TileType.EnemySpawnRight);

                    if (enemySpawn)
                    {
                        _enemySpawnSystem.SetEnemySpawnPosition(tile.transform.position + Vector3.up);
                    }
                }
            }

            int max = Mathf.Max(map.GridSize.x, map.GridSize.y);
            Camera.main.transform.SetPositionAndRotation(new Vector3(-map.GridSize.x / 2, max, map.GridSize.y / 2), Quaternion.Euler(90f, 180f, 0f));
        }
    }
}
