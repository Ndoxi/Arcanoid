using App.Input;
using strange.extensions.mediation.impl;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace App.Views
{
    public class GameplayView : View
    {
        public event Action OnPauseClick;

        public bool Focused { get; set; }
        [Inject] public IInputReader InputReader { get; private set; } 

        [SerializeField] private Button _pauseButton;
        [SerializeField] private RectTransform _controlsTooltip;
        [SerializeField] private float _tooltipDuration;
        private Coroutine _tooltipCorutine;

        protected override void OnEnable()
        {
            base.OnEnable();

            _pauseButton.onClick.AddListener(PauseGame);
            _controlsTooltip.gameObject.SetActive(false);
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _pauseButton.onClick.RemoveListener(PauseGame);
        }

        private void Update()
        {
            if (Focused && InputReader.PausePressed())
                OnPauseClick?.Invoke();
        }

        private void PauseGame()
        {
            OnPauseClick?.Invoke();
        }

        public void ShowTooltip()
        {
            if (_tooltipCorutine != null)
                StopCoroutine(_tooltipCorutine);

            _tooltipCorutine = StartCoroutine(ShowTooltipCo());
        }

        private IEnumerator ShowTooltipCo()
        {
            _controlsTooltip.gameObject.SetActive(true);
            yield return new WaitForSeconds(_tooltipDuration);
            _controlsTooltip.gameObject.SetActive(false);

            _tooltipCorutine = null;
        }
    }
}