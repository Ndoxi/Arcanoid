using App.Gameplay.Controllers;
using App.ResourcesLoaders;
using strange.extensions.injector.api;
using UnityEngine;

namespace App.LevelBuilder
{
    public class Builder : ILevelBuilder
    {
        private const string PaddlePrefabKey = "Entities/Paddle";
        private const string BallPrefabKey = "Entities/Ball";
        private const string BrickPrefabKey = "Entities/Brick";

        [Inject] public IResourcesLoader ResourcesLoader { get; private set; }
        [Inject] public IInjector Injector { get; private set; }

        private PaddleController _paddlePrefab;
        private BallController _ballPrefab;
        private BrickController _brickPrefab;

        [PostConstruct]
        public void Init()
        {
            _paddlePrefab = ResourcesLoader.Load<PaddleController>(PaddlePrefabKey);
            _ballPrefab = ResourcesLoader.Load<BallController>(BallPrefabKey);
            _brickPrefab = ResourcesLoader.Load<BrickController>(BrickPrefabKey);
        }

        public void Load()
        {
            CreateObject(_paddlePrefab);
            CreateObject(_ballPrefab);
            CreateObject(_brickPrefab);
        }

        public void Unload()
        {

        }

        private T CreateObject<T>(T prefab) where T : Object
        {
            var @object = Object.Instantiate(prefab);
            return Injector.Inject(@object) as T;
        }
    }
}