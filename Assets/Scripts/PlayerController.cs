using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    const float DELTA_Y = 1f;
    const float MOVEMENT_SENSITIVITY = 0.1f;

    public VariableJoystick joystick;

    private float _cameraY = 0;

    void Update()
    {
        Vector3 deltaMovement = transform.TransformDirection(new Vector3(joystick.Horizontal, 0, joystick.Vertical) * MOVEMENT_SENSITIVITY);
        transform.position += deltaMovement;
        Time.timeScale = deltaMovement.magnitude;
        Time.fixedDeltaTime *= Time.timeScale;

        _cameraY = GetCameraRotation();
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
