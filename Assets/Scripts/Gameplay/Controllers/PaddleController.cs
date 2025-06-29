using App.Input;
using UnityEngine;

namespace App.Gameplay.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PaddleController : MonoBehaviour
    {
        [Inject] public IInputReader InputReader { get; private set; }
        [SerializeField] private Transform _ballPosition;
        [SerializeField] private float _speed;
        [SerializeField] private float _clampX;

        private Rigidbody2D _rigidbody;
        private BallController _currentBall;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            float movementInput = InputReader.GetMovement();
            if (!Mathf.Approximately(movementInput, 0f))
                ProcessMovement(movementInput, Time.deltaTime);
            if (InputReader.LaunchPressed())
                LaunchCurrentBall();
        }

        public void SetCurrentBall(BallController ball)
        {
            _currentBall = ball;
            ball.transform.SetParent(transform);
            ball.transform.position = _ballPosition.position;
        }

        private void ProcessMovement(float input, float deltaTime)
        {
            var direction = Vector2.right;
            var delta = _speed * deltaTime * input * direction;
            var newPos = _rigidbody.position + delta;
            newPos.x = Mathf.Clamp(newPos.x, -1 * _clampX, _clampX);

            _rigidbody.MovePosition(newPos);
        }

        private void LaunchCurrentBall()
        {
            if (_currentBall == null)
                return;

            _currentBall.Launch();
            _currentBall = null;
        }
    }
}