using UnityEngine;
using System.Collections;

/**
 * Controls character movement. Character can strafe and move forwads and backwards (no jumping).
 */
public class CharacterMovement : MonoBehaviour {
	// How fast the character walks and runs.
	public float WalkSpeed = 1600f;
	public float RunSpeed = 3000f;

	public override Transform camera;

	CharacterController controller;
	public GameObject LeftLeg;
	public GameObject RightLeg;
	public GameObject Body;

	bool IsWalking = true;
	bool StartedWalking = false;

	// Record starting and last good location (not in a wall).
	Vector3 StartPos;
	Vector3 LastGoodLocation;

	// Last time the player's position was recorded.
	public static float UPDATE_INTERVAL = 0.05f;
	
	void Start() {
		controller = gameObject.GetComponent<CharacterController>();

		iTween.MoveBy(Body, iTween.Hash("y", 20, "looptype", "pingPong", "easetype", "linear", "time", 0.25f));
		MainController.ResetLocations();
		StartPos = controller.transform.position;
		LastGoodLocation = StartPos;
	}
	
	void Update() {
		UpdateMovement();

		if (!MainController.ShouldPause())
			UpdateMovement();

		// Toggle pause menu display.
		if (Input.GetKeyDown(KeyCode.Escape)) {
			MainController.TogglePauseMenu();
		}

		Vector3 pos = gameObject.transform.position;
		pos.y = 0;
		gameObject.transform.position = pos;

		// Somehow got into a wall. Return to the last known good position.
		if (MainController.MazeGen != null && MainController.MazeGen.IsMazeBlock(gameObject.transform.position))
			gameObject.transform.position = LastGoodLocation;
		else
			LastGoodLocation = gameObject.transform.position;
	}

	float UpdateMovement() {
		// Movement amount.
		float x = Input.GetAxis("Horizontal") * 0.4f;
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

		// Move player, and add move delta so clones can follow later.
		controller.Move(inputVec * Time.deltaTime);
		if (StartedWalking) {
			CloneLocation loc = new CloneLocation(inputVec * Time.deltaTime, gameObject.transform.rotation);
			MainController.AddPlayerLocation(loc);
		}
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
		if (Vector3.Distance(controller.transform.position, StartPos) > 800)
			StartedWalking = true;

		if (IsWalking)
			return;
		IsWalking = true;

		// Move feet to correct positions.
		Vector3 leftPos = LeftLeg.transform.localPosition;
		leftPos.z = -7;
		LeftLeg.transform.localPosition = leftPos;
		Vector3 rightPos = RightLeg.transform.localPosition;
		rightPos.z = 7;
		RightLeg.transform.localPosition = rightPos;

		// Start iTweens.
		iTween.Resume(Body);
		iTween.MoveBy(LeftLeg, iTween.Hash("y", 85, "looptype", "pingPong", "easetype", "linear", "time", 0.5f));
		iTween.MoveBy(RightLeg, iTween.Hash("y", -85, "looptype", "pingPong", "easetype", "linear", "time", 0.5f));
	}
}
