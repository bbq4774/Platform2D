using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] private float force = 10f;

    private void Update()
    {
        Fly();
    }

    private void Fly()
    {
        transform.Translate(force * Time.deltaTime * Vector2.left);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpawnObj.Instance.Despawn(transform);
    }
}
