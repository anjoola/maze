using UnityEngine;
using System.Collections;

public class CloneController : MonoBehaviour {
	float LastUpdateTime = 0;
	float UPDATE_INTERVAL = 0.1f;

	// Current index into the array.
	int Idx;

	void Start () {
		LastUpdateTime = Time.time;
		Idx = 0;
	}
	
	void FixedUpdate () {
		if (Time.time - LastUpdateTime >= UPDATE_INTERVAL) {
			LastUpdateTime = Time.time;
			CloneLocation loc = MainController.GetPlayerLocation(Idx);
			Idx = (Idx + 1) % MainController.PlayerLocations.Length;

			loc.position.y = gameObject.transform.position.y;
			gameObject.transform.position = loc.position;
			gameObject.transform.rotation = loc.rotation;
		}
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
