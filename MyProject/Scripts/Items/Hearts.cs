using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!HPPlayer.Instance.CanAddHp()) return;

        HPPlayer.Instance.AddHP();
        Destroy(transform.gameObject);
        Collected.Instance.CreateAnimaCollected(transform.position);
    }
}
