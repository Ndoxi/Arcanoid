using strange.extensions.mediation.impl;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace App.Views
{
    public class MainMenuView : View
    {
        public event Action OnPlayButtonClick;

        [SerializeField] private RectTransform _childRoot;
        [SerializeField] private Button _playButton;

        protected override void OnEnable()
        {
            base.OnEnable();
            _playButton.onClick.AddListener(OnClick);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _playButton.onClick.RemoveListener(OnClick);
        }

        private void OnClick()
        {
            OnPlayButtonClick?.Invoke();
        }

        public void Show()
        {
            _childRoot.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _childRoot.gameObject.SetActive(false);
        }
    }
}