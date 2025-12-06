using System.Collections.Generic;
using Level;
using TapDash.CodeBase.Player;
using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public class SimpleChunkSpawner : MonoBehaviour
    {
        [SerializeField] private List<Chunk> _chunks;
        
        private Transform _lastChunk;
        private int _index;
        private PlayerMove _player;

        private List<Chunk> _spawnedChunks = new();

        public void Construct(PlayerMove player)
        {
            _player = player;
        }

        private void Update()
        {
            if (_lastChunk && _player.transform.position.z > _lastChunk.transform.position.z - 15)
                SpawnChunk(_index);
        }

        public void Restart()
        {
            foreach (Chunk chunk in _spawnedChunks)
                Destroy(chunk.gameObject);
            
            _spawnedChunks.Clear();
            _lastChunk = null;
            SpawnChunk(_index);
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
        }
    }
}