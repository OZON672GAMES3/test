using TapDash.CodeBase.Infrastructure.Services;

namespace TapDash.CodeBase.Infrastructure
{
    public interface IGameplayInstaller : IService
    {
        void Install();
    }
}