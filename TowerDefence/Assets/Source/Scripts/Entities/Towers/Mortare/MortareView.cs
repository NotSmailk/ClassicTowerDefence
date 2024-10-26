using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Towers.MachineGun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Entities.Towers.Mortare
{
    public class MortareView : TowerView
    {
        public override TowerController CreateController(DiContainer container, TowerDataConfig config)
        {
            return container.Instantiate<MortareController>(new object[] { this, new MortareModel(config) });
        }
    }
}
