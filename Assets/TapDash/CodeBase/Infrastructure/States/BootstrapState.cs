using TapDash.CodeBase.Infrastructure.AssetManagement;
using TapDash.CodeBase.Infrastructure.Factory;
using TapDash.CodeBase.Infrastructure.Services;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using TapDash.CodeBase.Infrastructure.Services.Restart;
using TapDash.CodeBase.Infrastructure.Services.SaveLoad;
using TapDash.CodeBase.Level;
using TapDash.CodeBase.Services.Input;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private const string Initial = "Initial";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(Initial, EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel() => _stateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            _services.RegisterSingle<IInputService>(new InputService());
            _services.RegisterSingle<IAssets>(new AssetProvider());
            _services.RegisterSingle<IPersistentProgressService>(new PersistentProgressService());
            _services.RegisterSingle<IChunkSpawner>(new ChunkSpawner());
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssets>(),
                _services.Single<ILevelRestartService>()));
            _services.RegisterSingle<ISaveLoadService>(
                new SaveLoadService(_services.Single<IPersistentProgressService>(), _services.Single<IGameFactory>()));
            _services.RegisterSingle<ILevelRestartService>(new LevelRestartService(_services.Single<IGameFactory>(),
                _services.Single<IChunkSpawner>()));
        }
    }
}