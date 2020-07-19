using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public float velocity;
    public float despawnRadius = 100;

    void Update()
    {
        transform.position += transform.forward * velocity * Time.deltaTime * GameManager.TimeScale;        

        if (transform.position.magnitude > despawnRadius)
        {
            Destroy(gameObject);
        }
    }
}
