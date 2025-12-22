using System.Collections.Generic;
using TapDash.CodeBase.Infrastructure.AssetManagement;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using TapDash.CodeBase.Player;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();

        private GameObject _playerGameObject;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public void ResetPlayer()
        {
            CharacterController characterController = _playerGameObject.GetComponent<CharacterController>();
            characterController.enabled = false;
            _playerGameObject.transform.position = new Vector3(0, 1, 0);
            characterController.enabled = true;
            _playerGameObject.GetComponent<PlayerMoveOld>().SetPlayerAlive();
        }

        public void ResetPlayerFromLevelSelector()
        {
            CharacterController characterController = _playerGameObject.GetComponent<CharacterController>();
            characterController.enabled = false;
            _playerGameObject.transform.position = new Vector3(0, 1, 0);
            characterController.enabled = true;
            _playerGameObject.SetActive(false);
        }

        public GameObject CreatePLayer(GameObject at) =>
            _playerGameObject = InstantiateRegistered(AssetPath.PlayerPath, at.transform.position);

        public GameObject CreateHud() => InstantiateRegistered(AssetPath.HudPath);

        public GameObject CreateChunkSpawner() =>
            InstantiateRegistered(AssetPath.ChunkSpawnerPath);

        public void Cleanup()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }

        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath, at);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private GameObject InstantiateRegistered(string prefabPath)
        {
            GameObject gameObject = _assets.Instantiate(prefabPath);
            RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        private void RegisterProgressWatchers(GameObject gameObject)
        {
            foreach (ISavedProgressReader progressReader in gameObject.GetComponents<ISavedProgressReader>())
                Register(progressReader);
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);
            
            ProgressReaders.Add(progressReader);
        }
    }
}