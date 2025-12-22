using TapDash.CodeBase.CameraLogic;
using TapDash.CodeBase.Infrastructure.Factory;
using TapDash.CodeBase.Infrastructure.Services.LevelRestart;
using TapDash.CodeBase.Level;
using TapDash.CodeBase.Player;
using TapDash.CodeBase.UI;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure
{
    public class GameplayInstaller : IGameplayInstaller
    {
        private const string InitialPoint = "InitialPoint";

        private readonly IGameFactory _gameFactory;
        private readonly ILevelRestartService _levelRestart;

        public GameplayInstaller(IGameFactory gameFactory, ILevelRestartService levelRestart)
        {
            _gameFactory = gameFactory;
            _levelRestart = levelRestart;
        }

        public void Install()
        {
            GameObject player = _gameFactory.CreatePLayer(GameObject.FindWithTag(InitialPoint));
            GameObject hud = _gameFactory.CreateHud();
            GameObject spawner = _gameFactory.CreateChunkSpawner();

            PlayerMoveOld playerMoveOld = player.GetComponent<PlayerMoveOld>();
            LoseScreen loseScreen = hud.GetComponentInChildren<LoseScreen>();
            LevelSelector levelSelector = hud.GetComponentInChildren<LevelSelector>();
            MenuSelector menuSelector = hud.GetComponentInChildren<MenuSelector>();
            GameChunkSpawner chunkSpawner = spawner.GetComponent<GameChunkSpawner>();
            
            playerMoveOld.Construct(loseScreen);
            loseScreen.Construct(_levelRestart, menuSelector);
            levelSelector.Construct(chunkSpawner, playerMoveOld, menuSelector);
            chunkSpawner.Construct(playerMoveOld);
            
            _levelRestart.RegisterChunkSpawner(chunkSpawner);
            
            CameraFollow(player);
            GroundFollow(player);

            player.SetActive(false);
        }
        
        private void CameraFollow(GameObject target) => Camera.main.GetComponent<CameraFollow>().Follow(target);

        private void GroundFollow(GameObject target) => GameObject.FindObjectOfType<GroundFollow>().Follow(target);
    }
}