using UnityEngine;
using Zenject;

public class ZenjectHelper : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerController>().FromComponentInHierarchy().AsSingle().NonLazy();
    }
}