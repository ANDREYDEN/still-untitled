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
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 deltaMovement = transform.TransformDirection(new Vector3(joystick.Horizontal, 0, joystick.Vertical) * movementSpeed);

        transform.position += deltaMovement;
        Time.timeScale = deltaMovement.magnitude;
        Time.fixedDeltaTime *= Time.timeScale;
    }

    private void Rotate()
    {
        float newY = 0;
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                newY = transform.eulerAngles.y + rotationSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                newY = transform.eulerAngles.y - rotationSpeed;
            }
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            newY = Input.compass.magneticHeading;
        }
        
        transform.eulerAngles = Vector3.up * newY;
    }
}
