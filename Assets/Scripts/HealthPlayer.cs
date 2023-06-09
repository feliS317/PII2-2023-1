using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private bool enemy;
    [SerializeField] private float maxHealth = 20f;
    
    private GameObject player;
    private Collider2D hitbox;
    private Animator anim;
    public float health;
    private bool attacked = false;
    public static string level;
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealth(float mod)
    {       
        health += mod;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        anim.SetTrigger("Dead");
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
