using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;

    [Range(0, 2)]
    public float rotationSpeed;
    [Range(0, 1000)]
    public float movementSpeed;
    public VariableJoystick joystick;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 deltaJoystick = new Vector3(joystick.Horizontal, 0, joystick.Vertical);
        Vector3 deltaMovement = transform.TransformDirection(deltaJoystick * movementSpeed * Time.fixedDeltaTime);

        _rigidBody.AddRelativeForce(deltaJoystick * movementSpeed * Time.fixedDeltaTime);
        GameManager.TimeScale = deltaJoystick.magnitude;
    }

    private void Rotate()
    {
        float newY = transform.eulerAngles.y;
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                newY = transform.eulerAngles.y - rotationSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                newY = transform.eulerAngles.y + rotationSpeed;
            }
        }
        if (Application.platform == RuntimePlatform.Android)
        {
            newY = Input.compass.magneticHeading;
        }
        
        transform.eulerAngles = Vector3.up * newY;
    }
}
