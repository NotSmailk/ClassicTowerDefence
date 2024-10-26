using Assets.Source.Scripts.UI.LevelEndPanel;
using Zenject;

namespace Assets.Source.Scripts.UI.GameDataPanel
{
	public class GameDataController
    {
        private GameDataModel _model;
        private GameDataView _view;

        [Inject] private LevelEndController _levelEndController;

        public GameDataController(GameDataView view, GameDataModel model)
        {
            _model = model;
            _view = view;

            _model.OnCurrencyChanged += _view.UpdateCurrency;
            _model.OnHealthpointsChanged += _view.UpdateHealthpoints;
            _model.OnHealthpointsChanged += OnHealthChanged;

            _view.UpdateCurrency(_model.Currency);
            _view.UpdateHealthpoints(_model.Healthpoints);
        }

        public void OnHealthChanged(int health)
        {
            if (health <= 0)
            {
                _levelEndController.Defeat();
            }
        }

        public void AddCurrency(int currency)
        {
            _model.AddCurrency(currency);
        }

        public bool TakeCurrency(int currency)
        {
            return _model.TakeCurrency(currency);
        }

        public void TakeDamage(int damage)
        {
            _model.TakeDamage(damage);
        }
    }
}
