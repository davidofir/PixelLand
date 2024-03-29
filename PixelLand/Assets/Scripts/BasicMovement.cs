using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    private BoxCollider2D coll;
    float jumpForce = 0.25f;
    float speed = 5f;
    [SerializeField] private LayerMask jumpableGround;
    private SpriteRenderer sprite;
    private float dirX = 0.0f;
    public float KBForce;
    public float KBCounter = 0;
    public float KBTotalTime;
    public bool KnockFromRight;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveVertically();
        if (Input.GetButton("Jump") && IsGrounded())
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    public void MoveVertically()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (KBCounter < 0)
        {
            rb.velocity = new Vector2(dirX * speed, rb.velocity.y);
        }
        else
        {
            float horizontalForce = KnockFromRight ? -KBForce : KBForce;
            rb.velocity = new Vector2(horizontalForce * 5, rb.velocity.y + 0.1f); // Apply horizontal knockback only
            
        }
        KBCounter -= Time.deltaTime;

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, 14f);
        }
        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        if (dirX > 0f)
        {
            animator.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            animator.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            animator.SetBool("running", false);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size,0f,Vector2.down,.1f,jumpableGround);
    }
}
