using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    public Vector3 direction;
    public float velocity;
    public float despawnRadius = 100;

    void Update()
    {
        transform.position += direction.normalized * velocity * Time.deltaTime * GameManager.TimeScale;        

        if (transform.position.magnitude > despawnRadius)
        {
            Destroy(gameObject);
        }
    }
}
