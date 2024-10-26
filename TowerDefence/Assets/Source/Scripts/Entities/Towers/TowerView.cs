using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Game.Systems;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Entities.Towers
{
	public abstract class TowerView : MonoBehaviour, IClickable
    {
        [SerializeField] protected Transform tower;

        public event Action OnTowerClick;

        public Transform Tower => tower;

        public abstract TowerController CreateController(DiContainer container, TowerDataConfig config); 

        public virtual void OnClick()
        {
            OnTowerClick?.Invoke();
        }

        public virtual void RotateTowerTo(Vector3 position)
        {
            Vector3 dir = position - tower.position;
            Quaternion rotation = Quaternion.LookRotation(dir);
			tower.rotation = Quaternion.Slerp(tower.rotation, rotation, 45 * Time.deltaTime);
        }
	}
}
