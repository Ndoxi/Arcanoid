using UnityEngine;

namespace App.ResourcesLoaders
{
    public class LocalResourcesLoader : IResourcesLoader
    {
        public T Load<T>(string key) where T : Object
        {
            return Resources.Load<T>(key);
        }
    }
}