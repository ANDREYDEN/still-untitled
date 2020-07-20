using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyController : MonoBehaviour
{
    [Range(0, 5)]
    public float velocity;
    public float visibleRadius;

    [Inject] Player player;

    private bool CanSee(Vector3 position)
    {
        return Vector3.Distance(transform.position, position) < visibleRadius;
    }

    private void Update()
    {
        if (CanSee(player.transform.position))
        {
            float deltaDistance = velocity * Time.deltaTime * GameManager.TimeScale;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, deltaDistance);
            transform.LookAt(player.transform);
        }
    }
}
