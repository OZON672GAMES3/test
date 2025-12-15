using System.Collections.Generic;
using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public class ChunkSpawner : IChunkSpawner
    {
        private List<Chunk> _chunks;
        
        private Transform _lastChunk;
        private int _index;
        private List<Chunk> _spawnedChunks = new();


        public void SpawnChunk(int index)
        {
        }
    }
}