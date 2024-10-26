using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Enemy", fileName = "EnemyDataConfig")]
    public class EnemyDataConfig : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public int Healthpoints { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public int Speed { get; private set; }
        [field: SerializeField] public int Reward { get; private set; }
    }
}
