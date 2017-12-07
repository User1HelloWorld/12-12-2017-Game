using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    //Health variables for the player.
    public int maxHealth;
    public int currentHealth;

    // Use this for initialization
    void Start()
    {
        //Health will be full on startup.
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            //If at 0 health, enemy is destroyed, enemy is not respawned.
            Destroy(gameObject);
        }
    }

    //This subroutine is called by another script.
    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    //Also called by another script.
    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
