using UnityEngine;

namespace TapDash.CodeBase.Player
{
    public class PlayerGravity : MonoBehaviour
    {
        public CharacterController CharacterController;
        public float Gravity = -30f;
        public float GroundStickForce = -2f;

        private float _yVelocity;

        private void Update()
        {
            if (CharacterController.isGrounded)
            {
                if (_yVelocity < 0)
                    _yVelocity = GroundStickForce;
            }
            else
            {
                _yVelocity += Gravity * Time.deltaTime;
            }

            CharacterController.Move(Vector3.up * _yVelocity * Time.deltaTime);
        }
    }
}