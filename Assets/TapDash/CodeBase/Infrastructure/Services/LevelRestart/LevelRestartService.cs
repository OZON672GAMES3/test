using TapDash.CodeBase.Infrastructure.Factory;
using TapDash.CodeBase.Level;

namespace TapDash.CodeBase.Infrastructure.Services.LevelRestart
{
    public class LevelRestartService : ILevelRestartService
    {
        private readonly IGameFactory _gameFactory;
        private IChunkSpawner _chunkSpawner;

        public LevelRestartService(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void RegisterChunkSpawner(IChunkSpawner chunkSpawner)
        {
            _chunkSpawner = chunkSpawner;
        }
        
        public void Restart()
        {
            _gameFactory.ResetPlayer();
            _chunkSpawner.Clear();
        }

        public void RestartFromLevelSelector()
        {
            _gameFactory.ResetPlayerFromLevelSelector();
            _chunkSpawner.Clear();
        }
    }
}