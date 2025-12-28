using TapDash.CodeBase.Infrastructure.Services;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;

namespace TapDash.CodeBase.Infrastructure
{
    public interface IGameplayInstaller : IService
    {
        void Install();
    }
}