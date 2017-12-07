using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	
	//Don't want to make changes to it just want a variable to be used.
	private Animator animator;
	private Rigidbody2D myRigidbody;

	private bool playerMoving;
	public Vector2 lastMove;

	//Making this static means that all objects attached to this script, they will all have the same
	//playerExists value.
	private static bool playerExists;

	//To tell if the player is attacking and how long they should attack for.
	private bool attacking;
	public float attackTime;
	private float attackTimeCounter;	//Everytime an attack is used this is incremented.

	// Use this for initialization
	void Start () {
		//Finds the animator object.
		animator = GetComponent<Animator>();
		//Moving the rigidbody of the player around using the in-built physics.
		myRigidbody = GetComponent<Rigidbody2D>();

		//Checks to see if the player already exists. This will prevent duplications of the player occuring.
		if (!playerExists) {
			playerExists = true;
			//When a new level is loaded, the player will still stay in existance.
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame.
	void Update () {

		playerMoving = false;

		//Stops the player moving and only lets the attack finish before doing another action.
		if (!attacking) {
			//Whatever input is currently being used.
			//Input.GetAxisRaw returns as value between -1 and 1 which will determine movement in a direction.
			if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) {	//If moving right or left.
				//Transform is the position, roation and scale of the object in the world.
				//Translate moves the object.
				//Vectors are coordinate destinations so Vector 3 would be x, y, z. Vector 2 would be x, y, z.
				//* by moveSpeed to determine the velocity of the object.
				//20FPS, every 1/20 of a second and update occurs.
				//DeltaTime is the difference of time between each update, 20FPS would be 0.05 seconds.
				//DeltaTime is proportional to the FPS so that it can always be flush with the update speed.
				//Only horizontal axis is effected so only the x value needs to be assigned a non-zero value.
				//transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
				myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
				playerMoving = true;
				lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
			}

			if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) {	//If moving up or down.
				//transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
				playerMoving = true;
				lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
			}

			//Attacking animation.
			//GetKeyDown only gets the very first moment the key is pressed so the animation is only done once.
			if (Input.GetKeyDown(KeyCode.J)) {
				attackTimeCounter = attackTime;
				attacking = true;
				myRigidbody.velocity = Vector2.zero;	//Stops the player moving when attacking.
				animator.SetBool("Attack", true);
			}
		}

		//Finish attacking when the time for the animation is done.
		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;	//Take off time until it is finished.
		}

		if (attackTimeCounter <= 0) {
			attacking = false;
			animator.SetBool("Attack", false);
		}

		//This changes the value of the parameters for the animations.
		animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));

		animator.SetBool("PlayerMoving", playerMoving);
		animator.SetFloat("LastMoveX", lastMove.x);
		animator.SetFloat("LastMoveY", lastMove.y);
	}
}