using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(transform.gameObject);

        ItemsCollector.Instance.coins++;
        Collected.Instance.CreateAnimaCollected(transform.position);
    }
}
