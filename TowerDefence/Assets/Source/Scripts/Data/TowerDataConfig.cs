using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Tower", fileName = "TowerDataConfig")]
    public class TowerDataConfig : ScriptableObject
    {
        [field: SerializeField] public string Id { get; private set; }
        [field: SerializeField] public string WeaponId { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; } // Можно вынести также в addressables
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float Radius { get; private set; }
        [field: SerializeField] public float Firerate { get; private set; }
        [field: SerializeField] public int EnemyCount { get; private set; }
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public TowerUpgradeDataConfig[] Upgrades { get; private set; }
    }
}
