using TapDash.CodeBase.Infrastructure.Services.Restart;
using UnityEngine;
using UnityEngine.UI;

namespace TapDash.CodeBase.UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Image _losePanel;
        [SerializeField] private Button _restartButton;
        
        private ILevelRestartService _levelRestart;

        public void Construct(ILevelRestartService levelRestart)
        {
            _levelRestart = levelRestart;
            
            _restartButton.onClick.AddListener(() =>
            {
                _levelRestart.Restart();
                _losePanel.gameObject.SetActive(false);
            });
        }

        public void ShowLosePanel()
        {
            _losePanel.gameObject.SetActive(true);
        }
    }
}