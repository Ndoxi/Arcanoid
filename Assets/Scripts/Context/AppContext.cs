using App.Commands;
using App.Signals;
using UnityEngine;
using App.StateMachines;
using System;
using App.LevelBuilder;
using App.ResourcesLoaders;

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
            BindLevelBuilder();
            BindAppStateMachine();
            BindCommands();
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
            injectionBinder.Bind<MainMenuEnteredSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ExitMainMenuSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<MainMenuExitedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LevelLoadedSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<LevelUnloadedSignal>().ToSingleton().CrossContext();
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
            commandBinder.Bind<MainMenuExitedSignal>().To<LoadLevelCommand>();
        }

        private void BindLevelBuilder()
        {
            injectionBinder.Bind<ILevelBuilder>().To<Builder>().ToSingleton();
        }
    }
}