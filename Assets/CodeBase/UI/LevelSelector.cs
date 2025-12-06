using InputSystem;
using Level;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private SimpleChunkSpawner _simpleChunkSpawner;
        [SerializeField] private MenuSelector _menuSelector;
        [SerializeField] private PlayerBehaviour _player;
        
        private Button[] _levelIndexButton;

        private void Awake()
        {
            _levelIndexButton = GetComponentsInChildren<Button>();

            for (int i = 0; i < _levelIndexButton.Length; i++)
            {
                int index = i;
                _levelIndexButton[i].onClick.AddListener(() =>
                {
                    _simpleChunkSpawner.SpawnChunk(index);
                    _menuSelector.CloseLevelsPanelOnStart();
                    _player.EnablePlayer();
                });
            }
        }
    }
}