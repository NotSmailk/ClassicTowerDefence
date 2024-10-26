using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Scripts.UI.BuildTowerPanel
{
    public class BuildTowerPanelModel
    {
        public List<BuildTowerButton> buttons;
        public BuildTowerButton buttonPrefab;

        public BuildTowerPanelModel()
        {
            buttons = new List<BuildTowerButton>();
        }
    }
}
