using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnima : MonoBehaviour
{
    private Animator anima;
    private SpriteRenderer sprite;

    private void Awake()
    {
        anima = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        UpdateAnimator();
        Flip();
    }

    private void UpdateAnimator()
    {
        anima.SetFloat("yVelocity", PlayerControl.Instance.VelocityY);
        anima.SetBool("isGrounded", PlayerControl.Instance.IsGrounded);
        anima.SetBool("isRunning", PlayerControl.Instance.IsRunning);
        anima.SetBool("isHitting", PlayerControl.Instance.IsHit);
        //anima.SetBool("isDoubleJumping", PlayerControl.Instance.IsDoubleJumping);
        anima.SetBool("isWallSliding", PlayerControl.Instance.IsWallSliding);

        if (HPPlayer.Instance.IsDie)
        {
            anima.SetTrigger("death");
        }
    }

    private void Flip()
    {
        if (PlayerControl.Instance.Horizontal < -0.01)
            sprite.flipX = true;
        else if (PlayerControl.Instance.Horizontal > 0.01)
            sprite.flipX = false;
    }
}
