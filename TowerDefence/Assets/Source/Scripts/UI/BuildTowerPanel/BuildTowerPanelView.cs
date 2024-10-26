using UnityEngine;

namespace Assets.Source.Scripts.UI.BuildTowerPanel
{
    public class BuildTowerPanelView : MonoBehaviour
    {
        [SerializeField] private RectTransform _content;

        public void AddButton(BuildTowerButton button)
        {
            button.transform.SetParent(_content, false);
        }

        public void Show(bool show)
        {
            gameObject.SetActive(show);
        }
    }
}
