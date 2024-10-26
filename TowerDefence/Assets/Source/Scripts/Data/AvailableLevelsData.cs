using System.Collections.Generic;
using UnityEngine;

namespace Assets.Source.Scripts.Data
{
	[CreateAssetMenu(menuName = "Data/Available Levels", fileName = "AvailableLevelsData")]
	public class AvailableLevelsData : ScriptableObject
	{
		[field: SerializeField] public List<LevelDataConfig> Levels { get; private set; }
		[field: SerializeField] public string LevelButtonId { get; private set; }
		[field: SerializeField] public int ClearedLevels { get; private set; } = 0; // В идеале конечно JSON

		public LevelDataConfig CurrentLevel {  get; private set; }

		public void ClearLevel(LevelDataConfig level)
		{
			if (Levels.IndexOf(level) < ClearedLevels)
				return;

			ClearedLevels++;
		}

		public void NextLevel()
		{
			if (Levels.IndexOf(CurrentLevel) >= Levels.Count)
				return;

			CurrentLevel = Levels[Levels.IndexOf(CurrentLevel) + 1];
		}

		public void SetCurrentLevel(LevelDataConfig level)
		{
			CurrentLevel = level;
		}
	}
}
