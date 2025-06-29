using strange.extensions.mediation.impl;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Views
{
    public class GameplayView : View
    {
        public event Action OnPauseClick;

        [SerializeField] private Button _pauseButton;
        [SerializeField] private RectTransform _inputTooltip;

        protected override void OnEnable()
        {
            base.OnEnable();

            _pauseButton.onClick.AddListener(PauseGame);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _pauseButton.onClick.RemoveListener(PauseGame);
        }

        private void PauseGame()
        {
            OnPauseClick?.Invoke();
        }
    }
}