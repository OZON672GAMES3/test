using System;

namespace InputSystem
{
    public interface ITapInput
    {
        event Action OnTap;
        void Enable();
        void Disable();
    }
}