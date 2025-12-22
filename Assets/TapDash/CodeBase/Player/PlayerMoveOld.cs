using TapDash.CodeBase.Data;
using TapDash.CodeBase.Infrastructure.Services;
using TapDash.CodeBase.Infrastructure.Services.Input;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using TapDash.CodeBase.InputSystem;
using TapDash.CodeBase.UI;
using UnityEngine;

namespace TapDash.CodeBase.Player
{
    public class PlayerMoveOld : MonoBehaviour, ISavedProgress
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
            Align();
            
            if (_isDead)
                return;
            
            Vector3 move = _direction * MoveSpeed * Time.deltaTime;
            CharacterController.Move(move);

            if (transform.position.y <= -0.2f)
                Die();
        }

        private void Align()
        {
            if (_alignTarget.HasValue)
            {
                Vector3 target = _alignTarget.Value;
                Vector3 newPos = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
                transform.position = newPos;
                
                if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                        new Vector3(target.x, 0, target.z)) < 0.01f)
                    _alignTarget = null;
            }
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

        public void AlignTo(Vector3 target)
        {
            
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.LevelData = _lastCompletedLevel;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            _lastCompletedLevel = progress.LevelData;
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