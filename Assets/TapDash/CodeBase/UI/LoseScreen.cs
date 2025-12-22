using TapDash.CodeBase.Animations;
using TapDash.CodeBase.Infrastructure.Services.LevelRestart;
using UnityEngine;
using UnityEngine.UI;

namespace TapDash.CodeBase.UI
{
    public class LoseScreen : MonoBehaviour
    {
        public Button RestartButton;
        public Button LevelSelectorButton;
        
        public RectTransform ButtonContainer;
        public RectTransform Panel;
        
        public float Duration;
        
        private ILevelRestartService _levelRestart;
        private MenuSelector _levelSelector;
        private readonly UITransitionAnimator _animator = new();

        public void Construct(ILevelRestartService levelRestart, MenuSelector levelSelector)
        {
            _levelRestart = levelRestart;
            _levelSelector = levelSelector;
            
            RestartButton.onClick.AddListener(() =>
            {
                _levelRestart.Restart();
                HideLosePanel();
            });

            LevelSelectorButton.onClick.AddListener(() =>
            {
                _levelSelector.ShowLevelSelector();
                _levelRestart.RestartFromLevelSelector();
                HideLosePanel();
            });
            
            HideLosePanel();
        }
        
        public void ShowLosePanel()
        {
            _animator.ShowLosePanel(Panel, ButtonContainer, Duration);
        }

        public void HideLosePanel()
        {
            _animator.HideLosePanel(Panel, Duration);
        }
    }
}