using Assets.Source.Scripts.Data;
using UnityEngine;

namespace Assets.Source.Scripts.Tiles
{
    public class TileModel
    {
        public TileType Type { get; private set; }
        public MeshRenderer Renderer { get; set; }
        public Color DefaultColor { get; set; }
        public Color SelectedColor { get; set; }
        public bool Selected { get; set; }

        public TileModel(TileType type)
        {
            Type = type;
            Selected = false;
        }
    }
}
