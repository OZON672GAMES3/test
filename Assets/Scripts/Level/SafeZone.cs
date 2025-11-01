using InputSystem;
using UnityEngine;

namespace Level
{
    public class SafeZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerBehaviour player))
                player.AlignTo(transform.position);
        }
    }
}