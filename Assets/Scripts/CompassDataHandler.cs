using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CompassDataHandler : MonoBehaviour
{
    public float prevAngle;
    private Compass compass;
    public float deltaAngle;

    private float prev;

    public GameObject player;

    public TMP_Text textComponent;
    private float dest;
    [Inject] SignalBus _signalBus;

    [Inject] 
    private void OnInject()
    {
        _signalBus.Subscribe<CompassInitiated>(OnCompassInitialized);
    }

    
    private void OnCompassInitialized()
    {
        compass = Input.compass;
        prevAngle = compass.trueHeading;
        prev = compass.trueHeading;
        StartCoroutine(checkMovement());
    }

    IEnumerator checkMovement()
    {
        while (Mathf.Abs(compass.trueHeading - prev) < 1)
        {
            yield return new WaitForSeconds(0.3f);
        }
            
        deltaAngle = compass.trueHeading - prev;
        textComponent.text = " heading " + deltaAngle.ToString();
        dest = player.transform.eulerAngles.y + deltaAngle;
        yield return new WaitUntil(() => Mathf.Abs(dest - player.transform.eulerAngles.y) < 10);
    }
 
    void Start()
    {
        dest = player.transform.eulerAngles.y;
    }

    void Update()
    {
        if (CompassInit.compassInitialized)
        {
            player.transform.eulerAngles = Vector3.Lerp(player.transform.eulerAngles, Vector3.up * dest, Time.deltaTime);
            
            //player.transform.eulerAngles += angle.normalized * speed * Time.deltaTime;
        }
    }
}
