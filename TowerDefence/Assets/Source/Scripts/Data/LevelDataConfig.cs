using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Level", fileName = "LevelDataConfig")]
    public class LevelDataConfig : ScriptableObject
    {
        [field: SerializeField] public LevelPathDataConfig Path { get; private set; }
        [field: SerializeField] public EnemyWaveDataConfig[] Waves { get; private set; }
    }
}
