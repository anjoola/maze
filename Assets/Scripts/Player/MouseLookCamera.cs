using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Controls the mouse input for the camera. Mouse can pan the camera left and right; character will rotate with the
 * camera. Makes objects in between the camera and the player temporarily invisible so nothing obscures the camera's
 * view of the player.
 */
public class MouseLookCamera : MonoBehaviour {
	public GameObject player;

	// How quickly to rotate the camera.
	public float rotateSpeed = 10;

	// Difference between the camera's position and the player's position.
	Vector3 offset;

	void Start() {
		offset = player.transform.position - transform.position;
		Debug.Log ("camera offset: " + offset);
	}
	
	void LateUpdate() {
		if (MainController.ShouldPause())
			return;

		// Rotate player.
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		player.transform.Rotate(0, horizontal, 0);

		// Move camera.
		float desiredAngle = player.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = player.transform.position - (rotation * offset);
		Debug.Log ("camera position moved to : " + transform.position);

		// Rotate camera.
		transform.LookAt(player.transform);
	}
}
