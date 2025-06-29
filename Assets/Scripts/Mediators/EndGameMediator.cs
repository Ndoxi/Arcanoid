using App.Views;
using strange.extensions.mediation.impl;
using App.Signals;
using App.Gameplay;
using System;

namespace App.Mediators
{
    public class EndGameMediator : Mediator
    {
        [Inject] public EndGameView View { get; private set; }
        [Inject] public CompleteLevelSignal CompleteLevelSignal { get; private set; }
        [Inject] public LoadLevelSignal LoadLevelSignal { get; private set; }
        [Inject] public LoadMainMenuSignal LoadMainMenuSignal { get; private set; }

        public override void OnRegister()
        {
            base.OnRegister();

            View.Hide();

            View.OnTryAgain += TryAgain;
            View.OnBackClick += ReturnToMainMenu;
            CompleteLevelSignal.AddListener(ShowView);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            View.OnTryAgain -= TryAgain;
            View.OnBackClick -= ReturnToMainMenu;
            CompleteLevelSignal.RemoveListener(ShowView);
        }

        private void ShowView(LevelProgressTracker.LevelResult levelResult)
        {
            View.Show(levelResult);
        }

        private void HideView()
        {
            View.Hide();
        }

        private void TryAgain()
        {
            HideView();
            LoadLevelSignal.Dispatch();
        }

        private void ReturnToMainMenu()
        {
            HideView();
            LoadMainMenuSignal.Dispatch();
        }
    }
}