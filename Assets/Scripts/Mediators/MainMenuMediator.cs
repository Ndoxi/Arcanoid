using App.Signals;
using App.StateMachines;
using App.Views;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace App.Mediators
{
    public class MainMenuMediator : Mediator
    {
        [Inject] public MainMenuView View { get; private set; }
        [Inject] public MainMenuEnteredSignal OnEnterSignal { get; private set; }
        [Inject] public ExitMainMenuSignal ExitSignal { get; private set; }
        [Inject] public MainMenuExitedSignal OnExitSignal { get; private set; }

        public override void OnRegister()
        {
            base.OnRegister();

            View.OnPlayButtonClick += Play;
            OnEnterSignal.AddListener(ShowMenu);
            OnExitSignal.AddListener(HideMenu);
        }

        public override void OnRemove()
        {
            base.OnRemove();

            View.OnPlayButtonClick -= Play;
            OnEnterSignal.RemoveListener(ShowMenu);
            OnExitSignal.RemoveListener(HideMenu);
        }

        private void ShowMenu()
        {
            View.Show();
        }

        private void HideMenu()
        {
            View.Hide();
        }

        private void Play()
        {
            ExitSignal.Dispatch();
        }
    }
}