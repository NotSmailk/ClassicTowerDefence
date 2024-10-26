using Assets.Source.Scripts.UI.LevelEndPanel;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.Source.Scripts.Game.Systems
{
	public interface IClickable
	{
		public void OnClick();
	}

	public class GameObjectClickerSystem : ITickable
	{
		[Inject] private LevelInterfaceSystem _levelInterfaceSystem;
		[Inject] private LevelEndController _levelEndController;

		public void Tick()
		{
			if (_levelEndController.Paused)
				return;

			bool click = false;

#if UNITY_ANDROID
			click = Input.touchCount > 0;
#elif UNITY_STANDALONE
			click = Input.GetMouseButtonDown(0);
#endif

			if (click)
			{
				PointerEventData eventData = new PointerEventData(EventSystem.current);
				eventData.position = Input.mousePosition;

				List<RaycastResult> raysastResults = new List<RaycastResult>();
				EventSystem.current.RaycastAll(eventData, raysastResults);

				foreach (var ray in raysastResults)
				{
					if (ray.gameObject.TryGetComponent(out IClickable clickable))
					{
						clickable.OnClick();
						break;
					}
				}

				if (raysastResults.Count <= 0)
					_levelInterfaceSystem.DeactivatePanels();
			}			
		}
	}
}
