using TapDash.CodeBase.Infrastructure.Services;

namespace TapDash.CodeBase.Level
{
    public interface IChunkSpawner : IService
    {
        void SpawnChunk(int index);
        void Clear();
        void Tick();
    }
}