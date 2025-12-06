using TapDash.CodeBase.Infrastructure.Services;
using TapDash.CodeBase.Infrastructure.States;
using TapDash.CodeBase.Logic;

namespace TapDash.CodeBase.Infrastructure
{
    class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, AllServices.Container);
        }
    }
}