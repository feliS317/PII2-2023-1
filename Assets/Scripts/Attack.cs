using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [Header("Componentes")]
    [SerializeField] private BoxCollider2D hitbox;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator weapon;
    [Header("Values")]
    [SerializeField] private float damage = 10f;
    [SerializeField] private float atkCooldown = 0.8f;
    public bool attacking = false;
    private bool canAttack = true;
    [SerializeField] AudioClip[] sfx;
    [SerializeField] AudioController controller;
    int randomSfx;
    
    void Start()
    {
        controller = GameObject.Find("Audio").GetComponent<AudioController>();
        hitbox.enabled = false;
    }

    public void Left()
    {
        hitbox.transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    public void Right()
    {
        hitbox.transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void AttackAnimation()
    {
        if(canAttack)
        {
            randomSfx = Random.Range(0, 3);
            controller.PlaySfx(sfx[randomSfx]);
            attacking = true;
            hitbox.enabled = true;
            animator.SetBool("isAttacking", true);
            weapon.SetBool("isAttacking", true);
        }
    }

    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
        weapon.SetBool("isAttacking", false);
        attacking = false;
        hitbox.enabled = false;
        StartCoroutine(AttackCooldown(atkCooldown));
    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy" && attacking == true)
        {
            other.GetComponent<Health>().UpdateHealth(-damage);
        }
    }*/

    public IEnumerator AttackCooldown(float atkCooldown)
    {
        canAttack = false;
        yield return new WaitForSeconds(atkCooldown);
        canAttack = true;
    }
}