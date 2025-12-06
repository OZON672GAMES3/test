using System.Collections.Generic;
using TapDash.CodeBase.Infrastructure.AssetManagement;
using TapDash.CodeBase.Infrastructure.Services.PersistentProgress;
using TapDash.CodeBase.Level;
using TapDash.CodeBase.Player;
using TapDash.CodeBase.UI;
using UI;
using UnityEngine;

namespace TapDash.CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assets;

        public List<ISavedProgressReader> ProgressReaders { get; } = new();
        public List<ISavedProgress> ProgressWriters { get; } = new();
        
        private GameObject _playerGameObject;
        private GameObject _spawnerGameObject;
        private GameObject _hudGameObject;

        public GameFactory(IAssets assets)
        {
            _assets = assets;
        }

        public GameObject CreatePlayer(GameObject at)
        {
            _playerGameObject = InstantiateRegistered(AssetPath.PlayerPath, at.transform.position);
            _playerGameObject.SetActive(false);
            return _playerGameObject;
        }

        public void CreateHud()
        {
            _hudGameObject = InstantiateRegistered(AssetPath.HudPath);
            _hudGameObject.GetComponentInChildren<LevelSelector>().Construct(
                _spawnerGameObject.GetComponent<SimpleChunkSpawner>(),
                _playerGameObject.GetComponent<PlayerMove>(),
                _hudGameObject.GetComponentInChildren<MenuSelector>());
        }

        public GameObject CreateChunkSpawner()
        {
            _spawnerGameObject = InstantiateRegistered(AssetPath.ChunkSpawnerPath);
            _spawnerGameObject.GetComponent<SimpleChunkSpawner>().Construct(_playerGameObject.GetComponent<PlayerMove>());
            return _spawnerGameObject;
        }

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