using UnityEngine;
using UnityEngine.UI;

namespace App.Views
{
    public class ResultView : MonoBehaviour
    {
        [SerializeField] private RectTransform _childRoot;
        [SerializeField] private Button _closeButton;

        private void Awake()
        {
            Hide();
        }

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Hide);
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