using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyController : MonoBehaviour
{
    [Range(1, 10)]
    public float velocity;

    [Inject]
    Player player;

    void Update()
    {
        float deltaDistance = velocity * Time.deltaTime * GameManager.TimeScale;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, deltaDistance);
    }
}
