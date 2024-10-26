using UnityEngine;

namespace Assets.Source.Scripts.UI.LevelSelector
{
	public class LevelSelectorView : MonoBehaviour
	{
		[SerializeField] private RectTransform _content;

		public RectTransform Content => _content;

		public void AddButton(LevelButton button)
		{
			button.transform.SetParent(_content, false);
		}
	}
}
