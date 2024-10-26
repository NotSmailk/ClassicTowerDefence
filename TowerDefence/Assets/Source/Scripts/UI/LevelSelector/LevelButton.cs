using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Source.Scripts.UI.LevelSelector
{
	[RequireComponent(typeof(Button))]
	public class LevelButton : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _text;

		private Button _button;

		public string Text
		{
			get => _text.text;
			set => _text.text = value;
		}

		private Button Button
		{
			get
			{
				if (_button == null)
					_button = GetComponent<Button>();

				return _button;
			}
		}

		public void AddListener(UnityAction call)
		{
			Button.onClick.AddListener(call);
		}
	}
}
