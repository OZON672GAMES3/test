using TapDash.CodeBase.Level;
using TapDash.CodeBase.Player;
using TapDash.CodeBase.UI;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure
{
    public class LevelStartService : MonoBehaviour
    {
        private IChunkSpawner _chunkSpawner;
        private MenuSelector _menuSelector;
        private PlayerMoveOld _playerMove;

        public void Construct(IChunkSpawner chunkSpawner, MenuSelector menuSelector, PlayerMoveOld playerMove)
        {
            _chunkSpawner = chunkSpawner;
            _menuSelector = menuSelector;
            _playerMove = playerMove;
        }
        
        public void StartGame(int index)
        {
            _chunkSpawner.SpawnChunk(index);
            _menuSelector.CloseLevelsPanelOnStart();
            _playerMove.gameObject.SetActive(true);
            _playerMove.SetPlayerAlive();
        }
    }
}