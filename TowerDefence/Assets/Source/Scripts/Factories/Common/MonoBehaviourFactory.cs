using UnityEngine;

namespace Assets.Source.Scripts.Factories
{
    public class MonoBehaviourFactory : IFactory<MonoBehaviour>
    {
        private Transform _content;
        private MonoBehaviour _prefab;

        public MonoBehaviourFactory(Transform content, MonoBehaviour prefab)
        {
            _content = content;
            _prefab = prefab;
        }

        public MonoBehaviour Get()
        {
            MonoBehaviour instance = GameObject.Instantiate(_prefab, _content);
            return instance;
        }
    }
}
