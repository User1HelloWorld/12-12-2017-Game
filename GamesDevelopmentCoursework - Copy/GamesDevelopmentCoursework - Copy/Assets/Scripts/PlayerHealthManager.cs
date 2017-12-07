using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour {

	//Health variables for the player.
	public int playerMaxHealth;
	public int playerCurrentHealth;

	// Use this for initialization
	void Start () {
		//Health will be full on startup.
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			//If the attached object has 0 health, deactivate object and respawn.
			gameObject.SetActive(false);
		}
	}

	//This subroutine is called by another script.
	public void HurtPlayer(int damageToGive) {
		playerCurrentHealth -= damageToGive;
	}

	//Also called by another script.
	public void SetMaxHealth() {
		playerCurrentHealth = playerMaxHealth;
	}
}
