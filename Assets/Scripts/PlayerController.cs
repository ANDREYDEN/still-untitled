using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0, 2)]
    public float rotationSpeed;
    [Range(0, 1)]
    public float movementSpeed;

    public VariableJoystick joystick;

    private float _cameraY = 0;

    void Update()
    {
        Vector3 deltaMovement = transform.TransformDirection(new Vector3(joystick.Horizontal, 0, joystick.Vertical) * movementSpeed);
        Move(deltaMovement);

        _cameraY = GetCameraRotation();
        transform.eulerAngles = Vector3.up * _cameraY;
    }

    private void Move(Vector3 deltaMovement)
    {
        transform.position += deltaMovement;
        Time.timeScale = deltaMovement.magnitude;
        Time.fixedDeltaTime *= Time.timeScale;
    }

    private float GetCameraRotation()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                return _cameraY - rotationSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                return _cameraY + rotationSpeed;
            }
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            return Input.compass.magneticHeading;
        }
        return _cameraY;
    }
}
