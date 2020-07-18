using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float DELTA_Y = 0.1f;
    private float _cameraY = 0;

    void Update()
    {
        _cameraY = GetCameraRotation();

        Camera.main.transform.eulerAngles = Vector3.up * _cameraY;
    }

    private float GetCameraRotation()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return _cameraY + DELTA_Y;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                return _cameraY - DELTA_Y;
            }
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            return Input.compass.magneticHeading;
        }
        return _cameraY;
    }
}
