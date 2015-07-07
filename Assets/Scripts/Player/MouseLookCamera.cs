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
	public float rotateSpeed = 5;

	// Difference between the camera's position and the player's position.
	Vector3 offset;

	// List of blocks that are obscuring the camera and have been made transparent.
	List<GameObject> TransparentBlocks = new List<GameObject>();
	
	void Start() {
		offset = player.transform.position - transform.position;
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

		// Rotate camera.
		transform.LookAt(player.transform);

		// Un-transparent-ize previously-made transparent objects.
		foreach (GameObject obj in TransparentBlocks) {
			Color color = obj.GetComponent<Renderer>().material.color;
			color.a = 1.0f;
			obj.GetComponent<Renderer>().material.color = color;
		}
		TransparentBlocks.Clear();

		// If something is in the way between the camera and the player, make it transparent.
		RaycastHit hit;
		if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit)) {
			GameObject item = hit.collider.gameObject;
			// TODO add other tags
			if (item != player && item.tag == "Maze") {
				Color color = item.GetComponent<Renderer>().material.color;
				color.a = 0.1f;
				item.GetComponent<Renderer>().material.color = color;
				TransparentBlocks.Add(item);
			}
		}
	}
}
