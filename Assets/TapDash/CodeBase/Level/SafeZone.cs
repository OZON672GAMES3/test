using System;
using TapDash.CodeBase.Player;
using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public class SafeZone : MonoBehaviour
    {
        public event Action<int> OnComplete;
        
        private int _chunkIndex;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMoveOld player))
                OnComplete?.Invoke(_chunkIndex);
        }

        public void GetChunkIndex(int chunkIndex)
        {
            _chunkIndex = chunkIndex;
        }
    }
}