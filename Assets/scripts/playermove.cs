using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{

    public float runSpeed=2;

    public float jumpSpeed=3;

    public float doubleJumpSpeed=2.5f;

    private bool canDoubleJump;

    Rigidbody2D rb2D;


    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;


    void Start()
    {
     rb2D = GetComponent<Rigidbody2D>();   
    }

    private void Update()
    {
        if (Input.GetKey("space")  || Input.GetKey("w")  || Input.GetKey("up"))
        {
            if (colaiderpatas.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }

            else
            {
                if(Input.GetKeyDown("space") || Input.GetKeyDown("w") || Input.GetKeyDown("up"))
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



        if (colaiderpatas.isGrounded == false)
        {
            animator.SetBool("salto", true);
            animator.SetBool("corre", false);
        }

        if (colaiderpatas.isGrounded == true)
        {
            animator.SetBool("salto", false);
            animator.SetBool("caida", false);
            animator.SetBool("doble salto", false);
        }

        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("caida", true);
        }
        else if(rb2D.velocity.y > 0) 
        {
            animator.SetBool("caida", false);
        }
    }


    void FixedUpdate()
    {

        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2 (runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("corre", true);
        }

        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2 (-runSpeed, rb2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("corre", true);
            
        }

        else {
            rb2D.velocity = new Vector2 (0, rb2D.velocity.y);
            animator.SetBool("corre", false);
        }

       
        if (betterJump)
        {
            if (rb2D.velocity.y<0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }

            if(rb2D.velocity.y>0 && !Input.GetKey("space") && !Input.GetKey("w") && !Input.GetKey("up"))
            {
               rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }
}
