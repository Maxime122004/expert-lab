using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
        {
            moveInput = -1f;
            Debug.Log("Left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveInput = 1f;
            Debug.Log("Right");
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

    }
}
