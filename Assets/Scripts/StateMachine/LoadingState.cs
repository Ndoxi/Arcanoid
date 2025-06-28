using App.LevelBuilder;
using App.Signals;

namespace App.StateMachines
{
    public class LoadingState : IState
    {
        [Inject] public ILevelBuilder LevelBuilder { get; private set; }
        [Inject] public LevelLoadedSignal LevelLoadedSignal { get; private set; }

        public void Enter() 
        {
            LevelBuilder.Load();
            LevelLoadedSignal.Dispatch();
        }

        public void Exit() { }
    }
}