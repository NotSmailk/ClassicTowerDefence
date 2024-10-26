using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Available Towers", fileName = "AvailablesTowersData")]
    public class AvailableTowersData : ScriptableObject
    {
        [field: SerializeField] public TowerDataConfig[] Towers { get; private set; }
        [field: SerializeField] public string TowerButtonId { get; private set; }
    }
}
