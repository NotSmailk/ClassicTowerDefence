using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers.MachineGun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Entities.Towers.Sniper
{
    public class SniperView : TowerView
    {
        public override TowerController CreateController(DiContainer container, TowerDataConfig config)
        {
            return container.Instantiate<SniperController>(new object[] { this, new SniperModel(config) });
        }
    }
}
