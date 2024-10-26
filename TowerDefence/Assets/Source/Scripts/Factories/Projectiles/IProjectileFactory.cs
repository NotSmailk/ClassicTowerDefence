using Assets.Source.Scripts.Entities.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Source.Scripts.Factories.Projectiles
{
	public interface IProjectileFactory
	{
		public Projectile Get(string id);
	}
}
