using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassData : MonoBehaviour
{
    Text _textComponent;

    void Start()
    {
        _textComponent = GetComponent<Text>();
        Input.compass.enabled = true;
        Input.location.Start();
    }

    // Update is called once per frame
    void Update()
    {
        _textComponent.text = Input.compass.magneticHeading + " " + Input.compass.rawVector;
    }
}
