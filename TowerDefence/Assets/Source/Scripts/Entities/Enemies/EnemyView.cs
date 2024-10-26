using Assets.Source.Scripts.Data;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Entities.Enemies
{
    public abstract class EnemyView : MonoBehaviour
    {
        public abstract EnemyController BuildContoller(DiContainer container, EnemyDataConfig config);
    }
}
