using TapDash.CodeBase.Level;
using TapDash.CodeBase.Player;
using UnityEngine;
using UnityEngine.UI;

namespace TapDash.CodeBase.UI
{
    public class LevelSelector : MonoBehaviour
    {
        [SerializeField] private SimpleChunkSpawner _simpleChunkSpawner;
        [SerializeField] private MenuSelector _menuSelector;
        [SerializeField] private PlayerMove _player;
        
        private Button[] _levelIndexButton;

        public void Construct(SimpleChunkSpawner simpleChunkSpawner, PlayerMove player, MenuSelector menuSelector)
        {
            _simpleChunkSpawner = simpleChunkSpawner;
            _player = player;
            _menuSelector = menuSelector;
        }
        
        private void Start()
        {
            _levelIndexButton = GetComponentsInChildren<Button>();

            for (int i = 0; i < _levelIndexButton.Length; i++)
            {
                int index = i;
                _levelIndexButton[i].onClick.AddListener(() =>
                {
                    _simpleChunkSpawner.SpawnChunk(index);
                    _menuSelector.CloseLevelsPanelOnStart();
                    _player.gameObject.SetActive(true);
                });
            }
        }
    }
}