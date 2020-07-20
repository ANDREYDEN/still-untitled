using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;

public class CompassDataHandler : MonoBehaviour
{
    public GameObject player;

    private float dest;

    void Start()
    {
        dest = Input.compass.trueHeading;
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Time.time > 20)
            {
                dest = (int)(Input.compass.trueHeading / 10) * 10;
            }
            else
            {
                if (Mathf.Abs(Input.compass.trueHeading - player.transform.eulerAngles.y) > 10)
                {
                    dest = Input.compass.trueHeading;
                }
            }
            player.transform.eulerAngles = Vector3.Lerp(player.transform.eulerAngles, Vector3.up * dest, Time.deltaTime);
        }
    }
}
