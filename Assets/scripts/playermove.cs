using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    //velocidades
    public float runSpeed=2;

    public float jumpSpeed=3;

    public float doubleJumpSpeed=2.5f;

    private bool canDoubleJump;

    private float tiempocoyotetime = 0.2f;

    Rigidbody2D rb2D;

    //tiempos
    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    private bool coyotetime = false;
        
    private float tiempocoyote;


    void Start()
    {
     rb2D = GetComponent<Rigidbody2D>();   
    }

    /*void checktocasuelo()
    {
        //coyote time
        if (colaiderpatas.isGrounded)
        {
            coyotetime = true;
            tiempocoyote = 0f;
        }
        else
        {
            tiempocoyote += Time.deltaTime;
        }

        if (Input.GetKey("space") || Input.GetKey("w") || Input.GetKey("up"))
        {
            //control salto coyote time
            if (colaiderpatas.isGrounded == true)
            {
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
            }

            else
            {
                if (tiempocoyote < 0,25f)
                {
                    rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
                }
            }
        }  
    }*/

    //salto
    private void Update()
    {
        /*if (IsGrounded())
        {
            tiempocoyote = tiempocoyotetime;
        }
        else
        {
            tiempocoyote -= Time.deltaTime;
        }*/

        if (/*tiempocoyote > 0f &&*/Input.GetKey("space")  || Input.GetKey("w")  || Input.GetKey("up"))
        {
            //salto
            if (colaiderpatas.isGrounded)
            {
                canDoubleJump = true;
                rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);

            }

            //salto doble
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


        //animaciones salto
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

        //velocidad salto
        if (rb2D.velocity.y < 0)
        {
            animator.SetBool("caida", true);
        }
        else if(rb2D.velocity.y > 0) 
        {
            animator.SetBool("caida", false);
            /*tiempocoyote = 0f;*/
        }
    }

    //control de movimiento
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

       //movimiento en el aire
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
