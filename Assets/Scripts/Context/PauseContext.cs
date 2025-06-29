using App.Commands;
using App.Gameplay;
using App.Mediators;
using App.Signals;
using App.Views;
using UnityEngine;

namespace App.Context
{
    public class PauseContext : BaseContext
    {
        public PauseContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            injectionBinder.Bind<IPauseService>().To<PauseService>().ToSingleton().CrossContext();
            injectionBinder.Bind<LoadMainMenuSignal>().ToSingleton();
            commandBinder.Bind<LoadMainMenuSignal>().InSequence().To<UnloadLevelCommand>().To<EnterMainMenuCommand>();
            mediationBinder.Bind<PauseView>().To<PauseMediator>();
        }
    }
}