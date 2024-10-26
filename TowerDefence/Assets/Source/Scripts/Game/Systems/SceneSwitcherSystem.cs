using Assets.Source.Scripts.Data;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Source.Scripts.Game.Systems
{
	public class SceneSwitcherSystem
	{
		private string _name;

		[Inject] private AvailableLevelsData _availableLevelsData;

		public void SwitchScene(string name)
		{
			_name = name;
			SceneManager.LoadScene(name);
		}

		public void ReloadScene()
		{
			SceneManager.LoadScene(_name);
		}
	}
}
