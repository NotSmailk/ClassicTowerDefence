using Assets.Source.Scripts.Data;
using System;

namespace Assets.Source.Scripts.UI.GameDataPanel
{
	public class GameDataModel
	{
		public int Healthpoints { get; private set; }
		public int Currency { get; private set; }

		public GameDataModel(PlayerDataConfig config)
		{
			Healthpoints = config.Healthpoints;
			Currency = config.StartCurrency;
		}

		public event Action<int> OnHealthpointsChanged;
		public event Action<int> OnCurrencyChanged;

		public void TakeDamage(int health)
		{
			Healthpoints -= health;

			if (Healthpoints < 0)
				Healthpoints = 0;

			OnHealthpointsChanged?.Invoke(Healthpoints);
		}

		public void AddCurrency(int currency)
		{
			Currency += currency;

			OnCurrencyChanged?.Invoke(Currency);
		}

		public bool TakeCurrency(int currency)
		{
			int decreasedValue = Currency - currency;

			if (decreasedValue < 0)
				return false;

			Currency = decreasedValue;
			OnCurrencyChanged?.Invoke(Currency);
			return true;
		}
	}
}
