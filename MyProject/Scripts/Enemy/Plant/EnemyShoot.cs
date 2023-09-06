using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Info shoot")]
    [SerializeField] private float timeShootDelay = 1f;
    [SerializeField] private float countTime = 0f;
    [SerializeField] private Transform pointShoot;
    [SerializeField] private Transform bullet;

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        countTime += Time.deltaTime;
        if (countTime >= timeShootDelay)
        {
            Transform newBullet = SpawnObj.Instance.Spawn(bullet);
            newBullet.position = pointShoot.position;
            countTime = 0f;
        }
    }
}
