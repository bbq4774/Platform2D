using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    private Animator anima;
    private Rigidbody2D rb;
    private Vector3 firtPosition;

    [SerializeField] private float timeFalling = 1f;

    private void Awake()
    {
        anima = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        firtPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Invoke(nameof(FallingDown), timeFalling);
    }

    private void FallingDown()
    {
        anima.SetTrigger("off");

        //Set falling
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 3;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.enabled = false;

        Invoke(nameof(DisableObj), 2f);
    }

    private void ResetObj()
    {
        rb.bodyType = RigidbodyType2D.Static;
        transform.position = firtPosition;
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        box.enabled = true;
        transform.gameObject.SetActive(true);
    }

    private void DisableObj()
    {
        transform.gameObject.SetActive(false);
        Invoke(nameof(ResetObj), 5f);
    }
}
