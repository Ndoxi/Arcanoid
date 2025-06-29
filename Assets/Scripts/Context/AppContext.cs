using App.Commands;
using App.Signals;
using UnityEngine;
using App.StateMachines;
using System;
using App.LevelBuilder;
using App.ResourcesLoaders;
using App.Input;
using App.Gameplay;

namespace App.Context
{
    public class AppContext : BaseContext
    {
        public AppContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            BindResourcesLoader();
            BindSignals();
            BindProgressTracker();
            BindLevelBuilder();
            BindAppStateMachine();
            BindCommands();
            BindInputReader();
        }

        public override void Launch()
        {
            base.Launch();

            var signal = injectionBinder.GetInstance<AppStartSignal>();
            signal.Dispatch();
        }

        private void BindResourcesLoader()
        {
            injectionBinder.Bind<IResourcesLoader>().To<LocalResourcesLoader>().ToSingleton().CrossContext();
        }

        private void BindSignals()
        {
            injectionBinder.Bind<AppStartSignal>().ToSingleton().CrossContext(); 
            injectionBinder.Bind<LoadMainMenuSignal>().ToSingleton().CrossContext(); 
            injectionBinder.Bind<MainMenuEnteredSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ExitMainMenuSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<MainMenuExitedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<GameplayEnteredSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<GameplayExitedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadLevelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<UnloadLevelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LevelLoadedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LevelUnloadedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<CompleteLevelSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<PauseSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<RequestPauseSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ResumeSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<RequestResumeSignal>().ToSingleton().CrossContext();
        }

        private void BindAppStateMachine()
        {
            injectionBinder.Bind<MenuState>().To<MenuState>();
            injectionBinder.Bind<LoadingState>().To<LoadingState>();
            injectionBinder.Bind<GameplayState>().To<GameplayState>();
            injectionBinder.Bind<PauseState>().To<PauseState>();
            injectionBinder.Bind<UnloadingState>().To<UnloadingState>();

            injectionBinder.Bind<IStateMachine>().To<AppStateMachine>().ToSingleton().CrossContext();
        }

        private void BindCommands()
        {
            commandBinder.Bind<AppStartSignal>().To<EnterMainMenuCommand>().Once();
        }

        private void BindProgressTracker()
        {
            injectionBinder.Bind<LevelProgressTracker>().To<LevelProgressTracker>().ToSingleton().CrossContext();
        }

        private void BindLevelBuilder()
        {
            injectionBinder.Bind<ILevelBuilder>().To<Builder>().ToSingleton().CrossContext();
        }

        private void BindInputReader()
        {
            injectionBinder.Bind<IInputReader>().To<InputReader>().ToSingleton().CrossContext();
        }
    }
}