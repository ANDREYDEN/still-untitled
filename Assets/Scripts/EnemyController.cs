using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyController : MonoBehaviour
{
    private float _timeBeforeShot;

    [Range(1, 10)]
    public float velocity;
    public float pauseBetweenShots;

    [Inject] Player player;
    [Inject] DiContainer Container;


    private void Start()
    {
        _timeBeforeShot = pauseBetweenShots;
    }

    private void Update()
    {
        float deltaDistance = velocity * Time.deltaTime * GameManager.TimeScale;
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, deltaDistance);

        _timeBeforeShot -= Time.deltaTime * GameManager.TimeScale;
        if (_timeBeforeShot < 0)
        {
            _timeBeforeShot = pauseBetweenShots;
            Shoot();
            Debug.Log("EXTERMINATE!!!");
        }
    }

    private void Shoot()
    {
        Vector3 bulletSpawn = transform.position + 1.5f * Vector3.up;
        BulletController bulletController = Container.InstantiatePrefabResourceForComponent<BulletController>("Bullet", bulletSpawn, Quaternion.identity, transform);
        bulletController.direction = player.transform.position - transform.position;
        bulletController.velocity = 20;
    }
}
