using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDam : BaseTrap
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (Fire.Instance.IsOn)
            base.OnTriggerStay2D(collision);
    }
}
