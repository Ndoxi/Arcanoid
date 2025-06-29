using App.Views;
using App.Signals;
using strange.extensions.mediation.impl;

namespace App.Mediators
{
    public class GameplayMediator : Mediator
    {
        [Inject] public GameplayView View { get; private set; }
        [Inject] public RequestPauseSignal RequestPauseSignal { get; private set; }
        [Inject] public LevelLoadedSignal LevelLoadedSignal { get; private set; }


        public override void OnRegister()
        {
            base.OnRegister();

            View.OnPauseClick += EnterPause;
            LevelLoadedSignal.AddListener(ShowTooltip);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            View.OnPauseClick -= EnterPause;
            LevelLoadedSignal.RemoveListener(ShowTooltip);
        }

        private void EnterPause()
        {
            RequestPauseSignal.Dispatch();
        }

        private void ShowTooltip()
        {
            View.ShowTooltip();
        }
    }
}