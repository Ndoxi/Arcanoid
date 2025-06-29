using App.Signals;
using strange.extensions.command.impl;

namespace App.Commands
{
    public class FinalizeLevelCommand : Command
    {
        [Inject] public UnloadLevelSignal UnloadLevelSignal { get; private set; }

        public override void Execute()
        {
            UnloadLevelSignal.Dispatch();
        }
    }
}