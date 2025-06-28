using App.LevelBuilder;
using App.Signals;

namespace App.StateMachines
{
    public class UnloadingState : IState
    {
        [Inject] public ILevelBuilder LevelBuilder { get; private set; }
        [Inject] public LevelUnloadedSignal LevelUnloadedSignal { get; private set; }

        public void Enter() 
        {
            LevelBuilder.Unload();
            LevelUnloadedSignal.Dispatch();
        }

        public void Exit() { }
    }
}