using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowDeltaAngle : MonoBehaviour
{
    public CompassDataHandler compassDataHandler;
    public TMP_Text textComponent;

    private void Update()
    {
        textComponent.text = (compassDataHandler.prevAngle).ToString();
    }
}
