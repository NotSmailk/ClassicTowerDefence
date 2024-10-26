using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.UI.LevelEndPanel;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Tiles
{
    public class TileController : ILateDisposable
    {
        public delegate void TileClicked(TileController controller, Vector3 position);
        public event TileClicked OnTileClickEvent;

        private TileView _view;
        private TileModel _model;

        [Inject] private LevelEndController _levelEndController;

        public TileController(TileView view, TileModel model)
        {
            _view = view;
            _model = model;

            _view.Connect(model);
            _view.OnPointerClickEvent += OnTileClick;
        }

        public void LateDispose()
        {
            _view.OnPointerClickEvent -= OnTileClick;
        }

        public void Select()
        {
            _model.Selected = true;
            _view.Select(_model.Selected);
        }

        public void Deselect()
        {
            _model.Selected = false;
            _view.Select(_model.Selected);
        }

        public void OnTileClick()
        {
            if (_levelEndController.Paused)
                return;

            if (_model.Type.Equals(TileType.None))
            {
                OnTileClickEvent?.Invoke(this, _view.transform.position);
            }
        }
    }
}
