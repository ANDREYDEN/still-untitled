using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class TimeIndicator : MonoBehaviour
{
    public TMP_Text textComponent;

    private float secondsLeft = 60;

    [Inject] private SignalBus _signalBus;

    void Update()
    {
        secondsLeft -= Time.deltaTime * GameManager.TimeScale;
        if (secondsLeft < 0)
        {
            _signalBus.Fire(new GameEnded() { won = false });
        }
        textComponent.text = Mathf.FloorToInt(secondsLeft).ToString();         
    }
}
