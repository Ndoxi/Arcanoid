using App.Signals;

namespace App.StateMachines
{
    public class MenuState : IState
    {
        [Inject] public MainMenuEnteredSignal MainMenuEnteredSignal { get; private set; }
        [Inject] public MainMenuExitedSignal MainMenuExitedSignal { get; private set; }

        public void Enter() 
        {
            MainMenuEnteredSignal.Dispatch();
        }

        public void Exit() 
        {
            MainMenuExitedSignal.Dispatch();
        }
    }
}