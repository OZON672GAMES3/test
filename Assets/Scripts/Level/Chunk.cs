using UnityEngine;

namespace Level
{
    public class Chunk : MonoBehaviour
    {
        [SerializeField] private Transform _endPoint;
        [SerializeField] private Transform _startPoint;

        public Transform EndPoint => _endPoint;
        public Transform StartPoint => _startPoint;
    }
}