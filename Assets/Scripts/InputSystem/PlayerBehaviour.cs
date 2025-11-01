using System;
using Level;
using UI;
using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class PlayerBehaviour : MonoBehaviour
    {
        public event Action OnPlayerDead;
        
        [SerializeField] private float _moveSpeed = 5f;

        private ITapInput _tapInput;
        private bool _isDead;

        private Vector3 _direction = Vector3.forward;
        private Rigidbody _rigidbody;
        private TurnTrigger _currentTurnZone;
        private Vector3? _alignTarget;
        private Vector3 _defaultPlayerTransform;

        [Inject]
        public void Construct(ITapInput tapInput)
        {
            _tapInput = tapInput;
            _tapInput.OnTap += OnTap;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _defaultPlayerTransform = transform.position;
        }

        private void OnDestroy()
        {
            _tapInput.OnTap -= OnTap;
        }

        private void Update()
        {
            if (_alignTarget.HasValue)
            {
                Vector3 target = _alignTarget.Value;
                Vector3 newPos = Vector3.MoveTowards(transform.position, target, _moveSpeed * Time.deltaTime);
                transform.position = newPos;
                
                if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                        new Vector3(target.x, 0, target.z)) < 0.01f)
                {
                    _alignTarget = null;
                }
            }
        }

        private void FixedUpdate()
        {
            if (!_isDead)
                _rigidbody.MovePosition(transform.position + _direction * _moveSpeed * Time.fixedDeltaTime);

            if (transform.position.y <= -0.2)
                Die();
        }

        public void ResetPlayer()
        {
            _isDead = false;
            _direction = Vector3.forward;
            transform.position = _defaultPlayerTransform;
            gameObject.SetActive(true);
        }

        public void AlignTo(Vector3 target)
        {
            _alignTarget = new Vector3(target.x, transform.position.y, target.z);
        }

        private void OnTap()
        {
            if (_currentTurnZone == null)
            {
                Die();
                return;
            }
            
            Turn(_currentTurnZone.TurnDirection);
            _currentTurnZone = null;
        }

        public void Turn(TurnDirection turnDirection)
        {
            _direction = Quaternion.Euler(0, (float)turnDirection, 0) * _direction;
        }

        public void EnablePlayer(int _)
        {
            gameObject.SetActive(true);
        }

        private void Die()
        {
            _isDead = true;
            print("deadass");
            OnPlayerDead?.Invoke();
            gameObject.SetActive(false);
        }

        public void SetTurnZone(TurnTrigger zone) => _currentTurnZone = zone;
        public void ClearTurnZone() => _currentTurnZone = null;
    }
}