using System;
using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/EnemyWave", fileName = "EnemyWaveDataConfig")]
    public class EnemyWaveDataConfig : ScriptableObject
    {
        [field: SerializeField] public EnemyWaveDetail[] Details { get; private set; }
        [field: SerializeField] public int Cooldown { get; private set; }
    }

    [Serializable]
    public class EnemyWaveDetail
    {
        [field: SerializeField] public EnemyDataConfig Data { get; private set; }
        [field: SerializeField] public int Amount { get; set; }

        public EnemyWaveDetail(EnemyWaveDetail detail)
        {
            Data = detail.Data;
            Amount = detail.Amount;
        }
    }
}
