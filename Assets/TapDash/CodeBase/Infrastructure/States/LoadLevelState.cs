using TapDash.CodeBase.CameraLogic;
using TapDash.CodeBase.Infrastructure.Factory;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using TapDash.CodeBase.Logic;
using TapDash.CodeBase.Player;
using TapDash.CodeBase.Services.Input;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPoint = "InitialPoint";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine stateMachine,
            SceneLoader sceneLoader,
            LoadingCurtain curtain,
            IGameFactory gameFactory, 
            IPersistentProgressService progressService)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            InitGameWorld();
            InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
        
        private void InitGameWorld()
        {
            GameObject player = _gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPoint));
            CameraFollow(player);
            GroundFollow(player);
            _gameFactory.CreateChunkSpawner();
            _gameFactory.CreateHud();
        }

        private static void CameraFollow(GameObject target) => Camera.main.GetComponent<CameraFollow>().Follow(target);

        private static void GroundFollow(GameObject target) => GameObject.FindObjectOfType<GroundFollow>().Follow(target);
    }
}