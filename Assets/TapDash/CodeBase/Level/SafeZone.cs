using System;
using InputSystem;
using UnityEngine;

namespace Level
{
    public class SafeZone : MonoBehaviour
    {
        public event Action OnComplete;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerBehaviour player))
            {
                player.AlignTo(transform.position);
                OnComplete?.Invoke();
            }
        }
    }
}