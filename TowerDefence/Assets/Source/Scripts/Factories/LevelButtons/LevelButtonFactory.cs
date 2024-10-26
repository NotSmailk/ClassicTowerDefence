using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.UI.LevelSelector;
using System;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Factories.LevelButtons
{
	public class LevelButtonFactory : ILevelButtonFactory
	{
		private Transform _content;
		private LevelButton _prefab;

		[Inject]
		private DiContainer _container;

		public event Action OnFactoryInitialized;

		[Inject]
		private async void Construct(AddressablesAssetsLoader loader, AvailableLevelsData levelsData)
		{
			_prefab = await loader.LoadComponent<LevelButton>(levelsData.LevelButtonId);
			OnFactoryInitialized?.Invoke();
		}

		public LevelButtonFactory(Transform content)
		{
			_content = content;
		}

		public LevelButton Get()
		{
			LevelButton button = _container.InstantiatePrefabForComponent<LevelButton>(_prefab);
			return button;
		}
	}
}
