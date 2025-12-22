using System;

namespace TapDash.CodeBase.Infrastructure.Services.Input
{
    public interface IInputService : IService
    {
        event Action OnTap;
    }
}