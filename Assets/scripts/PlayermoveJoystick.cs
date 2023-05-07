using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayermoveJoystick : MonoBehaviour
{

    private float horizontalMove = 0f;

    private float verticalMove = 0f;

    public Joystick joystick;


    public float runSpeedHorizontal = 2;

    public float runSpeed = 2;

    public float jumpSpeed = 3;

    public float doubleJumpSpeed = 2.5f;

    private bool canDoubleJump;

    Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;

    public Animator animator;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("corre", true);
        }

        else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("corre", true);

        }

        else
        {
            animator.SetBool("corre", false);
        }


        if (colaiderpatas.isGrounded == false)
        {
            animator.SetBool("salto", true);
            animator.SetBool("corre", false);
        }

        if (colaiderpatas.isGrounded == true)
        {
            animator.SetBool("salto", false);
            animator.SetBool("doble salto", false);
            animator.SetBool("caida", false);
        }

        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("caida", true);
        }
        else if (rb2D.velocity.y > 0)
        {
            animator.SetBool("caida", false);
        }
    }


    void FixedUpdate()
    {

        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;

    }

    public void Jump()
    {
        if (colaiderpatas.isGrounded)
        {
            canDoubleJump = true;
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        }
        else
        {

            if (canDoubleJump)
            {
                animator.SetBool("doble salto", true);
                rb2D.velocity = new Vector2(rb2D.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }

        }
    }
}
