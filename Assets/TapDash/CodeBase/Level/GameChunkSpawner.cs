using System.Collections.Generic;
using TapDash.CodeBase.Data;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using TapDash.CodeBase.Player;
using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public class GameChunkSpawner : MonoBehaviour, IChunkSpawner, ISavedProgress
    {
        public List<LevelConfig> Chunks;
        public float SpawnAheadDistance = 15;
        public int PoolInitialSize = 5;

        private PlayerMoveOld _player;
        private int _index;
        private Chunk _lastChunk;
        private ChunkPool<Chunk> _pool;

        private List<Chunk> _spawnedChunks = new();
        private float _spawnZ;
        private int _lastCompletedChunkIndex;

        public void Construct(PlayerMoveOld player)
        {
            // _pool = new ChunkPool<Chunk>(Chunks[1].Chunk, PoolInitialSize, gameObject.transform);
            _player = player;
        }
        
        private void Update()
        {
            Tick();
        }

        public void SpawnChunk(int index)
        {
            _index = index;
            LevelConfig config = Chunks[_index];
            Chunk chunk = Instantiate(config.Chunk, transform);
            _spawnedChunks.Add(chunk);

            chunk.transform.position = new Vector3(0, 0, _spawnZ);
            _spawnZ += chunk.GetChunkLengthZ() - 2;

            int spawnedChunkIndex = index;
            chunk.SafeZone.GetChunkIndex(spawnedChunkIndex);
            chunk.SafeZone.OnComplete += OnChunkPassed;
            
            _lastChunk = chunk;
            _index = (_index + 1) % Chunks.Count;

            Debug.Log($"Spawned chunk {Chunks[_index].name}");
        }

        private void OnChunkPassed(int chunkIndex)
        {
            if (chunkIndex <= _lastCompletedChunkIndex)
                return;
            
            _lastCompletedChunkIndex = chunkIndex;
        }

        public void Clear()
        {
            foreach (Chunk chunk in _spawnedChunks)
                Destroy(chunk.gameObject);
            
            _spawnedChunks.Clear();
            _lastChunk = null;
        }

        public void Tick()
        {
            if (_player.transform.position.z + SpawnAheadDistance >= _spawnZ && _lastChunk != null)
                SpawnChunk(_index);
        }

        public void LoadProgress(PlayerProgress progress)
        {
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.LastCompletedChunkIndex = _lastCompletedChunkIndex;
        }
    }
}