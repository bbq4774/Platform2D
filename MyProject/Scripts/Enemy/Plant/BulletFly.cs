using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float timeDespawn = 3f;
    [SerializeField] private float countTime = 0f;

    private void Update()
    {
        Fly();
        DespawnBytime();
    }

    private void DespawnBytime()
    {
        countTime += Time.deltaTime;
        if (countTime >= timeDespawn)
        {
            SpawnObj.Instance.Despawn(transform);
            countTime = 0f;
        }
    }

    private void Fly()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            Debug.Log("Deduct by BulletFly");
            HPPlayer.Instance.DeductHP();
        }

        SpawnObj.Instance.Despawn(transform);
    }
}
