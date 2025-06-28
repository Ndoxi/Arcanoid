using UnityEngine;

namespace App.ResourcesLoaders
{
    public interface IResourcesLoader
    {
        T Load<T>(string key) where T : Object;
    }
}