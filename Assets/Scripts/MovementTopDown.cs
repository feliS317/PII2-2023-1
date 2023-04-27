using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTopDown : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hitbox;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private Animator weapon;

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
        weapon = hitbox.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        Attack();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(characterSpeed * Input.GetAxisRaw("Horizontal"), characterSpeed * Input.GetAxisRaw("Vertical"));
    }

    void MovementUpdate()
    {
        anim.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("Vertical", Input.GetAxisRaw("Vertical"));
        anim.SetFloat("Speed", rb.velocity.sqrMagnitude);
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            characterSpeed = runSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            characterSpeed = walkSpeed;
        }
        LastDirection();
    }

    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            hitbox.GetComponent<Attack>().AttackAnimation();
        }
    }

    void LastDirection()
    {
        if(Input.GetAxisRaw("Horizontal") > 0){
            anim.SetFloat("Dir", 1);
            weapon.SetFloat("Dir", 1);
        }
        if(Input.GetAxisRaw("Horizontal") < 0){
            anim.SetFloat("Dir", 3);
            weapon.SetFloat("Dir", 3);
        }
        if(Input.GetAxisRaw("Vertical") > 0){
            anim.SetFloat("Dir", 0);
            weapon.SetFloat("Dir", 0);
        }
        if(Input.GetAxisRaw("Vertical") < 0){
            anim.SetFloat("Dir", 2);
            weapon.SetFloat("Dir", 2);
        }   
    }

    public void EndAttack()
    {
        hitbox.GetComponent<Attack>().EndAttack();
    }
    
}
