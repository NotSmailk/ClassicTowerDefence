using Array2DEditor;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/LevelPath", fileName = "LevelPathDataConfig")]
    public class LevelPathDataConfig : ScriptableObject
    {
        [field: SerializeField] public TileTypeEnum Map { get; private set; }
    }

    [Serializable]
    public class TileTypeEnum : Array2D<TileType>
    {
        [SerializeField] private TileTypeCell[] cells = new TileTypeCell[Consts.defaultGridSize];

        protected override CellRow<TileType> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }

    [Serializable]
    public class TileTypeCell : CellRow<TileType> { }

    public enum TileType 
    {
        None = 0,
        Player = 1,
        Tower = 2,
        EnemySpawnLeft = 10,
        EnemySpawnRight = 11,
        EnemySpawnUp = 12,
        EnemySpawnDown = 13,
        PathUp = 20,
        PathDown = 21,
        PathLeft = 22,
        PathRight = 23
    }

    public static class TileTypeExtension
    {
        private static Dictionary<TileType, Quaternion> _map = new Dictionary<TileType, Quaternion>()
        {
            { TileType.None, Quaternion.Euler(Vector3.zero) },
            { TileType.Player, Quaternion.Euler(Vector3.zero) },
            { TileType.Tower, Quaternion.Euler(Vector3.zero) },
            { TileType.EnemySpawnLeft, Quaternion.Euler(new Vector3(0f, 90f, 0f)) },
            { TileType.EnemySpawnRight, Quaternion.Euler(new Vector3(0f, 270f, 0f)) },
            { TileType.EnemySpawnUp, Quaternion.Euler(new Vector3(0f, 180f, 0f)) },
            { TileType.EnemySpawnDown, Quaternion.Euler(new Vector3(0f, 0f, 0f)) },
            { TileType.PathUp, Quaternion.Euler(new Vector3(0f, 180f, 0f)) },
            { TileType.PathDown, Quaternion.Euler(new Vector3(0f, 0f, 0f)) },
            { TileType.PathLeft, Quaternion.Euler(new Vector3(0f, 90f, 0f)) },
            { TileType.PathRight, Quaternion.Euler(new Vector3(0f, 270f, 0f)) },
        };

        public static Quaternion Rotation(this TileType tileType) => _map[tileType];
    }
}
