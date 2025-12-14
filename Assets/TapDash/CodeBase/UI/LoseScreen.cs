using TapDash.CodeBase.Level;
using UnityEngine;
using UnityEngine.UI;

namespace TapDash.CodeBase.UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Image _losePanel;
        [SerializeField] private Button _restartButton;
        
        private SimpleChunkSpawner _chunkSpawner;

        public void Construct(SimpleChunkSpawner chunkSpawner)
        {
            _chunkSpawner = chunkSpawner;
            
            _restartButton.onClick.AddListener(() =>
            {
                _chunkSpawner.Restart();
                _losePanel.gameObject.SetActive(false);
            });
        }

        public void ShowLosePanel()
        {
            _losePanel.gameObject.SetActive(true);
        }
    }
}