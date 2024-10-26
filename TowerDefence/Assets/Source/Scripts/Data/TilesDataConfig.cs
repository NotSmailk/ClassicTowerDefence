using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Tile", fileName = "TilesDataConfig")]
    public class TilesDataConfig : ScriptableObject
    {
        [SerializeField] private TileKeyValue[] _map;

        [Serializable]
        public class TileKeyValue
        {
            public TileType key;
            public string value;
        }

        public Dictionary<TileType, string> Map { get; private set; }

        private void OnValidate()
        {
            Map = new Dictionary<TileType, string>();

            foreach (TileKeyValue kv in _map)
            {
                if (Map.ContainsKey(kv.key))
                {
                    Debug.LogError($"Map already contains key: {kv.key}");
                    continue;
                }                    

                Map.Add(kv.key, kv.value);
            }
        }
    }
}
