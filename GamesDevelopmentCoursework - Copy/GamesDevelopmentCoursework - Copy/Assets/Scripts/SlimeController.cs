
using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour {
	
	public float moveSpeed;
	private Rigidbody2D myRigidbody;
	private bool moving;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection; 
	
	//Used to determine when the player will be reactivated.
	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;
	
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
		
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;
		
		timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			timeToMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = moveDirection;
			
			if (timeToMoveCounter < 0f) {
				moving = false;
				timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			}
		} else {
			timeBetweenMoveCounter -= Time.deltaTime;
			myRigidbody.velocity = Vector2.zero;
			
			if (timeBetweenMoveCounter < 0f) {
				moving = true;
				timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
				
				//Picks a random number between -1 and 1 so the slime randomly moves.
				moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
			}
		}
		
		/*if (reloading) {
			waitToReload -= Time.deltaTime;
			
			if (waitToReload < 0) {
				Application.LoadLevel(Application.loadedLevel);
				thePlayer.SetActive (true);
			}
		}*/
	}
	
	void OnCollisionEnter2D(Collision2D other) {
		/*if (other.gameObject.name == "Player") {
			//Destroy (other.gameObject);
			//Rather want the player to be deactivated instead of being destroyed. This is because it gives a lot of errors.
			other.gameObject.SetActive(false);
			reloading = true;
			thePlayer = other.gameObject;
		}*/

	}
}

