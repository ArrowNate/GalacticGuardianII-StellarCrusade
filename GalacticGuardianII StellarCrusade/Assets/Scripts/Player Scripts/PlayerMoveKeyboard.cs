using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{
    [SerializeField] private float speed = 600f;
    [SerializeField] Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(transform.up * speed);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-transform.up * speed);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(transform.right * speed);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-transform.right * speed);
        }
    }
}