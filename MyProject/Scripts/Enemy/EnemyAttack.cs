using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : EnemyMove
{
    [Header("Check Attack")]
    [SerializeField] protected LayerMask player;
    [SerializeField] private bool isAttack;
    [SerializeField] private float disCheckAttack;

    private float countTime = 0f;
    private readonly float timeAttack = 2f;
    private bool canAttack = false;

    protected override void Update()
    {
        CheckAttack();
        CheckSendDam();
        base.Update();
    }

    private void CheckSendDam()
    {
        countTime += Time.deltaTime;
        if (countTime >= timeAttack)
        {
            canAttack = true;
        }
    }

    private void CheckAttack()
    {
        isAttack = Physics2D.Raycast(transform.position, Vector2.right, disCheckAttack, player);

        if (isAttack && canAttack)
        {
            countTime = 0f;
            canAttack = false;
            HPPlayer.Instance.DeductHP();
        }
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

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new(transform.position.x + disCheckAttack,
                                                transform.position.y));
    }
}
