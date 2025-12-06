using TapDash.CodeBase.Data;

namespace TapDash.CodeBase.Infrastructure.Services.PersistentProgress
{
    public interface ISavedProgress
    {
        void UpdateProgress(PlayerProgress progress);
        void LoadProgress(PlayerProgress progress);
    }
}