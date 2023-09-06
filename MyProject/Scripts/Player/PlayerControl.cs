using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private static PlayerControl instance;
    public static PlayerControl Instance => instance;

    private Rigidbody2D rb2D;
    private float jumpForce = 14f;
    private float speed = 10f;
    private bool canDoubleJump = true;

    private float horizontal;
    public float Horizontal => horizontal;
    private float velocityY;
    public float VelocityY => velocityY;
    private bool isRunning;
    public bool IsRunning => isRunning;
    private bool isHitting = false;
    public bool IsHit => isHitting;
    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    /*private bool isDoubleJumping;
    public bool IsDoubleJumping => isDoubleJumping;*/

    [Header("Ground check info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Vector2 boxSizeGround = new(0.9f, 0.1f);

    [Header("Wall check info")]
    [SerializeField] private float wallCheckDistance = 0.6f;
    [SerializeField] private bool isWallDetected;
    [SerializeField] private bool isWallSliding;
    public bool IsWallSliding => isWallSliding;

    private void Awake()
    {
        PlayerControl.instance = this;

        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetInput();
        WallSlide();
        SetWallCheckDistance();
        GroundedCheck();
        CheckIsDie();
    }

    private void WallSlide()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            return;
        }

        if (isWallSliding)
            rb2D.velocity = new(rb2D.velocity.x, rb2D.velocity.y * 0.1f);
    }

    private void GetInput()
    {
        velocityY = rb2D.velocity.y;
        /*if (rb2D.velocity.y < 0)
            isDoubleJumping = false;*/

        horizontal = Input.GetAxisRaw("Horizontal");
        Run();
    }

    private void Run()
    {
        isRunning = (horizontal != 0);
        rb2D.velocity = new(horizontal * speed, rb2D.velocity.y);
    }

    private void Jump()
    {
        if (isGrounded || isWallSliding)
        {
            rb2D.velocity = new(rb2D.velocity.x, jumpForce);
        }
        else if (canDoubleJump && !isWallSliding)
        {
            rb2D.velocity = new(rb2D.velocity.x, jumpForce);
            //isDoubleJumping = true;
            canDoubleJump = false;
        }
    }

    private void GroundedCheck()
    {
        isGrounded = Physics2D.BoxCast(groundCheck.position, boxSizeGround, 0, Vector2.down, 0.1f, whatIsGround);
        isWallDetected = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, whatIsGround);

        if (isGrounded)
            canDoubleJump = true;
        if (!isGrounded && rb2D.velocity.y < 0 && isWallDetected)
            isWallSliding = true;
        else
            isWallSliding = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(groundCheck.position, boxSizeGround);
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + wallCheckDistance, transform.position.y));
    }

    public void IsHitting()
    {
        isHitting = true;
        Invoke(nameof(SetIsHittingFalse), 0.3f);
    }

    private void SetIsHittingFalse()
    {
        isHitting = false;
    }

    private void CheckIsDie()
    {
        if (HPPlayer.Instance.IsDie)
        {
            speed = 0;
            jumpForce = 0;
        }
    }

    private void SetWallCheckDistance()
    {
        if (rb2D.velocity.x < 0)
            wallCheckDistance = -0.6f;
        else if (rb2D.velocity.x > 0)
            wallCheckDistance = 0.6f;
    }
}
