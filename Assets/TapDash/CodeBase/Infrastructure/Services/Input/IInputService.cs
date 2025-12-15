using System;
using TapDash.CodeBase.Infrastructure.Services;

namespace TapDash.CodeBase.Services.Input
{
    public interface IInputService : IService
    {
        event Action OnTap;
    }
}