using UnityEngine;
using System.Collections;

//Tells the player and camera objects to go to a specific position in the world.
public class PlayerStartPoint : MonoBehaviour {

	private PlayerController thePlayer;
	private CameraController theCamera;

	//USed to make the player face the correct way when leaving or entering an area.
	public Vector2 startDirection;

	// Use this for initialization
	void Start () {
		//Looks in the game world and finds the PlayerController objects.
		thePlayer = FindObjectOfType<PlayerController>();
		thePlayer.transform.position = transform.position;
		thePlayer.lastMove = startDirection;

		theCamera = FindObjectOfType<CameraController>();
		theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
