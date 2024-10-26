using Assets.Source.Scripts.Entities.Enemies;
using Assets.Source.Scripts.UI.GameDataPanel;
using Assets.Source.Scripts.UI.LevelEndPanel;
using ModestTree;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Game.Systems
{
    public class EnemyEntityHandlerSystem : IInitializable, IDisposable, ITickable
    {
        public delegate void EnemyDestroyed(int reward);
        public event EnemyDestroyed OnEnemyDestroyed;

        [Inject] private EnemySpawnSystem _enemySpawnSystem;
        [Inject] private LevelEndController _levelEndController;
        [Inject] private DiContainer Container;
        [Inject] private GameDataController _gameData;

        private Dictionary<string, EnemyController> _contollers;
        private int _count;

        public void Initialize()
        {
            _contollers = new Dictionary<string, EnemyController>();

            _enemySpawnSystem.OnEnemySpawn += AddController;
        }

        public void Dispose()
        {
            _enemySpawnSystem.OnEnemySpawn -= AddController;
        }

        public void AddController(EnemyController controller)
        {
            controller.Name = $"{controller.Name}:{_count++}";
            controller.OnEnemyDestoyed += RemoveController;
            _contollers.Add(controller.Name, controller);
        }

        public void RemoveController(EnemyController controller)
        {
            _contollers.RemoveWithConfirm(controller.Name);
            _gameData.AddCurrency(controller.Reward);

			CheckWavesEnded();
		}

        public void CheckWavesEnded()
        {
			if (_contollers.Count <= 0 && _enemySpawnSystem.WavesEnded)
				_levelEndController.Victory();
		}

        public EnemyController GetController(string name)
		{
            if (_contollers.ContainsKey(name))
			    return _contollers[name];

            return null;
		}

        public void Tick()
        {
            if (_levelEndController.Paused) 
                return;

            foreach (var controller in _contollers.Values)
            {
                controller.GameUpdate();
            }
        }
    }
}
