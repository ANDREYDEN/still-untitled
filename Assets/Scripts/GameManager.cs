using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public static float TimeScale { get; set; } = 1;

    [Inject] private SignalBus _signalBus;

    private void Start()
    {
        _signalBus.Subscribe<GameEnded>(HandleGameEnded);
    }

    private void HandleGameEnded(GameEnded result)
    {
        Debug.Log("GE: " + result.won);
    }
}
