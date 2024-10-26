using Assets.Source.Scripts.Assets;
using Assets.Source.Scripts.Data;
using Assets.Source.Scripts.Entities.Projectiles;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Source.Scripts.Factories.Projectiles
{
	public class ProjectileFactory : IProjectileFactory
	{
		private Transform _content;
		private Dictionary<string, Projectile> _projects;

		[Inject] private DiContainer _container;

		[Inject]
		private async void Construct(AvailableTowersData data, AddressablesAssetsLoader loader)
		{
			_projects = new Dictionary<string, Projectile>();
			foreach (var config in data.Towers)
			{
				if (config.WeaponId == "" || config.WeaponId == string.Empty || config.WeaponId == null)
					continue;

				if (_projects.ContainsKey(config.WeaponId))
					continue;

				var projectile = await loader.LoadComponent<Projectile>(config.WeaponId);
				_projects.Add(config.WeaponId, projectile);
			}
		}

		public ProjectileFactory(Transform content)
		{
			_content = content;
		}

		public Projectile Get(string id)
		{
			var instance = _container.InstantiatePrefabForComponent<Projectile>(_projects[id], _content);
			return instance;
		}
	}
}
