using App.Commands;
using App.Signals;
using UnityEngine;

namespace App.Context
{
    public class GameplayContext : BaseContext
    {
        public GameplayContext(MonoBehaviour view) : base(view) { }

        protected override void mapBindings()
        {
            base.mapBindings();
            BindCommands();
        }

        private void BindCommands()
        {
            commandBinder.Bind<LevelLoadedSignal>().To<StartGameplayCommand>();
            commandBinder.Bind<LevelUnloadedSignal>().To<EnterMainMenuCommand>();
        }
    }
}