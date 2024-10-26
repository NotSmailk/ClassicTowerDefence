using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers;
using UnityEngine;
namespace Assets.Source.Scripts.Factories.Towers
{
    public interface ITowersFactory
    {
        public TowerController Get(TowerDataConfig config, Vector3 position);
    }
}
