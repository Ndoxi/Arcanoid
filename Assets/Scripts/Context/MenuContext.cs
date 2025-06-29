using App.Commands;
using App.Mediators;
using App.Signals;
using App.Views;
using UnityEngine;

namespace App.Context
{
    public class MenuContext : BaseContext
    {
        public MenuContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            mediationBinder.Bind<MainMenuView>().To<MainMenuMediator>();
            commandBinder.Bind<LoadMainMenuSignal>().To<EnterMainMenuCommand>();
        }
    }
}