using UnityEngine;

namespace TapDash.CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public Bootstrapper BootstrapperPrefab;
        
        private void Awake()
        {
            var bootstrapper = FindObjectOfType<Bootstrapper>();
            if (bootstrapper == null)
                Instantiate(BootstrapperPrefab);
        }
    }
}