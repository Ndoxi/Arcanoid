using UnityEngine;

namespace App.Context
{
    public class ContextWeaver : MonoBehaviour
    {
        [SerializeField] private ContextRootView[] _contexts;

        private void Awake()
        {
            foreach (var context in _contexts)
                context.Init();
        }
    }
}