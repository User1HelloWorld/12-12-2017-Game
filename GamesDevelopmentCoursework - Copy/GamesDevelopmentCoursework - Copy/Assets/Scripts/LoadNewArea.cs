using UnityEngine;
using System.Collections;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Triggers changing the scene using a box collider.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			Application.LoadLevel(levelToLoad);
		}
	}
}
