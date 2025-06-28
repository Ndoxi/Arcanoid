using App.Commands;
using App.Signals;
using UnityEngine;
using App.StateMachines;
using strange.extensions.injector.api;

namespace App.Context
{
    public class AppContext : BaseContext
    {
        public AppContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            BindSignals();
            BindAppStateMachine();
            BindCommands();
        }

        public override void Launch()
        {
            base.Launch();

            var signal = injectionBinder.GetInstance<AppStartSignal>() as AppStartSignal;
            signal.Dispatch();
        }

        private void BindSignals()
        {
            injectionBinder.Bind<AppStartSignal>().ToSingleton().CrossContext(); 
            injectionBinder.Bind<MainMenuEnteredSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<ExitMainMenuSignal>().ToSingleton().CrossContext();
            injectionBinder.Bind<MainMenuExitedSignal>().ToSingleton().CrossContext();
        }

        private void BindAppStateMachine()
        {
            injectionBinder.Bind<MenuState>().To<MenuState>();
            injectionBinder.Bind<GameplayState>().To<GameplayState>();
            injectionBinder.Bind<PauseState>().To<PauseState>();

            injectionBinder.Bind<IStateMachine>().To<AppStateMachine>().ToSingleton().CrossContext();
        }

        private void BindCommands()
        {
            commandBinder.Bind<AppStartSignal>().To<AppStartCommand>().Once();
        }
    }
}