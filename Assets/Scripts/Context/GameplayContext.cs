using App.Commands;
using App.Gameplay;
using App.Signals;
using System;
using UnityEngine;

namespace App.Context
{
    public class GameplayContext : BaseContext
    {
        public GameplayContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            BindSignals();
            BindCommands();
        }

        private void BindSignals()
        {
            injectionBinder.Bind<BallDestroyedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<BrickDestroyedSignal>().ToSingleton().CrossContext();
        }

        private void BindCommands()
        {
            commandBinder.Bind<LoadLevelSignal>().To<LoadLevelCommand>();
            commandBinder.Bind<LevelLoadedSignal>().To<StartGameplayCommand>();
            commandBinder.Bind<UnloadLevelSignal>().To<UnloadLevelCommand>();
            commandBinder.Bind<BrickDestroyedSignal>().To<UpdateBricksCountCommand>();
            commandBinder.Bind<BallDestroyedSignal>().To<UpdateBallsCountCommand>();
            commandBinder.Bind<CompleteLevelSignal>().To<FinalizeLevelCommand>();
        }
    }
}