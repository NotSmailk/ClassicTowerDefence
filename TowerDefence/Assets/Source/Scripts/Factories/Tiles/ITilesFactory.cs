using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Tiles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assets.Source.Scripts.Factories
{
    public interface ITilesFactory
    {
        public TileView Get(TileType type);
        public Task InitTilesDictionary(Dictionary<TileType, string> map);
    }
}
