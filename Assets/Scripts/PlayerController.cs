using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public VariableJoystick joystick;

    const float DELTA_Y = 1f;
    private float _cameraY = 0;

    void Update()
    {
        _cameraY = GetCameraRotation();
        transform.position += new Vector3(joystick.Horizontal, 0, joystick.Vertical);

        transform.eulerAngles = Vector3.up * _cameraY;
    }

    private float GetCameraRotation()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return _cameraY - DELTA_Y;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                return _cameraY + DELTA_Y;
            }
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            return Input.compass.magneticHeading;
        }
        return _cameraY;
    }
}
