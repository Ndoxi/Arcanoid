using strange.extensions.mediation.impl;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Views
{
    public class PauseView : View
    {
        public event Action OnResumeClick;
        public event Action OnExitClick;

        [SerializeField] private RectTransform _childRoot; 
        [SerializeField] private Button _resumeButton; 
        [SerializeField] private Button _exitButton;

        protected override void OnEnable()
        {
            base.OnEnable();

            _resumeButton.onClick.AddListener(ResumeGame);
            _exitButton.onClick.AddListener(ExitGame);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _resumeButton.onClick.RemoveListener(ResumeGame);
            _exitButton.onClick.RemoveListener(ExitGame);
        }

        public void Show()
        {
            _childRoot.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _childRoot.gameObject.SetActive(false);
        }

        private void ResumeGame()
        {
            OnResumeClick?.Invoke();
        }

        private void ExitGame()
        {
            OnExitClick?.Invoke();
        }
    }
}