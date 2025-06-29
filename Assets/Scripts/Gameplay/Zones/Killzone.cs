using UnityEngine;
using App.Gameplay.CollisionDetectors;
using App.Gameplay.Controllers;
using System;

namespace App.Gameplay.Zones
{
    [RequireComponent(typeof(BallCollisionDetector2D))]
    public class Killzone : MonoBehaviour
    {
        private BallCollisionDetector2D _collisionDetector;

        private void Awake()
        {
            _collisionDetector = GetComponent<BallCollisionDetector2D>();
        }

        private void OnEnable()
        {
            _collisionDetector.OnEnter += KillBall;
        }

        private void OnDisable()
        {
            _collisionDetector.OnEnter -= KillBall;
        }

        private void KillBall(BallController ball, Collision2D collision)
        {
            ball.Kill();
        }
    }
}