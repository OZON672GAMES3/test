using System;
using UnityEngine.InputSystem;

namespace TapDash.CodeBase.Infrastructure.Services.Input
{
    public class InputService : IInputService, IDisposable
    {
        public event Action OnTap;
        
        private readonly TapControls _controls;

        public InputService()
        {
            _controls = new TapControls();
            _controls.Enable();
            _controls.Gameplay.Tap.performed += OnPerformed;
        }

        public void Dispose()
        {
            _controls.Gameplay.Tap.performed -= OnPerformed;
            _controls.Gameplay.Disable();
        }

        private void OnPerformed(InputAction.CallbackContext context)
        {
            OnTap?.Invoke();
        }
    }
}