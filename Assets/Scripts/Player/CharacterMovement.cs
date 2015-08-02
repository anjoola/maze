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

	CharacterController controller;
	public GameObject LeftLeg;
	public GameObject RightLeg;
	public GameObject Body;

	bool IsWalking = true;

	// Last time the player's position was recorded.
	float UPDATE_INTERVAL = 0.1f;
	float LastUpdateTime = 0;
	
	void Start() {
		controller = gameObject.GetComponent<CharacterController>();
		LastUpdateTime = Time.time;

		iTween.MoveBy(Body, iTween.Hash("y", 10, "looptype", "pingPong", "easetype", "linear", "time", 0.25f));
	}
	
	void Update() {
		UpdateMovement();

		if (!MainController.ShouldPause())
			UpdateMovement();

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
			MainController.AddPlayerLocation(loc);
		}
	}

	float UpdateMovement() {
		// Movement amount.
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		if (x == 0 && z == 0)
			Stop();
		else
			Walk();
		
		// Adjust character's position based on input and where the camera is facing.
		Vector3 inputVec = new Vector3(x, 0, z);
		inputVec *= WalkSpeed;
		inputVec = camera.transform.TransformDirection(inputVec);
		inputVec.y = 0;

		controller.Move(inputVec * Time.deltaTime);
		return inputVec.magnitude;
	}

	void Stop() {
		if (!IsWalking)
			return;
		IsWalking = false;

		// Pause iTweens.
		iTween.Pause(Body);
		iTween.Stop(LeftLeg);
		iTween.Stop(RightLeg);

		// Move feet back to original position.
		Vector3 leftPos = LeftLeg.transform.localPosition;
		leftPos.z = 0;
		LeftLeg.transform.localPosition = leftPos;
		Vector3 rightPos = RightLeg.transform.localPosition;
		rightPos.z = 0;
		RightLeg.transform.localPosition = rightPos;
	}

	void Walk() {
		if (IsWalking)
			return;
		IsWalking = true;

		// Move feet to correct positions.
		Vector3 leftPos = LeftLeg.transform.localPosition;
		leftPos.z = -5;
		LeftLeg.transform.localPosition = leftPos;
		Vector3 rightPos = RightLeg.transform.localPosition;
		rightPos.z = 5;
		RightLeg.transform.localPosition = rightPos;

		// Start iTweens.
		iTween.Resume(Body);
		iTween.MoveBy(LeftLeg, iTween.Hash("y", 75, "looptype", "pingPong", "easetype", "linear", "time", 0.5f));
		iTween.MoveBy(RightLeg, iTween.Hash("y", -75, "looptype", "pingPong", "easetype", "linear", "time", 0.5f));
	}
}
