using System.Collections.Generic;
using TapDash.CodeBase.Player;
using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public class GameChunkSpawner : MonoBehaviour, IChunkSpawner
    {
        [SerializeField] private List<Chunk> _chunks;
        
        private IChunkSpawner _chunkSpawner;
        private PlayerMoveOld _player;
        private int _index;
        private Transform _lastChunk;
        
        private List<Chunk> _spawnedChunks = new();

        public void Construct(PlayerMoveOld player)
        {
            _player = player;
        }
        
        private void Update()
        {
            Tick();
        }

        public void SpawnChunk(int index)
        {
            _index = index;
            Chunk newChunk = Instantiate(_chunks[_index], transform);
            _spawnedChunks.Add(newChunk);
            
            if (!_lastChunk)
                newChunk.transform.position = Vector3.zero;
            else
            {
                Transform startPoint = newChunk.StartPoint;
                Vector3 offset = _lastChunk.position - startPoint.position;
                newChunk.transform.position += offset;
            }
            
            _lastChunk = newChunk.EndPoint;
            
            if (_index >= _chunks.Count -1)
                _index = 0;
            else
                _index++;

            Debug.Log($"Spawned chunk {_chunks[_index].name}");
        }

        public void Clear()
        {
            foreach (Chunk chunk in _spawnedChunks)
                Destroy(chunk.gameObject);
            
            _spawnedChunks.Clear();
            _lastChunk = null;
            SpawnChunk(_index);
        }
        
        public void Tick()
        {
            if (_lastChunk && _player.transform.position.z > _lastChunk.position.z - 15)
                SpawnChunk(_index);
        }
    }
}