using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public Vector3 direction;
    public float velocity;

    void Update()
    {
        transform.position += direction.normalized * velocity * Time.deltaTime * GameManager.TimeScale;        
    }
}
