using TapDash.CodeBase.Level;

namespace TapDash.CodeBase.Infrastructure.Services.LevelRestart
{
    public interface ILevelRestartService : IService
    {
        void Restart();
        void RegisterChunkSpawner(IChunkSpawner chunkSpawner);
        void RestartFromLevelSelector();
    }
}