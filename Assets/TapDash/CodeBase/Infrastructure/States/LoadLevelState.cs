using TapDash.CodeBase.Infrastructure.Factory;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using TapDash.CodeBase.Logic;

namespace TapDash.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private const string InitialPoint = "InitialPoint";
        private const string SceneName = "Main";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IGameplayInstaller _gameplayInstaller;

        public LoadLevelState(GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            LoadingCurtain curtain,
            IGameFactory gameFactory,
            IPersistentProgressService progressService,
            IGameplayInstaller gameplayInstaller)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _gameplayInstaller = gameplayInstaller;
        }

        public void Enter()
        {
            _curtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(SceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            _gameplayInstaller.Install();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
    }
}