using App.Gameplay;
using App.Gameplay.Controllers;
using App.ResourcesLoaders;
using strange.extensions.injector.api;
using UnityEngine;

namespace App.LevelBuilder
{
    public partial class Builder : ILevelBuilder
    {
        private const string PaddlePrefabKey = "Entities/Paddle";
        private const string BallPrefabKey = "Entities/Ball";
        private const string BrickPrefabKey = "Entities/Brick";

        [Inject] public IResourcesLoader ResourcesLoader { get; private set; }
        [Inject] public IInjector Injector { get; private set; }
        [Inject] public LevelProgressTracker ProgressTracker { get; private set; }

        private readonly LevelScheme _scheme;
        private readonly Level _level;

        private PaddleController _paddlePrefab;
        private BallController _ballPrefab;
        private BrickController _brickPrefab;

        public Builder()
        {
            _scheme = new LevelScheme();
            _level = new Level();
        }

        [PostConstruct]
        public void Init()
        {
            _paddlePrefab = ResourcesLoader.Load<PaddleController>(PaddlePrefabKey);
            _ballPrefab = ResourcesLoader.Load<BallController>(BallPrefabKey);
            _brickPrefab = ResourcesLoader.Load<BrickController>(BrickPrefabKey);
        }

        public void Load()
        {
            var paddle = CreateObject(_paddlePrefab, _scheme.PlayerSpawnPosition);
            var ball = CreateObject(_ballPrefab, Vector2.zero);
            ball.SetState(false);
            paddle.SetCurrentBall(ball);

            int ballsCount = 1;
            int bricksCount = 0;

            foreach (var brickPosition in _scheme.BrickSpawnPositions)
            {
                var brick = CreateObject(_brickPrefab, brickPosition);
                _level.Entities.Add(brick.gameObject);
                bricksCount++;
            }

            _level.Entities.Add(paddle.gameObject);
            _level.Entities.Add(ball.gameObject);

            ProgressTracker.Init(ballsCount, bricksCount);
        }

        public void Unload()
        {
            foreach (var entity in _level.Entities)
            {
                if (entity != null)
                    DestroyObject(entity);
            }

            _level.Entities.Clear();
        }

        private T CreateObject<T>(T prefab, Vector2 position) where T : Object
        {
            var gameObject = Object.Instantiate(prefab, position, Quaternion.identity);
            return Injector.Inject(gameObject) as T;
        }

        private void DestroyObject(GameObject gameObject)
        {
            Object.Destroy(gameObject);
        }
    }
}