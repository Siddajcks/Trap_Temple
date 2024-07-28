using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] AudioSource jumpAudio;
    [SerializeField] float jumpForce = 18f;
    [SerializeField] float runSpeed = 500f;
    float dirX;
    Rigidbody2D rb;
    BoxCollider2D collider2D;
    [SerializeField] LayerMask groundMask;
    SpriteRenderer spriteRenderer;
    Animator animator;
    private enum MovementState { idle, run, jump }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpAudio.Play();
        }

        HandleAnimation();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * runSpeed * Time.deltaTime, rb.velocity.y);
    }

    bool isGrounded()
    {
        return Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0, Vector2.down, 0.1f, groundMask);
    }
    
    void HandleAnimation()
    {
        MovementState state;
        
        if (dirX > 0)
        {
            spriteRenderer.flipX = false;
            state = MovementState.run;
        }
        else if (dirX < 0)
        {
            spriteRenderer.flipX = true;
            state = MovementState.run;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }

        animator.SetInteger("state", (int)state);
    }
}
