using TapDash.CodeBase.Level;
using TapDash.CodeBase.Player;
using UnityEngine;
using UnityEngine.UI;

namespace TapDash.CodeBase.UI
{
    public class LevelSelector : MonoBehaviour
    {
        private IChunkSpawner  _chunkSpawner;
        [SerializeField] private MenuSelector _menuSelector;
        [SerializeField] private PlayerMoveOld _player;
        
        private Button[] _levelIndexButton;

        public void Construct(IChunkSpawner chunkSpawner, PlayerMoveOld player, MenuSelector menuSelector)
        {
            _chunkSpawner = chunkSpawner;
            _player = player;
            _menuSelector = menuSelector;
            
            _levelIndexButton = GetComponentsInChildren<Button>();

            for (int i = 0; i < _levelIndexButton.Length; i++)
            {
                int index = i;
                _levelIndexButton[i].onClick.AddListener(() =>
                {
                    _chunkSpawner.SpawnChunk(index);
                    _menuSelector.CloseLevelsPanelOnStart();
                    _player.gameObject.SetActive(true);
                    _player.SetPlayerAlive();
                });
            }
        }
    }
}