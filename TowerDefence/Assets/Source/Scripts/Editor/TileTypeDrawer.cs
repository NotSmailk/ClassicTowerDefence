using Assets.Source.Scripts.Data;
using UnityEditor;

namespace Assets.Source.Scripts.Editor
{
    [CustomPropertyDrawer(typeof(TileTypeEnum))]
    public class TileTypeDrawer : Array2DEditor.Array2DEnumDrawer<TileType> { }
}