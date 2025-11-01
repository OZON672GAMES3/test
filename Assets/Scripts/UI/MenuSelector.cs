using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MenuSelector : MonoBehaviour
    {
        [Header("Canvas Groups")]
        [SerializeField] private CanvasGroup _optionsPanel;
        [SerializeField] private CanvasGroup _menuPanel;
        [SerializeField] private CanvasGroup _levelsPanel;
        
        [Header("Rects")]
        [SerializeField] private RectTransform _menuPanelRect;
        [SerializeField] private RectTransform _levelsPanelRect;
        [SerializeField] private RectTransform _optionsPanelRect;

        [Header("Buttons")]
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _optionsButton;
        [SerializeField] private Button _backLevel;
        [SerializeField] private Button _backOptions;
        
        private Vector2 _defaultPositions;
        

        private void Start()
        {
            _defaultPositions = _menuPanelRect.anchoredPosition;
            
            _playButton.onClick.AddListener(ShowLevelsPanel);
            _optionsButton.onClick.AddListener(ShowOptionsPanel);
            _backOptions.onClick.AddListener(ShowMainMenuPanel);
            _backLevel.onClick.AddListener(ShowMainMenuPanel);
        }

        public void CloseLevelsPanel(int _)
        {
            _levelsPanel.DOFade(0, 0.5f).SetEase(Ease.OutBack);
            _levelsPanelRect.DOAnchorPos(new Vector2(0, 1000f), 0.5f).SetEase(Ease.OutBack);
        }

        private void ShowMainMenuPanel()
        {
            _menuPanelRect.anchoredPosition = _defaultPositions + new Vector2(0, 1000f);
            _menuPanelRect.DOAnchorPos(_defaultPositions, 0.5f).SetEase(Ease.OutBack);
            _menuPanel.DOFade(1, 0.5f).SetEase(Ease.OutBack);
            
            _optionsPanel.DOFade(0, 0.5f).SetEase(Ease.OutBack);
            _levelsPanel.DOFade(0, 0.5f).SetEase(Ease.OutBack);
            OffCanvasGroup(_optionsPanel);
            OffCanvasGroup(_levelsPanel);
            EnableCanvasGroup(_menuPanel);
        }

        private void ShowOptionsPanel()
        {
            _optionsPanelRect.anchoredPosition = _defaultPositions + new Vector2(0, 1000f);
            _optionsPanelRect.DOAnchorPos(_defaultPositions, 0.5f).SetEase(Ease.OutBack);
            _optionsPanel.DOFade(1, 0.5f).SetEase(Ease.OutBack);
            
            _menuPanel.DOFade(0, 0.5f).SetEase(Ease.OutBack);
            _levelsPanel.DOFade(0, 0.5f).SetEase(Ease.OutBack);
            OffCanvasGroup(_menuPanel);
            OffCanvasGroup(_levelsPanel);
            EnableCanvasGroup(_optionsPanel);
        }

        private void ShowLevelsPanel()
        {
            _levelsPanelRect.anchoredPosition = _defaultPositions + new Vector2(0, 1000f);
            _levelsPanelRect.DOAnchorPos(_defaultPositions, 0.5f).SetEase(Ease.OutBack);
            _levelsPanel.DOFade(1, 0.5f).SetEase(Ease.OutBack);

            _menuPanel.DOFade(0, 0.5f).SetEase(Ease.OutBack);
            _optionsPanel.DOFade(0, 0.5f).SetEase(Ease.OutBack);
            OffCanvasGroup(_menuPanel);
            OffCanvasGroup(_optionsPanel);
            EnableCanvasGroup(_levelsPanel);
        }
        
        private void OffCanvasGroup (CanvasGroup panel)
        {
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }

        private void EnableCanvasGroup(CanvasGroup canvasGroup)
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}