using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTopDown : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hitbox;
    private HealthPlayer health;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private Animator weapon;
    private Vector2 movementAxis = Vector2.zero;

    public PlayerInput _playerInput;

    [Header("Movimiento")]
    
    private float characterSpeed;
    public float walkSpeed;
    public float runSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        characterSpeed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        weapon = hitbox.GetComponent<Animator>();
        health = this.GetComponent<HealthPlayer>();

    }

    // Update is called once per frame
    void Update()
    {
        movementAxis = _playerInput.actions["Movement"].ReadValue<Vector2>();
        Attack();
        if(!hitbox.GetComponent<Attack>().attacking)
        {
            MovementUpdate();
        }  
    }

    void FixedUpdate() {
        
    }

    void MovementUpdate()
    {
        rb.velocity = new Vector2(characterSpeed * movementAxis.x, characterSpeed * movementAxis.y);
        anim.SetFloat("Horizontal", movementAxis.x);
        anim.SetFloat("Vertical", movementAxis.y);
        anim.SetFloat("Speed", rb.velocity.sqrMagnitude);
        if(_playerInput.actions["Run"].IsPressed())
        {
            characterSpeed = runSpeed;
        }
        else
        {
            characterSpeed = walkSpeed;
        }
        LastDirection();
    }

    void Attack()
    {
        rb.velocity = Vector2.zero;
        if(_playerInput.actions["Attack"].WasPressedThisFrame())
        {
            hitbox.GetComponent<Attack>().AttackAnimation();
        }
    }

    void LastDirection()
    {
        if(Mathf.Abs(movementAxis.x) > Mathf.Abs(movementAxis.y))
        {
            if(movementAxis.x > 0){
                anim.SetFloat("Dir", 1);
                weapon.SetFloat("Dir", 1);
            }
            if(movementAxis.x < 0){
                anim.SetFloat("Dir", 3);
                weapon.SetFloat("Dir", 3);
            }
        }
        else if(Mathf.Abs(movementAxis.y) > Mathf.Abs(movementAxis.x))
        {
            if(movementAxis.y > 0){
                anim.SetFloat("Dir", 0);
                weapon.SetFloat("Dir", 0);
            }
            if(movementAxis.y < 0){
                anim.SetFloat("Dir", 2);
                weapon.SetFloat("Dir", 2);
            }
        }
    }

    public void EndAttack()
    {
        hitbox.GetComponent<Attack>().EndAttack();
    }
}
