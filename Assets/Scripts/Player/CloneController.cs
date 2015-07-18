using UnityEngine;
using System.Collections;

public class CloneController : MonoBehaviour {
	float LastUpdateTime = 0;
	float UPDATE_INTERVAL = 0.1f;

	// Current goal location.
	CloneLocation GoalLoc;

	// Current index into the array.
	int Idx;

	void Start () {
		LastUpdateTime = Time.time;
		Idx = 0;
		GoalLoc = null;
	}
	
	void FixedUpdate () {
		if (Time.time - LastUpdateTime >= UPDATE_INTERVAL) {
			LastUpdateTime = Time.time;
			GoalLoc = MainController.GetPlayerLocation(Idx);
			GoalLoc.position.y = gameObject.transform.position.y;

			Idx = (Idx + 1) % MainController.PlayerLocations.Length;
		}

		if (GoalLoc == null)
			return;

		// Update positoin and rotation.
		gameObject.transform.position =
			Vector3.Lerp(gameObject.transform.position, GoalLoc.position, Time.fixedDeltaTime);
		gameObject.transform.rotation =
			Quaternion.Lerp (gameObject.transform.rotation, GoalLoc.rotation, Time.fixedDeltaTime);
	}
}

public class CloneLocation {
	public Vector3 position;
	public Quaternion rotation;

	public CloneLocation(Transform transform) {
		position = transform.position;
		rotation = transform.rotation;
	}
}
