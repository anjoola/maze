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
	
	void Start() {
		controller = gameObject.GetComponent<CharacterController>();
	}
	
	void Update() {
		// TODO detect running if movespeed fast enough
		if (!MainController.IsPaused)
			moveSpeed = UpdateMovement();

		// Toggle pause menu display.
		if (Input.GetKeyDown(KeyCode.Escape)) {
			MainController.TogglePauseMenu();
		}
	}

	float UpdateMovement() {
		// Movement amount.
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		
		// Adjust character's position based on input and where the camera is facing.
		Vector3 inputVec = new Vector3(x, 0, z);
		inputVec *= WalkSpeed;
		inputVec = camera.transform.TransformDirection(inputVec);
		inputVec.y = 0;

		controller.Move(inputVec * Time.deltaTime);
		return inputVec.magnitude;
	}
}
