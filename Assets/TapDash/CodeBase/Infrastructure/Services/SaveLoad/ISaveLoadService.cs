using TapDash.CodeBase.Data;

namespace TapDash.CodeBase.Infrastructure.Services.SaveLoad
{
    internal interface ISaveLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}