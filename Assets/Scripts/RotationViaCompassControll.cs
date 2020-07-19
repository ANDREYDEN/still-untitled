using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RotationViaCompassControll : MonoBehaviour
{
    private Compass _compass;
    private int prevAngle;

    [Inject] private SignalBus _signalBus;
    [Inject] 
    private void OnInject()
    {
        _signalBus.Subscribe<CompassInitializedSignal>(OnCompassInit);
    }

    private void OnCompassInit()
    {
        _compass = Input.compass;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompassInit.compassInitialized)
        {

        }
    }
}
