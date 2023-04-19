using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTopDown : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Animator anim;

    [Header("Movimiento")]
    private float characterSpeed;
    public float walkSpeed;
    public float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        characterSpeed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
    }

    void MovementUpdate()
    {
        rb.velocity = new Vector2(characterSpeed * Input.GetAxisRaw("Horizontal"), characterSpeed * Input.GetAxisRaw("Vertical"));
        if(rb.velocity.x > 0){
            anim.SetBool("isMoving", true);
        }
        else{
            anim.SetBool("isMoving", false);
        }
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            characterSpeed = runSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            characterSpeed = walkSpeed;
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
}
