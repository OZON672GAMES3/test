using TapDash.CodeBase.CameraLogic;
using TapDash.CodeBase.Infrastructure.Factory;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string InitialPoint = "InitialPoint";
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            CameraFollow(_gameFactory.CreatePlayer(GameObject.FindWithTag(InitialPoint)));
            
            _stateMachine.Enter<GameLoopState>();
        }

        private static void CameraFollow(GameObject target) => Camera.main.GetComponent<CameraFollow>().Follow(target);
    }
}