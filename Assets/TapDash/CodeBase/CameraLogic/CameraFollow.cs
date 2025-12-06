using UnityEngine;

namespace TapDash.CodeBase.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        public float RotationAngleX;
        public float Distance;
        public float OffsetY;

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
