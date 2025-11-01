using InputSystem;
using UnityEngine;
using Zenject;

namespace Bootstrap
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ITapInput>().To<TapInput>().AsSingle().NonLazy();
        }
    }
}