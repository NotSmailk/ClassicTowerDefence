using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/TowerUpgrade", fileName = "TowerUpgradeDataConfig")]
    public class TowerUpgradeDataConfig : ScriptableObject
    {
        [field: SerializeField] public int Price { get; private set; }
        [field: SerializeField] public int DamageIncreaseValue { get; private set; }
        [field: SerializeField] public int RangeIncreaseValue { get; private set; }
        [field: SerializeField] public int FirerateIncreaseValue { get; private set; }
    }
}
