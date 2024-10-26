using UnityEngine;

namespace Assets.Source.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Player", fileName = "PlayerDataConfig")]
    public class PlayerDataConfig : ScriptableObject
    {
        [field: SerializeField] public int Healthpoints { get; private set; }
        [field: SerializeField] public int StartCurrency { get; private set; }
    }
}