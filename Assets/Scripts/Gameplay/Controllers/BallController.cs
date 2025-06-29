using App.Gameplay.CollisionDetectors;
using App.Signals;
using UnityEngine;

namespace App.Gameplay.Controllers
{
    [RequireComponent(typeof(Rigidbody2D), typeof(BrickCollisionDetector2D))]
    public class BallController : MonoBehaviour
    {
        [Inject] public BallDestroyedSignal BallDestroyedSignal { get; private set; }
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;
        private BrickCollisionDetector2D _collisionDetector;
        private bool _state = true;
        private Vector2 _currentDirection;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collisionDetector = GetComponent<BrickCollisionDetector2D>();
        }

        private void OnEnable()
        {
            _collisionDetector.OnEnter += OnHitBrick;
        }

        private void OnDisable()
        {
            _collisionDetector.OnEnter -= OnHitBrick;
        }

        public void Launch()
        {
            if (_state)
                return;

            SetStateInternal(true);

            var direction = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
            SetDirection(direction);
        }

        public void SetState(bool isActive)
        {
            SetStateInternal(isActive);
        }

        public void Kill()
        {
            BallDestroyedSignal.Dispatch();
            Destroy(gameObject);
        } 

        private void OnHitBrick(BrickController brick, Collision2D collision)
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

        private void FixedUpdate()
        {
            _rigidbody.linearVelocity = _currentDirection.normalized * _speed;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            SetDirection(CalculateBounce(collision));
        }

        private void SetDirection(Vector2 direction)
        {
            var force = direction.normalized * _speed;

            _rigidbody.linearVelocity = force;
            _currentDirection = direction.normalized;
        }

        private Vector2 CalculateBounce(Collision2D collision)
        {
            Vector2 normal = collision.GetContact(0).normal;
            var currentDirection = Vector2.Reflect(_currentDirection.normalized, normal);

            float randomDeviation = Random.Range(-0.1f, 0.1f);
            currentDirection = Quaternion.Euler(0, 0, randomDeviation) * currentDirection;

            return currentDirection;
        }
    }
}