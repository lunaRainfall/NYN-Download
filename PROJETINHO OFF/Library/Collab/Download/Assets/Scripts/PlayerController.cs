using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    //public float speed;
    private float moveInput;
    private bool lKey;
    private bool rKey;
    private bool facingRight = true;
    public Vector2 jumpHeight;

    public float spd;
    private float atualSpdH;
    public float frict;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    //public int extraJumpValue;
    //private int extraJumps;
    private bool jump = false;
	public Animator animator;
	public SpriteRenderer renderer;

    void Start() {
    
        rb = GetComponent<Rigidbody2D>();
        
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
       
        //moveInput = Input.GetAxis("Horizontal");
        lKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        rKey = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);


        //rb.velocity = new Vector2(atualSpdH, rb.velocity.y);
		if (rKey == true)
		{
			renderer.flipX = true;
		}

		if (facingRight == true && lKey == true) {
			renderer.flipX = false;
		}

    }

    void Update() {
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(9, 11, true);
        Physics2D.IgnoreLayerCollision(9, 12, true);
		Physics2D.IgnoreLayerCollision(9, 13, true);
		Physics2D.IgnoreLayerCollision(9, 14, true);
		Physics2D.IgnoreLayerCollision(9, 15, true);
		Physics2D.IgnoreLayerCollision(9, 16, true);

		Debug.Log (isGrounded);
		animator.SetFloat ("Movespeed", Mathf.Abs(atualSpdH));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
			animator.SetBool ("Midair", true);
			animator.SetTrigger ("JumpTrigger");
        }

		if (isGrounded)
		{
			animator.SetBool ("Midair", false);
		}


        else if (Input.GetKeyDown(KeyCode.UpArrow) && jump == false && isGrounded == true)
        {
            // jump = true;
            //rb.velocity = Vector2.up * jumpForce;
        }
        // THE PUTARIA BEGINS+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        if (lKey)
        {
           // facingRight = false;
            
            if (atualSpdH > -spd)
            {
                atualSpdH -= frict;
            }
            else
            {
                atualSpdH = -spd;
            }

        }
        if (rKey)
        {
            //facingRight = true;
           
            if (atualSpdH < spd)
            {
                atualSpdH += frict;
            }
            else
            {
                atualSpdH = spd;
            }
            //x += atualSpdH;
        }

        //Checando por teclas soltas
        if ((!lKey && !rKey) || (lKey && rKey))
        {
            if (atualSpdH != 0)
            {
                if (atualSpdH < 0)
                {
                    atualSpdH += frict;
                    
                }
                else {
                    atualSpdH -= frict;
                    
                }
            }
        }

        rb.velocity = new Vector2(atualSpdH, rb.velocity.y);
        //THE PUTARIA ENDS--------------------------------------------------------------------------

    }
}

