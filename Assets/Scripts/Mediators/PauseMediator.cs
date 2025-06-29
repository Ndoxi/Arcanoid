using App.Views;
using App.Signals;
using strange.extensions.mediation.impl;
using System;

namespace App.Mediators
{
    public class PauseMediator : Mediator
    {
        [Inject] public PauseView View { get; private set; }
        [Inject] public PauseSignal PauseSignal { get; private set; }
        [Inject] public ResumeSignal ResumeSignal { get; private set; }
        [Inject] public RequestResumeSignal RequestResumeSignal { get; private set; }
        [Inject] public LoadMainMenuSignal LoadMainMenuSignal { get; private set; }


        public override void OnRegister()
        {
            base.OnRegister();

            HideView();

            View.OnResumeClick += ResumeGame;
            View.OnExitClick += ExitGame;
            PauseSignal.AddListener(ShowView);
            ResumeSignal.AddListener(HideView);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            View.OnResumeClick -= ResumeGame;
            View.OnExitClick -= ExitGame;
            PauseSignal.RemoveListener(ShowView);
            ResumeSignal.RemoveListener(HideView);
        }

        private void ShowView()
        {
            View.Show();
        }

        private void HideView()
        {
            View.Hide();
        }

        private void ResumeGame()
        {
            RequestResumeSignal.Dispatch();
        }

        private void ExitGame()
        {
            LoadMainMenuSignal.Dispatch();
        }
    }
}