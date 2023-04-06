using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

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
        if(rb.velocity.x < 0)
        {
            sr.flipX = true;
        }
        else if(rb.velocity.x > 0)
        {
            sr.flipX = false;
        }
    }

    void JumpingAndFalling()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, 0.1f, ground);
        if(isGrounded)
        {
            canDoubleJump = true;
        }
        if(Input.GetButtonDown("Jump")){
            if(isGrounded || canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                if(!isGrounded && canDoubleJump)
                {
                    canDoubleJump = false;
                }
            }    
        }
    }
}
