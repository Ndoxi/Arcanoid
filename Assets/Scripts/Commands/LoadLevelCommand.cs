using App.StateMachines;
using strange.extensions.command.impl;

namespace App.Commands
{
    public class LoadLevelCommand : Command
    {
        [Inject] public IStateMachine StateMachine { get; private set; }
        
        public override void Execute()
        {
            StateMachine.ChangeState<LoadingState>();
        }
    }
}