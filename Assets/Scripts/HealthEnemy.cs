using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private float maxHealth = 20f;
    
    private GameObject player;
    private Attack playerAttack;
    private Animator anim;
    public float health;
    private bool attacked = false;
    public static string level;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("AttackPlayer");
        playerAttack = player.GetComponent<Attack>();
        anim = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(attacked)
        {
            if(!playerAttack.attacking)
            {
                attacked = false;
            }
        }
    }

    public void UpdateHealth(float mod)
    {       
        if(!attacked)
        {   
            health += mod;
            if(mod < 0)
            {
                attacked = true;
            }
            else if(health > maxHealth)
            {
                health = maxHealth;
            }
            if(health <= 0)
            {
                Die();
            }
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
