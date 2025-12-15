using System.Collections.Generic;
using TapDash.CodeBase.Infrastructure.Services;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
        void Cleanup();
        
        GameObject CreateChunkSpawner();
        GameObject CreateHud();
        GameObject CreatePLayer(GameObject at);
        void ConstructGameplay();
        void ResetPlayer();
    }
}