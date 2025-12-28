using TapDash.CodeBase.Infrastructure.Services;
using TapDash.CodeBase.Infrastructure.Services.Input;
using TapDash.CodeBase.InputSystem;
using TapDash.CodeBase.UI;
using UnityEngine;

namespace TapDash.CodeBase.Player
{
    public class PlayerMoveOld : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MoveSpeed = 5f;
        
        private IInputService _inputService;
        private TurnTrigger _currentTurnZone;
        private Vector3 _direction = Vector3.forward;
        private Vector3? _alignTarget;
        private int _lastCompletedLevel;
        private bool _isDead;
        private LoseScreen _loseScreenView;

        public void Construct(LoseScreen loseScreenView)
        {
            _loseScreenView = loseScreenView;
        }
        
        private void Awake()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            _inputService.OnTap += OnTap;
        }

        private void OnDestroy()
        {
            _inputService.OnTap -= OnTap;
        }

        private void Update()
        {
            if (_isDead)
                return;
            
            Move();

            if (transform.position.y <= -0.2f)
                Die();
        }

        public void SetPlayerAlive()
        {
            _isDead = false;
            _direction = Vector3.forward;
        }

        public void SetTurnZone(TurnTrigger zone) => _currentTurnZone = zone;

        public void ClearTurnZone() => _currentTurnZone = null;

        public void Turn(TurnDirection turnDirection)
        {
            _direction = Quaternion.Euler(0, (float)turnDirection, 0) * _direction;
        }

        private void Move()
        {
            Vector3 move = _direction * MoveSpeed * Time.deltaTime;
            CharacterController.Move(move);
        }

        private void Die()
        {
            _isDead = true;
            _loseScreenView.ShowLosePanel();
        }

        private void OnTap()
        {
            if (!_currentTurnZone)
                return;
            
            Turn(_currentTurnZone.TurnDirection);
            _currentTurnZone = null;
        }
    }
}