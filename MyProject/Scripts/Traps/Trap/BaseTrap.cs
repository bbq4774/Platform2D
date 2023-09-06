using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrap : MonoBehaviour
{
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        HPPlayer.Instance.DeductHP();
    }
}
