using App.Signals;
using UnityEngine;

namespace App.Gameplay.Controllers
{
    public class BrickController : MonoBehaviour
    {
        [Inject] public BrickDestroyedSignal BrickDestroyedSignal { get; private set; }

        public void OnHit()
        {
            BrickDestroyedSignal.Dispatch();
            Destroy(gameObject);
        }
    }
}