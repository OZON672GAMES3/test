using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

namespace TapDash.CodeBase.Level
{
    public class ChunkPool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Queue<T> _pool = new();
        private readonly Transform _parent;

        public ChunkPool(T prefab, int initialSize, Transform parent = null)
        {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialSize; i++)
            {
                T obj = GameObject.Instantiate(_prefab, parent);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }
        }

        public T Get()
        {
            T obj = _pool.Count > 0 ? _pool.Dequeue() : GameObject.Instantiate(_prefab, _parent);
            
            obj.gameObject.SetActive(true);
            return obj;
        }

        public void Release(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}