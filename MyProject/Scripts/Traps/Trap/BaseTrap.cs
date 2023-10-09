using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerControl>() != null)
        {
            HPPlayer.Instance.DeductHP();
        }
    }
}
