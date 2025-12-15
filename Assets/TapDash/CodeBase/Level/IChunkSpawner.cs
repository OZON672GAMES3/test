using TapDash.CodeBase.Infrastructure.Services;
using UnityEngine;

namespace TapDash.CodeBase.Level
{
    public interface IChunkSpawner : IService
    {
        void SpawnChunk(int index);
    }
}