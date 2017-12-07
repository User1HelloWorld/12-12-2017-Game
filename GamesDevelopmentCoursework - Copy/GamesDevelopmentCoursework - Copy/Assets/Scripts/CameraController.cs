using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;
	private Vector3 targetPosition;	//This is used to follow the target object.
	public float moveSpeed;	//The speed at which it will follow.

	private static bool cameraExists;

	// Use this for initialization
	void Start () {
		if (!cameraExists) {
			cameraExists = true;
			//When a new level is loaded, the player will still stay in existance.
			DontDestroyOnLoad(transform.gameObject);
		} else {
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		targetPosition = new Vector3 (followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);	//From point A to B at what speed.
	}
}
