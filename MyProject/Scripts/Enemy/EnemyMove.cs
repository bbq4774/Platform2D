using UnityEngine;

public class EnemyMove : MovePoints
{
    protected SpriteRenderer sprite;
    protected Animator anima;

    protected bool isIdle = false;
    protected readonly float timeToIdle = 4f;
    protected float countTimeToIdle = 0;
    protected readonly float timeIdle = 2f;

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
    }

    protected override void MoveToPoint()
    {
        if (isIdle) return;
        base.MoveToPoint();
    }
}
