using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    private float _timeBeforeShot;
    private GameObject _missileParent;

    public GameObject missileResource;
    public float pauseBetweenShots;
    public float power;

    [Inject] Player player;
    [Inject] DiContainer Container;

    void Start()
    {
        _timeBeforeShot = pauseBetweenShots;
        _missileParent = GameObject.Find("Missiles");
    }

    void Update()
    {
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
        Vector3 bulletSpawn = transform.position;
        BulletController bulletController = Container.InstantiatePrefabForComponent<BulletController>(missileResource,
                                                                                                      bulletSpawn,
                                                                                                      Quaternion.identity,
                                                                                                      _missileParent.transform);
        bulletController.direction = player.transform.position - transform.position;
        bulletController.velocity = power;
    }
}
