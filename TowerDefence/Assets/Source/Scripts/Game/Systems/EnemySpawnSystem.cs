using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Enemies;
using Assets.Source.Scripts.Factories;
using Assets.Source.Scripts.Utilities;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Assets.Source.Scripts.Game.Systems
{
    public class EnemySpawnSystem : IInitializable, ITickable
    {
        public delegate void EnemySpawnEventHandler(EnemyController controller);
        public event EnemySpawnEventHandler OnEnemySpawn;

        [Inject] private AvailableLevelsData _levelConfig;
        [Inject] private IEnemiesFactory _enemiesFactory;
        [Inject] private EnemyEntityHandlerSystem _enemyEntityHandlerSystem;

        private CountdownTimer _countdownTimer;
        private int _currentWaveIndex;
        private List<EnemyWaveDetail> _details;
        private Transform _content;

        public bool WavesEnded { get; private set; }

        public EnemySpawnSystem(Transform content)
        {
            _currentWaveIndex = 0;
            _content = content;
            _details = new List<EnemyWaveDetail>();
            WavesEnded = false;
        }

        public async void Initialize()
        {
            _countdownTimer = new CountdownTimer(_levelConfig.CurrentLevel.Waves[_currentWaveIndex].Cooldown);
            await _enemiesFactory.InitDictionary(_levelConfig.CurrentLevel);

            InitDetails(_levelConfig.CurrentLevel.Waves[_currentWaveIndex]);
        }

        public void SetEnemySpawnPosition(Vector3 pos)
        {
            _content.position = pos;
        }

        private void InitDetails(EnemyWaveDataConfig wave)
        {
            foreach (var detail in wave.Details)
                _details.Add(new EnemyWaveDetail(detail));
        }

        private void ResetDetails()
        {
            _details.Clear();
        }

        public void Tick()
        {
            _countdownTimer.Tick(Time.deltaTime);

            if (_countdownTimer.Over)
            {
                if (GetRandomDetail(out EnemyWaveDetail detail))
                {
                    OnEnemySpawn?.Invoke(_enemiesFactory.Get(detail.Data));
                    detail.Amount--;
                }
                else
                {
                    if (_levelConfig.CurrentLevel.Waves.Length <= ++_currentWaveIndex)
					{
						WavesEnded = true;
						_enemyEntityHandlerSystem.CheckWavesEnded();
						return;
					}

					InitDetails(_levelConfig.CurrentLevel.Waves[_currentWaveIndex]);
                }

                _countdownTimer.Stop();
                _countdownTimer.Start(_levelConfig.CurrentLevel.Waves[_currentWaveIndex].Cooldown);
            }
        }

        private bool GetRandomDetail(out EnemyWaveDetail detail)
        {
            detail = default;
            if (_details.Count == 0)
                return false;

            int index = Random.Range(0, _details.Count);

            if (_details[index].Amount <= 0)
            {
                _details.RemoveAt(index);
                return GetRandomDetail(out detail);
            }

            detail = _details[index];
            return true;
        }
    }
}
