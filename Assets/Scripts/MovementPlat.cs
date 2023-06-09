using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlat : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;

    [Header("Movimiento")]
    public float characterSpeed;

    [Header("Salto")]
    private bool canDoubleJump = true;
    public float jumpForce;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask ground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        JumpingAndFalling();
    }

    void MovementUpdate()
    {
        rb.velocity = new Vector2(characterSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y);
        if(rb.velocity.x > 0){
            anim.SetBool("isMoving", true);
        }
        else{
            anim.SetBool("isMoving", false);
        }
        /*if(rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x > 0)
        {
            sr.flipX = false;
        }*/
    }

    void JumpingAndFalling()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, 0.1f, ground);
        if(isGrounded)
        {
            canDoubleJump = true;
            anim.SetBool("isJumping", false);
        }
        if(Input.GetButtonDown("Jump")){
            if(isGrounded || canDoubleJump)
            {
                anim.SetBool("isJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                if(!isGrounded && canDoubleJump)
                {
                    canDoubleJump = false;
                }
            }    
        }
    }
}
