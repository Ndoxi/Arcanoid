using App.Gameplay.CollisionDetectors;
using UnityEngine;

namespace App.Gameplay.Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BrickCollisionDetector2D))]
    public class BallController : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;
        private BrickCollisionDetector2D _collisionDetector;
        private bool _state;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collisionDetector = GetComponent<BrickCollisionDetector2D>();
        }

        private void OnEnable()
        {
            _collisionDetector.OnEnter += OnHit;
        }

        private void OnDisable()
        {
            _collisionDetector.OnEnter -= OnHit;
        }

        public void Launch()
        {
            if (_state)
                return;

            SetStateInternal(true);
            _rigidbody.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1f).normalized * _speed;
        }

        public void SetState(bool isActive)
        {
            SetStateInternal(isActive);
        }

        private void OnHit(BrickController brick, Collision2D collision)
        {
            brick.OnHit();
        }

        private void SetStateInternal(bool isActive)
        {
            if (isActive == _state)
                return;

            _state = isActive;
            _rigidbody.simulated = _state;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (Mathf.Abs(_rigidbody.linearVelocity.y) < 0.2f)
                _rigidbody.linearVelocity += Vector2.up * 0.5f;
        }
    }
}