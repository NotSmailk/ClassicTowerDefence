using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Assets.Source.Scripts.Assets
{
    public class AddressablesAssetsLoader
    {
        public async Task LoadComponent<T>(string id, Action<T> callback)
        {
            var op = Addressables.LoadAssetAsync<GameObject>(id);

            await op.Task;

            if (op.Result.TryGetComponent(out T instance))
            {
                callback(instance);
            }
            else
            {
                throw new Exception($"There is no {typeof(T)} component on object or {typeof(T)} isn't component at all");
            }
        }

        public async Task<T> LoadComponent<T>(string id) 
        {
            var op = Addressables.LoadAssetAsync<GameObject>(id);

            await op.Task;

            if (op.Result.TryGetComponent(out T instance))
            {
                return instance;
            }
            else
            {
                throw new Exception($"There is no {typeof(T)} component on object or {typeof(T)} isn't component at all");
            }
        }
    }
}
