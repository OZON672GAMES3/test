using InputSystem;
using Level;
using UI;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Bootstrap
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private LoseScreen _loseScreen;
        [SerializeField] private LevelSelector _levelSelector;
        [SerializeField] private SimpleChunkSpawner _simpleChunkSpawner;

        public override void InstallBindings()
        {
            Container.BindInstance(_player);
            Container.BindInstance(_levelSelector);
            Container.BindInstance(_simpleChunkSpawner);
        }
    }
}