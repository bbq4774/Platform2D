using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIsHitted : MonoBehaviour
{
    protected Animator anima;

    [Header("Check hitted by player")]
    [SerializeField] protected Transform whereIsHitted;
    [SerializeField] protected LayerMask player;
    [SerializeField] protected Vector2 boxSize;

    protected readonly float randomDirX = 0;
    protected readonly float randomDirY = 150f;
    protected bool isDie = false;

    protected void Awake()
    {
        anima = GetComponent<Animator>();
    }

    private void Update()
    {
        IsHitted();
    }

    protected void IsHitted()
    {
        if (!Physics2D.BoxCast(whereIsHitted.position, boxSize, 0, Vector2.down, 0.1f, player)) return;
        if (!(PlayerControl.Instance.VelocityY <= -10f)) return;

        Die();
    }

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(whereIsHitted.position, boxSize);
    }

    protected void Die()
    {
        isDie = true;

        Rigidbody2D rigid = transform.GetComponent<Rigidbody2D>();
        rigid.gravityScale = 3;
        BoxCollider2D box = transform.GetComponent<BoxCollider2D>();
        box.enabled = false;
        rigid.AddForce(new(randomDirX, randomDirY));

        Invoke(nameof(DisableObj), 2f);
    }

    protected void DisableObj()
    {
        transform.parent.gameObject.SetActive(false);
    }


    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (isDie) return;
        if (collision.GetComponent<PlayerControl>() != null)
            HPPlayer.Instance.DeductHP();
    }
}
