using UnityEngine;
using System.Collections;

/**
 * Controls character movement. Character can strafe and move forwads and backwards (no jumping).
 */
public class CharacterMovement : MonoBehaviour {
	// How fast the character walks and runs.
	public float WalkSpeed = 1000f;
	public float RunSpeed = 3000f;

	public new Transform camera;

	float moveSpeed;
	CharacterController controller;

	// Last time the player's position was recorded.
	float UPDATE_INTERVAL = 0.1f;
	float LastUpdateTime = 0;
	
	void Start() {
		controller = gameObject.GetComponent<CharacterController>();
		LastUpdateTime = Time.time;
	}
	
	void Update() {
		// TODO remove for testing purpoises
		if (MainController.instance == null) {
			UpdateMovement();
			return;
		}

		// TODO detect running if movespeed fast enough
		if (!MainController.ShouldPause())
			moveSpeed = UpdateMovement();

		// Toggle pause menu display.
		if (Input.GetKeyDown(KeyCode.Escape)) {
			MainController.TogglePauseMenu();
		}
	}

	void FixedUpdate() {
		// Update the player's position.
		if (Time.time - LastUpdateTime >= UPDATE_INTERVAL) {
			LastUpdateTime = Time.time;

			CloneLocation loc = new CloneLocation(gameObject.transform);

			// TODO
			if (MainController.instance != null)
			MainController.AddPlayerLocation(loc);
		}
	}

	float UpdateMovement() {
		// Movement amount.
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		// Adjust character's position based on input and where the camera is facing.
		Vector3 inputVec = new Vector3(x, 0, z);
		inputVec *= WalkSpeed;
		// TODO add back inputVec = camera.transform.TransformDirection(inputVec);
		inputVec.y = 0;

		controller.Move(inputVec * Time.deltaTime);
		return inputVec.magnitude;
	}
}
