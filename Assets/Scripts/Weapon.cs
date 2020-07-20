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
        Vector3 spawnPoint = transform.position;
        MissileController missileController = Container.InstantiatePrefabForComponent<MissileController>(missileResource,
                                                                                                         spawnPoint,
                                                                                                         Quaternion.identity,
                                                                                                         _missileParent.transform);
        missileController.transform.LookAt(player.transform);
    }
}
