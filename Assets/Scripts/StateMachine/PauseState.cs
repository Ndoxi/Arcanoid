using App.Signals;

namespace App.StateMachines
{
    public class PauseState : IState
    {
        [Inject] public PauseSignal PauseSignal { get; private set; }
        [Inject] public ResumeSignal ResumeSignal { get; private set; }

        public void Enter() 
        {
            PauseSignal.Dispatch();
        }

        public void Exit() 
        {
            ResumeSignal.Dispatch();
        }
    }
}