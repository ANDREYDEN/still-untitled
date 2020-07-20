using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CompassDataHandler : MonoBehaviour
{
    public GameObject player;

    private float dest;
    [Inject] SignalBus _signalBus;

    [Inject] 
    private void OnInject()
    {
        _signalBus.Subscribe<CompassInitiated>(OnCompassInitialized);
    }

    void Start()
    {
        dest = Input.compass.trueHeading;
        StartCoroutine(checkMovement());
    }
    
    private void OnCompassInitialized()
    {
        //StartCoroutine(checkMovement());
    }

    IEnumerator checkMovement()
    {
        yield return new WaitUntil(() => Mathf.Abs(Input.compass.trueHeading - player.transform.eulerAngles.y) > 10);
        dest = Input.compass.trueHeading;
    }

    void Update()
    {
        //if (Time.time > 20)
        //{
            dest = (int)(Input.compass.trueHeading / 10) * 10;
        //}
        player.transform.eulerAngles = Vector3.Lerp(player.transform.eulerAngles, Vector3.up * dest, Time.deltaTime);
    }
}
