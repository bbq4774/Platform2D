using UnityEngine;

public class EnemyMove : MovePoints
{
    protected SpriteRenderer sprite;
    protected Animator anima;

    protected bool isDie = false;
    protected bool isIdle = false;
    protected readonly float timeToIdle = 4f;
    protected float countTimeToIdle = 0;
    protected readonly float timeIdle = 2f;

    [Header("Check hitted by player")]
    [SerializeField] protected Transform whereIsHitted;
    [SerializeField] protected LayerMask player;
    [SerializeField] protected Vector2 boxSize;

    protected readonly float randomDirX = 0;
    protected readonly float randomDirY = 150f;

    protected void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        anima = GetComponent<Animator>();
    }

    protected override void Update()
    {
        ChangeFace();
        CheckIdle();
        Animation();
        IsHitted();
        base.Update();
    }

    protected virtual void ChangeFace()
    {
        if (Vector2.Distance(transform.position, point.position) < 0.1f)
            sprite.flipX = !sprite.flipX;
    }

    protected void CheckIdle()
    {
        if (isIdle) return;
        countTimeToIdle += Time.deltaTime;
        if (countTimeToIdle >= timeToIdle)
        {
            isIdle = true;
            Invoke(nameof(ResetIdle), timeIdle);
        }
    }

    protected void ResetIdle()
    {
        isIdle = false;
        countTimeToIdle = 0;
    }

    protected virtual void Animation()
    {
        anima.SetBool("isIdle", isIdle);
        anima.SetBool("isDie", isDie);
    }

    protected override void MoveToPoint()
    {
        if (isIdle) return;
        base.MoveToPoint();
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
        rigid.AddForce(new(randomDirX, randomDirY));
        Invoke(nameof(DisableObj), 2f);
    }

    protected void DisableObj()
    {
        transform.parent.gameObject.SetActive(false);
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        HPPlayer.Instance.DeductHP();
    }
}
