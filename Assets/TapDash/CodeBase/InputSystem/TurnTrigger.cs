using TapDash.CodeBase.Player;
using UnityEngine;

namespace InputSystem
{
    public class TurnTrigger : MonoBehaviour
    {
        [SerializeField] private TurnDirection _turnDirection;
        public TurnDirection TurnDirection => _turnDirection;

        
        private PlayerMove _player;
        private Collider _collider;
        
        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void Update()
        {
            if (_player == null)
                return;
            
            Vector3 playerPos = _player.transform.position;
            Vector3 center = _collider.bounds.center;

            float distance = Vector3.Distance(
                new Vector3(playerPos.x, 0, playerPos.z),
                new Vector3(center.x, 0, center.z)
            );

            if (distance < 0.1f)
            {
                _player.Turn(_turnDirection);
                _player.ClearTurnZone();
                _player = null;
                print($"Player turned {_turnDirection}");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerMove player))
            {
                _player = player;
                player.SetTurnZone(this);
                print($"Entered turn zone: {_turnDirection}");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerMove player))
                player.ClearTurnZone();
        }
    }

    public enum TurnDirection
    {
        Left = -90,
        Right = 90
    }
}