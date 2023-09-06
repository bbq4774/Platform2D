using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPlatform : MonoBehaviour
{
    /*private Rigidbody2D rb;
    private Rigidbody2D platformRb;

    private bool isOnPlatform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        if (isOnPlatform)
            rb.velocity = rb.velocity + platformRb.velocity;
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(collision.transform);
            //isOnPlatform = true;
            //platformRb = collision.transform.GetComponent<Rigidbody2D>();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
            //isOnPlatform = false;
            //platformRb = null;
        }
    }
}
