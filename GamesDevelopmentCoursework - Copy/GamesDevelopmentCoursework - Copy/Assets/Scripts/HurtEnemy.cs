using UnityEngine;
using System.Collections;

public class HurtEnemy : MonoBehaviour {

    public int damageToGive;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	//when something moves into the trigger box, check if it is an enemy.
	void OnTriggerEnter2D(Collider2D other) {
		//Want to use a tag so that it can be given to all enemies.
		if (other.gameObject.tag == "Enemy") {
			//Destroy(other.gameObject);
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy
		}
	}
}
