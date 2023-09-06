using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyMove
{
    [Header("Check Attack")]
    [SerializeField] private bool isAttack;
    [SerializeField] private float disCheckAttack;

    protected override void Update()
    {
        CheckAttack();
        base.Update();
    }

    private void CheckAttack()
    {
        isAttack = Physics2D.Raycast(transform.position, Vector2.right, disCheckAttack, player);
    }

    protected override void Animation()
    {
        anima.SetBool("isAttack", isAttack);
        base.Animation();
    }

    protected override void MoveToPoint()
    {
        if (isIdle || isAttack) return;
        base.MoveToPoint();
    }

    protected override void ChangeFace()
    {
        if (Vector2.Distance(transform.position, point.position) < 0.1f)
        {
            sprite.flipX = !sprite.flipX;
            disCheckAttack *= (-1);
        }
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new(transform.position.x + disCheckAttack,
                                                transform.position.y));
        base.OnDrawGizmos();
    }

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (!isAttack) return;
        base.OnTriggerStay2D(collision);
    }
}
