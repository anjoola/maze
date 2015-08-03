using UnityEngine;
using System.Collections;

public class CloneController : MonoBehaviour {
	float LastUpdateTime = 0;

	// Current goal location.
	CloneLocation GoalLoc;
	GameObject player;

	// Current index into the array.
	int Idx;

	void Start() {
		LastUpdateTime = Time.time;
		Idx = 0;
		GoalLoc = null;
		player = GameObject.FindGameObjectWithTag("Player");

		iTween.MoveBy(gameObject, iTween.Hash("y", 10, "looptype", "pingPong", "easetype", "linear", "time", 0.7f));
		PlayAnimation();

		if (!MainController.CurrentGame.CloneIntroduced) {
			MainController.CurrentGame.CloneIntroduced = true;
			MainController.ShowNote("Something is following you...");
		}
	}
	
	void FixedUpdate() {
		if (Time.time - LastUpdateTime >= CharacterMovement.UPDATE_INTERVAL) {
			LastUpdateTime = Time.time;
			GoalLoc = MainController.GetPlayerLocation(Idx);
			if (GoalLoc == null)
				return;

			GoalLoc.position.y = gameObject.transform.position.y;
			Idx = (Idx + 1) % MainController.PlayerLocations.Length;
		}

		if (GoalLoc == null)
			return;

		// Update position and rotation.
		gameObject.transform.position =
			Vector3.Lerp(gameObject.transform.position, GoalLoc.position, Time.fixedDeltaTime);
		gameObject.transform.rotation =
			Quaternion.Lerp(gameObject.transform.rotation, GoalLoc.rotation, Time.fixedDeltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			PlayAnimation();
			MainController.DecreaseHP(2);
			Destroy(gameObject);
		}
	}

	void PlayAnimation() {
		GameObject obj = Instantiate(Resources.Load("Enemy/Spawning") as GameObject,
		                             transform.position, transform.rotation) as GameObject;
		ParticleSystem sys = obj.GetComponentInChildren<ParticleSystem>();
		sys.Play();
		Destroy(obj, sys.duration);
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
