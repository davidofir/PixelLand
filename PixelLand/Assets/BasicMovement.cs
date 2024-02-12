using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;
    Rigidbody2D rb;
    float jumpForce = 2f;
    float speed = 5f;
    private SpriteRenderer sprite;
    private float dirX = 0.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveVertically();
        if (Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    public void MoveVertically()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
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
}
