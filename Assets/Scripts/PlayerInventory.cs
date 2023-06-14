using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public float PlayerBank;
    public float PlayerPotions;
    public GameObject player;
    private bool drankPotion = false;
    void Start()
    {
        PlayerPotions = 0;
        PlayerBank = 0;
    }
    
    public void Potion()
    {
        if(PlayerPotions > 0 && !drankPotion)
        {
            player.GetComponent<HealthPlayer>().UpdateHealth(20);
            PlayerPotions--;
            StartCoroutine(CooldownPotion());
        }  
    }

    private IEnumerator CooldownPotion()
    {
        drankPotion = true;
        yield return new WaitForSeconds(2);
        drankPotion = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Potion"))
        {
            Destroy(other.gameObject);
            PlayerPotions += 1;
        }
        else if (other.CompareTag("Money"))
        {
            Destroy(other.gameObject);
            PlayerBank += 1;
        }
    }

    public void OverrideInventory(float potions, float money){
        PlayerPotions = potions;
        PlayerBank = money;
    }

}
