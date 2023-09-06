using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBreak : MonoBehaviour
{
    private float randomTorque;
    private float randomDirX;
    private float randomDirY;

    public void Start()
    {
        foreach (Transform obj in transform)
        {
            Rigidbody2D rigid = obj.GetComponent<Rigidbody2D>();

            randomTorque = Random.Range(-100f, 100f);
            randomDirX = Random.Range(-200f, 200f);
            randomDirY = Random.Range(-200f, 200f);
            rigid.AddTorque(randomTorque);
            rigid.AddForce(new(randomDirX, randomDirY));
        }
        Invoke(nameof(DestroyObj), 1f);
    }

    private void DestroyObj()
    {
        Destroy(transform.gameObject);
    }
}
