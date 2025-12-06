using UnityEngine;

namespace TapDash.CodeBase
{
    public class GroundFollow : MonoBehaviour
    { 
        public float RotationAngleX = 10;
        public float Distance = 10;
        public float OffsetY = -10;

        [SerializeField] private Transform _target;

        public void Follow(GameObject target) => _target = target.transform;

        private void LateUpdate()
        {
            if (!_target)
                return;

            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            Vector3 position = rotation * new Vector3(0, 0, -Distance) + FollowingPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        private Vector3 FollowingPosition()
        {
            Vector3 followingPosition = _target.position;
            followingPosition.y += OffsetY;
            
            return followingPosition;
        }
    }
}