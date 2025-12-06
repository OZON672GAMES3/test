using InputSystem;
using Level;
using TapDash.CodeBase.Level;
using TapDash.CodeBase.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TapDash.CodeBase.UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Image _losePanel;
        [SerializeField] private Button _restartButton;

        private PlayerMove _player;
        private SimpleChunkSpawner _chunkSpawner;
        
        [Inject]
        public void Construct(PlayerMove player, SimpleChunkSpawner chunkSpawner)
        {
            _player = player;
            _chunkSpawner = chunkSpawner;
        }

        private void Start()
        {
            _restartButton.onClick.AddListener(() =>
            {
                _chunkSpawner.Restart();
                _losePanel.gameObject.SetActive(false);
            });
        }

        private void ShowLosePanel()
        {
            _losePanel.gameObject.SetActive(true);
        }
    }
}