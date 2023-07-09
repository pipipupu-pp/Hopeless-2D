using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 1f;
    public float jumpingPower = 16f;
    private bool isfacingRight = true;

    public Rigidbody2D rb;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public Animator animator;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (IsGrounded() && horizontal != 0)
        {
                animator.SetTrigger("GoWalk");
            }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                animator.SetTrigger("GoJump");
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if (isfacingRight && horizontal < 0f || !isfacingRight && horizontal > 0f)
        {
            isfacingRight = !isfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, groundLayer);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject.CompareTag("Ground"))
            {
                Debug.Log("Grounded");
                return true;
            }
        }
        return false;
    }
}