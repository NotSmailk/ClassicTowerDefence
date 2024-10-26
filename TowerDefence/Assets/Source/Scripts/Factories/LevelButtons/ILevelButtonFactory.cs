using Assets.Source.Scripts.UI.LevelSelector;
using System;

namespace Assets.Source.Scripts.Factories.LevelButtons
{
	public interface ILevelButtonFactory
	{
		public event Action OnFactoryInitialized;
		public LevelButton Get();
	}
}
