using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public class Chunk : MonoBehaviour
    {
        public SafeZone SafeZone;
        
        private float _length;

        public float GetChunkLengthZ()
        {
            Collider[] colliders = GetComponentsInChildren<Collider>();

            if (colliders.Length == 0)
                return 0f;

            Bounds bounds = colliders[0].bounds;

            foreach (Collider c in colliders)
                bounds.Encapsulate(c.bounds);

            return bounds.size.z;
        }
    }
}