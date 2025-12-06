using TapDash.CodeBase.Data;

namespace TapDash.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface IPersistentProgressService
    {
        PlayerProgress Progress { get; set; }
    }
}