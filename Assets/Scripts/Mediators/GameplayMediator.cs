using App.Views;
using App.Signals;
using strange.extensions.mediation.impl;
using System;

namespace App.Mediators
{
    public class GameplayMediator : Mediator
    {
        [Inject] public GameplayView View { get; private set; }
        [Inject] public RequestPauseSignal RequestPauseSignal { get; private set; }
        [Inject] public LevelLoadedSignal LevelLoadedSignal { get; private set; }
        [Inject] public GameplayEnteredSignal GameplayEnteredSignal { get; private set; }
        [Inject] public GameplayExitedSignal GameplayExitedSignal { get; private set; }

        public override void OnRegister()
        {
            base.OnRegister();

            View.OnPauseClick += EnterPause;
            LevelLoadedSignal.AddListener(ShowTooltip);
            GameplayEnteredSignal.AddListener(SetFocused);
            GameplayExitedSignal.AddListener(SetUnfocused);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            View.OnPauseClick -= EnterPause;
            LevelLoadedSignal.RemoveListener(ShowTooltip);
            GameplayEnteredSignal.RemoveListener(SetFocused);
            GameplayExitedSignal.RemoveListener(SetUnfocused);
        }

        private void EnterPause()
        {
            RequestPauseSignal.Dispatch();
        }

        private void ShowTooltip()
        {
            View.ShowTooltip();
        }

        private void SetFocused()
        {
            View.Focused = true;
        }

        private void SetUnfocused()
        {
            View.Focused = false;
        }
    }
}