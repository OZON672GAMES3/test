using System;

namespace InputSystem
{
    public class TapInput : ITapInput, IDisposable
    {
        public event Action OnTap;
        
        private readonly TapControls _controls;

        public TapInput()
        {
            _controls = new TapControls();
            _controls.Gameplay.Enable();
            _controls.Gameplay.Tap.performed += ctx => OnTap?.Invoke();
        }

        public void Enable() => _controls.Gameplay.Enable();
        public void Disable() => _controls.Gameplay.Disable();
        public void Dispose() => _controls.Dispose();
    }
}