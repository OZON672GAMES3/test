using TapDash.CodeBase.InputSystem;
using UnityEngine;

namespace TapDash.CodeBase.Player
{
    public class PlayerMove : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float MoveSpeed = 5f;
        
        private Vector3 _direction = Vector3.forward;
        private Vector3? _alignTarget;

        public void Tick()
        {
            Align();
        }

        public void Turn(TurnDirection turn)
        {
            _direction = Quaternion.Euler(0, (float)turn, 0) * _direction;
        }

        private void AlignTo(Vector3 target)
        {
            _alignTarget = target;
        }

        private void Align()
        {
            if (!_alignTarget.HasValue)
                return;
            
            Vector3 target = _alignTarget.Value;
            Vector3 newPos = Vector3.MoveTowards(transform.position, target, MoveSpeed * Time.deltaTime);
            transform.position = newPos;
                
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                    new Vector3(target.x, 0, target.z)) < 0.01f)
                _alignTarget = null;
        }
    }
}