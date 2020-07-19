using UnityEngine;
using Zenject;


public class SignalsInstaler : MonoInstaller
{
    public override void InstallBindings()
    {
        Debug.Log("Instaling signals");
        Container.DeclareSignal<TestSignal>();



        SignalBusInstaller.Install(Container);

    }
}

