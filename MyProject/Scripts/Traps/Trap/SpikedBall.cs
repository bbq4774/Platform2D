using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedBall : BaseTrap
{
    [SerializeField] private float speed = 200;

    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
