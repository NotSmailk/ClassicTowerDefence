using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Game.Systems;
using DG.Tweening;
using UnityEngine;

namespace Assets.Source.Scripts.Tiles
{
	public class TileView : MonoBehaviour, IClickable
    {
        [SerializeField] private MeshRenderer _renderer;

        public delegate void OnPointerClickHandler();
        public event OnPointerClickHandler OnPointerClickEvent;

        private TileModel _model;

        public TileType Type => _model.Type;

        public void Connect(TileModel model)
        {
            _model = model;
            _model.DefaultColor = _renderer.material.color;
            _model.SelectedColor = Color.yellow;
        }

        public void Select(bool select)
        {
            var color = select ? _model.SelectedColor : _model.DefaultColor;
            _renderer.material.DOColor(color, 0.1f);
        }

        public void OnClick()
        {
            if (Type.Equals(TileType.Tower))
                return;

            OnPointerClickEvent?.Invoke();
        }
    }
}
