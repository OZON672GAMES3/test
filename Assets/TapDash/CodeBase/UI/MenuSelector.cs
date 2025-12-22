using DG.Tweening;
using TapDash.CodeBase.Animations;
using UnityEngine;
using UnityEngine.UI;

namespace TapDash.CodeBase.UI
{
    public class MenuSelector : MonoBehaviour
    {
        [Header("Canvas Groups")]
        [SerializeField] private CanvasGroup _optionsPanel;
        [SerializeField] private CanvasGroup _menuPanel;
        [SerializeField] private CanvasGroup _levelsPanel;
   
        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _backLevel;
        [SerializeField] private Button _backOptions;
        
        private UITransitionAnimator _animator;
        private CanvasGroup[] _panels;

        private void Awake()
        {
            _animator = new UITransitionAnimator();
            _panels = new[] { _menuPanel, _optionsPanel, _levelsPanel };
        }

        private void Start()
        {
            _playButton.onClick.AddListener(() => ShowPanel(_levelsPanel));
            _optionsButton.onClick.AddListener(() => ShowPanel(_optionsPanel));
            _backLevel.onClick.AddListener(() => ShowPanel(_menuPanel));
            _backOptions.onClick.AddListener(() => ShowPanel(_menuPanel));
        }

        private void ShowPanel(CanvasGroup targetPanel)
        {
            foreach (CanvasGroup group in _panels)
            {
                if (group == targetPanel)
                    _animator.ShowPanel(group, (RectTransform)group.transform, 0.5f, Ease.OutBack);
                else
                    _animator.HidePanel(group, (RectTransform)group.transform, 0.5f, Ease.InBack);
            }
        }

        public void ShowLevelSelector()
        {
            ShowPanel(_levelsPanel);
        }

        public void CloseLevelsPanelOnStart()
        {
            foreach (CanvasGroup group in _panels)
                _animator.HidePanel(group, (RectTransform)group.transform, 0.5f, Ease.Linear);
        }
    }
}