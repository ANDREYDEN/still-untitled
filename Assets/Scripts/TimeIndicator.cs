using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeIndicator : MonoBehaviour
{
    public TMP_Text textComponent;

    private float secondsLeft = 60;

    void Update()
    {
        secondsLeft -= Time.deltaTime * GameManager.TimeScale;
        textComponent.text = Mathf.FloorToInt(secondsLeft).ToString();         
    }
}
