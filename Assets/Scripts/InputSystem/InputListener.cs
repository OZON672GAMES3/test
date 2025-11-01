using UnityEngine;
using Zenject;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private ITapInput _tapInput;
        
        [Inject]
        public void Construct(ITapInput tapInput)
        {
            _tapInput = tapInput;
            _tapInput.OnTap += OnTap;
        }

        private void OnDestroy()
        {
            _tapInput.OnTap -= OnTap;
        }

        private void OnTap()
        {
            Turn(TurnDirection.Left);
        }

        private void Turn(TurnDirection turnDirection)
        {
            transform.rotation = Quaternion.Euler(0, (float)turnDirection, 0);
        }
    }
}