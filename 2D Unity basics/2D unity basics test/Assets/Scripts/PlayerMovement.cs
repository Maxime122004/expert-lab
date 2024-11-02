using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isGrounded = false;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
            Debug.Log("Left");
            spriteRenderer.flipX = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
            Debug.Log("Right");
            spriteRenderer.flipX = false;

        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        bool isRunning = moveInput != 0;
        animator.SetBool("isRunning", isRunning);
        animator.SetFloat("moveDirection", moveInput);

        // Jumping
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space)) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Not grounded");
        }
    }
}
