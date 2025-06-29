using App.Signals;

namespace App.StateMachines
{
    public class GameplayState : IState
    {
        [Inject] public GameplayEnteredSignal GameplayEnteredSignal { get; private set; }
        [Inject] public GameplayExitedSignal GameplayExitedSignal { get; private set; }

        public void Enter() 
        {
            GameplayEnteredSignal.Dispatch();
        }

        public void Exit() 
        {
            GameplayExitedSignal.Dispatch();
        }
    }
}