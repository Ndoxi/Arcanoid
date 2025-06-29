using App.Views;
using App.Signals;
using strange.extensions.mediation.impl;

namespace App.Mediators
{
    public class GameplayMediator : Mediator
    {
        [Inject] public GameplayView View { get; private set; }
        [Inject] public RequestPauseSignal RequestPauseSignal { get; private set; }

        public override void OnRegister()
        {
            base.OnRegister();

            View.OnPauseClick += EnterPause;
        }

        public override void OnRemove()
        {
            base.OnRemove();

            View.OnPauseClick -= EnterPause;
        }

        private void EnterPause()
        {
            RequestPauseSignal.Dispatch();
        }
    }
}