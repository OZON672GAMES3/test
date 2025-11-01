using InputSystem;
using Level;
using UnityEngine;

namespace UI
{
    public class GameStart : MonoBehaviour
    {
        [SerializeField] private SimpleChunkSpawner _simpleChunkSpawner;
        [SerializeField] private MenuSelector _menuSelector;
        [SerializeField] private PlayerBehaviour _player;
        
        private UiLevelSelector[] _uiLevelSelectors;

        private void Awake()
        {
            _uiLevelSelectors = GetComponentsInChildren<UiLevelSelector>();
        }

        private void OnEnable()
        {
            foreach (UiLevelSelector selector in _uiLevelSelectors)
            {
                selector.OnLevelSelected += _simpleChunkSpawner.SpawnChunk;
                selector.OnLevelSelected += _menuSelector.CloseLevelsPanel;
                selector.OnLevelSelected += _player.EnablePlayer;
            }
        }

        private void OnDisable()
        {
            foreach (UiLevelSelector selector in _uiLevelSelectors)
            {
                selector.OnLevelSelected -= _simpleChunkSpawner.SpawnChunk;
                selector.OnLevelSelected -= _menuSelector.CloseLevelsPanel;
                selector.OnLevelSelected -= _player.EnablePlayer;
            }
        }
    }
}