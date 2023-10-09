using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour
{
    private Animator anima;
    [SerializeField] private int hp = 1;
    [Header("Check hitted by player")]
    [SerializeField] private Transform whereIsHitted;
    [SerializeField] private LayerMask player;
    [SerializeField] private Vector2 boxSize = new(1.24f, 0.2f);

    private void Awake()
    {
        anima = GetComponent<Animator>();    
    }

    private void Update()
    {
        IsHitting();
    }

    private void IsHitting()
    {
        if (!Physics2D.BoxCast(whereIsHitted.position, boxSize, 0, Vector2.down, 0.1f, player)) return;
        if (!(PlayerControl.Instance.VelocityY <= -10f)) return;

        hp--;
        anima.SetBool("isHitted", true);
        Invoke(nameof(SetIsHitted), 0.2f);
        if (hp == 0)
            Invoke(nameof(IsBreak), 0.2f);
    }

    private void IsBreak()
    {
        CreateBoxBreak.Instance.CreateBoxBreaks(transform.position);
        Destroy(transform.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(whereIsHitted.position, boxSize);
    }

    private void SetIsHitted()
    {
        anima.SetBool("isHitted", false);
    }
}
