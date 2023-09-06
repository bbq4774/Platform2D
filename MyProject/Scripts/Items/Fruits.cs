using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(transform.gameObject);

        ItemsCollector.Instance.fruits++;
        Collected.Instance.CreateAnimaCollected(transform.position);
    }
}
