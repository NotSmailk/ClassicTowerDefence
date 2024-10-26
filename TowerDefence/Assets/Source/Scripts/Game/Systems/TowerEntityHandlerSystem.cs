using Assets.Source.Scripts.Entities.Towers;
using Assets.Source.Scripts.UI.LevelEndPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Source.Scripts.Game.Systems
{
    public class TowerEntityHandlerSystem : ITickable
    {
        private List<TowerController> _controllers;

        [Inject] private LevelEndController _levelEndController;

        public TowerEntityHandlerSystem()
        {
            _controllers = new List<TowerController>();
        }

        public void RegisterController(TowerController controller)
        {
            _controllers.Add(controller);
        }

        public void Tick()
        {
            if (_levelEndController.Paused)
                return;

            foreach (var controller in _controllers)
                controller.GameUpdate();
        }
    }
}
