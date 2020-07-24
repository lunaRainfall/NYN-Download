using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour {
    [Header ("Inputs")]
    private bool lKey;
    private bool rKey;
    [HideInInspector] public bool facingRight = true;
    private bool isMoving = false;

    [Header ("Values")]
    public Vector2 jumpHeight;
    public float jumpForce;
    public float spd;

    [Header ("Inspector")]
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer renderer;

    [Header ("Ground Check")]
    public bool isGrounded;
    public Transform groundCheck;
    public Vector2 bottomOffset;
    public Vector2 bottomSquare;
    public Vector2 squareSize;
    public float checkRadius;
    public LayerMask whatIsGround;

    [Header("ParticleSystem")]
    public ParticleSystem dust;
    public ParticleSystem jumpDust;
    public ParticleSystem fallDust;
    public bool ableToDust = false;
    public Gradient particleColorGradient;


    //Audio
    [Header ("Audio")]
    public AudioSource charAudio;
    public AudioClip walk;
    public float walkingSoundDelay;
    private int cdAudioRun = 0;

    void Start() {  
        rb = GetComponent<Rigidbody2D>();
        charAudio.clip = walk;
    }

    void FixedUpdate() {
        //isGrounded = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, checkRadius, whatIsGround);
        //isGrounded = Physics2D.OverlapBox((Vector2)transform.position + bottomSquare, squareSize, 0f, whatIsGround);

        //moveInput = Input.GetAxis("Horizontal");
        lKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0;
        rKey = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0;


        //rb.velocity = new Vector2(atualSpdH, rb.velocity.y);


        
        if (rKey == true && facingRight == false && !lKey)
		{
            renderer.flipX = false;
            facingRight = true;
            if (isGrounded)
            {
                CreatDust();
            }
        }

		if (facingRight == true && lKey == true && !rKey) {
            renderer.flipX = true;
            facingRight = false;
            if (isGrounded)
            {
                CreatDust();
            }
        }
        



        /*
        if (Input.GetButton("Jump") && isGrounded == true)
        {
            //GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;
            animator.SetTrigger("JumpTrigger");
        }
        */

        // THE PUTARIA BEGINS+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        if ((lKey && rKey) && isGrounded)
        {
            x = 0;
        }

        Vector2 dir = new Vector2(x, y);

        Walk(dir);

        if(rb.velocity.x != 0)
        {
            animator.SetBool("Movement", true);
        }
        else
        {
            animator.SetBool("Movement", false);
        }

        
    }

    void Update() {
        animator.SetFloat("VelocityY", rb.velocity.y);
        Physics2D.IgnoreLayerCollision(9, 10, true);
        Physics2D.IgnoreLayerCollision(9, 11, true);
        Physics2D.IgnoreLayerCollision(9, 12, true);
		Physics2D.IgnoreLayerCollision(9, 13, true);
		Physics2D.IgnoreLayerCollision(9, 14, true);
		Physics2D.IgnoreLayerCollision(9, 15, true);
		Physics2D.IgnoreLayerCollision(9, 16, true);
        Physics2D.IgnoreLayerCollision(9, 18, true);
        //INICIO DAS ALTERAÇÕES 25/02/2020 (CORREÇÃO DE PULO)------------------------------------------
        isGrounded = Physics2D.OverlapBox((Vector2)transform.position + bottomSquare, squareSize, 0f, whatIsGround);
        
        if (Input.GetButtonDown("Jump") && isGrounded == true) 
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += Vector2.up * jumpForce;

            jumpDust.Play();

            animator.SetTrigger("JumpTrigger");
            //StartCoroutine(FallParticleSystemCD());
        }
        
        
        

        if (rb.velocity.y < -0.1f || rb.velocity.y > 0.1f) 
        {
            animator.SetBool("Midair", true);
        }
        else
        {
            animator.SetBool("Midair", false);
        }

        if(rb.velocity.y < -3)
        {
            ableToDust = true;
        }

        if(ableToDust && isGrounded)
        {
            ableToDust = false;
            GameObject dust = Instantiate(fallDust.gameObject, new Vector2(jumpDust.transform.position.x, jumpDust.transform.position.y), Quaternion.identity) as GameObject;
            Destroy(dust, 1.5f);
        }
        //FIM DAS ALTERAÇÕES 25/02/2020

        if (lKey && rKey)
        {
            rb.velocity = new Vector2 (0, rb.velocity.y);
        }

        //THE PUTARIA ENDS--------------------------------------------------------------------------
        //Audio begins

        if ((lKey || rKey && isGrounded == true) && !(lKey && rKey))
        {
            if (cdAudioRun == 0)
            {
                cdAudioRun = 1;
                StartCoroutine(Walking());
            }

        }
        if (isGrounded == false)
        {
            charAudio.Stop();
        }



        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }


    public void Walk(Vector2 direction)
    {
        //if (!(rKey && lKey)) { 
            rb.velocity = (new Vector2(direction.x * spd, rb.velocity.y));
        //}
    }

    public IEnumerator Walking()
    {
        if ((lKey || rKey && isGrounded == true) && !(lKey && rKey))
        {
            yield return new WaitForSeconds(walkingSoundDelay);
            cdAudioRun = 0;
            if (isGrounded == true)
            {
                if (lKey || rKey)
                {
                    charAudio.Play();
                }
            }
        }

    }

    void Flip(bool right)
    {
        facingRight = right;
        transform.rotation = Quaternion.Euler(0, right ? 0 : 180, 0);
        CreatDust();
    }

    void CreatDust()
    {
        //ParticleSystem.MainModule psMain = dust.main;
        //psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
        dust.Play();
    }

    private IEnumerator FallParticleSystemCD()
    {
        yield return new WaitForSeconds(0.4f);
        if (!isGrounded)
        {
            ableToDust = true;
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        var positions = new Vector2[] { bottomSquare};

        Gizmos.DrawWireCube((Vector2)transform.position + bottomSquare, squareSize);

    }
}


