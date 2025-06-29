using App.Gameplay;
using strange.extensions.mediation.impl;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Views
{
    public class EndGameView : View
    {
        public event Action OnTryAgain;
        public event Action OnBackClick;

        [SerializeField] private RectTransform _childRoot;
        [SerializeField] private Button _tryAgainButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private ResultView _winRoot;
        [SerializeField] private ResultView _loseRoot;


        protected override void OnEnable()
        {
            base.OnEnable();

            _tryAgainButton.onClick.AddListener(TryAgain);
            _backButton.onClick.AddListener(Back);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _tryAgainButton.onClick.RemoveListener(TryAgain);
            _backButton.onClick.RemoveListener(Back);
        }

        public void Show(LevelProgressTracker.LevelResult levelResult)
        {
            _childRoot.gameObject.SetActive(true);

            if (levelResult == LevelProgressTracker.LevelResult.Win)
            {
                _winRoot.Show();
                _loseRoot.Hide();
            }
            else
            {
                _winRoot.Hide();
                _loseRoot.Show();
            }
        }

        public void Hide()
        {
            _childRoot.gameObject.SetActive(false);
        }

        private void TryAgain()
        {
            OnTryAgain?.Invoke();
        }

        private void Back()
        {
            OnBackClick?.Invoke();
        }
    }
}