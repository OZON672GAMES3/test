using TapDash.CodeBase.Infrastructure.Factory;
using TapDash.CodeBase.Level;

namespace TapDash.CodeBase.Infrastructure.Services.Restart
{
    public class LevelRestartService : ILevelRestartService
    {
        private readonly IGameFactory _gameFactory;
        private readonly IChunkSpawner _chunkSpawner;

        public LevelRestartService(IGameFactory gameFactory, IChunkSpawner chunkSpawner)
        {
            _gameFactory = gameFactory;
            _chunkSpawner = chunkSpawner;
        }
        
        public void Restart()
        {
            _gameFactory.ResetPlayer();
        }
    }
}