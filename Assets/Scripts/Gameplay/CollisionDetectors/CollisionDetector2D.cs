using System;
using UnityEngine;

namespace App.Gameplay.CollisionDetectors
{
    public class CollisionDetector2D<TTarget> : MonoBehaviour where TTarget : MonoBehaviour
    {
        public event Action<TTarget, Collision2D> OnEnter;
        public event Action<TTarget, Collision2D> OnExit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.rigidbody.TryGetComponent(out TTarget target))
                OnEnter?.Invoke(target, collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.rigidbody.TryGetComponent(out TTarget target))
                OnExit?.Invoke(target, collision);
        }
    }
}