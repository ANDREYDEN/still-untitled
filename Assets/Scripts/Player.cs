using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    [Inject] private SignalBus _signalBus;

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag) {
            case "Harmful":
                _signalBus.Fire(new GameEnded() { won = false });
                break;
            case "Finish":
                _signalBus.Fire(new GameEnded() { won = true });
                break;
        }
    }
}
