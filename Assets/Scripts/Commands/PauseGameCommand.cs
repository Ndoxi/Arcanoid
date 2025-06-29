using App.Gameplay;
using App.StateMachines;
using strange.extensions.command.impl;

namespace App.Commands
{
    public class PauseGameCommand : Command
    {
        [Inject] public IStateMachine StateMachine { get; private set; }
        [Inject] public IPauseService PauseService { get; private set; }

        public override void Execute()
        {
            StateMachine.ChangeState<PauseState>();
            PauseService.RequestPause();
        }
    }
}