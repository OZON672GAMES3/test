using InputSystem;
using Level;
using UI;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class GameplayInstaller : MonoInstaller
    {
        [SerializeField] private PlayerBehaviour _player;
        [SerializeField] private LoseScreen _loseScreen;
        [SerializeField] private GameStart _gameStart;
        [SerializeField] private SimpleChunkSpawner _simpleChunkSpawner;

        public override void InstallBindings()
        {
            Container.BindInstance(_player).AsSingle();
            Container.BindInstance(_gameStart).AsSingle();
            Container.BindInstance(_simpleChunkSpawner).AsSingle();
        }
    }
}