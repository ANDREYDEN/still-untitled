using UnityEngine;
using Zenject;

public class ZenjectHelper : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<TestSignal>();
        Container.DeclareSignal<CompassInitiated>();

        SignalBusInstaller.Install(Container);

        Container.Bind<Player>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}