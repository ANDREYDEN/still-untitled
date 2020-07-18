using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private Vector3 velocity = new Vector3(0, 0, -20f);

    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
