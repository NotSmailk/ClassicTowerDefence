using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Scripts.Data
{
	[CreateAssetMenu(menuName = "Data/Scenes", fileName = "SceneNamesData")]
	public class SceneNamesData : ScriptableObject
	{
		[field: SerializeField] public string Preloader { get; private set; } = "Preloader";
		[field: SerializeField] public string Level { get; private set; } = "Level";
	}
}
