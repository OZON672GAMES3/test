using System;
using TapDash.CodeBase.InputSystem;
using TapDash.CodeBase.Player;
using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public class SafeZone : MonoBehaviour
    {
        public event Action OnComplete;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMove player))
            {
                player.AlignTo(transform.position);
                OnComplete?.Invoke();
            }
        }
    }
}