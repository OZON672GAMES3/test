using System;
using InputSystem;
using Level;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class LoseScreen : MonoBehaviour
    {
        [SerializeField] private Image _losePanel;
        [SerializeField] private Button _restartButton;

        private PlayerBehaviour _player;
        private SimpleChunkSpawner _chunkSpawner;
        
        [Inject]
        public void Construct(PlayerBehaviour player, SimpleChunkSpawner chunkSpawner)
        {
            _player = player;
            _chunkSpawner = chunkSpawner;
        }

        private void Start()
        {
            _restartButton.onClick.AddListener(() =>
            {
                _player.ResetPlayer();
                _chunkSpawner.Restart();
                _losePanel.gameObject.SetActive(false);
            });
        }

        private void OnEnable()
        {
            _player.OnPlayerDead += ShowLosePanel;
        }

        private void OnDisable()
        {
            _player.OnPlayerDead -= ShowLosePanel;
        }

        private void ShowLosePanel()
        {
            _losePanel.gameObject.SetActive(true);
        }
    }
}