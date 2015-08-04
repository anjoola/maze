using UnityEngine;
using System.Collections;

public class CloneController : MonoBehaviour {
	float LastUpdateTime = 0;

	// Current goal location.
	CloneLocation GoalLoc;
	GameObject player;

	CharacterController controller;

	// Current index into the array.
	int Idx;

	void Start() {
		controller = GetComponent<CharacterController>();
		LastUpdateTime = Time.time;
		Idx = 0;
		player = GameObject.FindGameObjectWithTag("Player");

		iTween.MoveBy(gameObject, iTween.Hash("y", 10, "looptype", "pingPong", "easetype", "linear", "time", 0.7f));
		PlayAnimation();

		if (!MainController.CurrentGame.CloneIntroduced) {
			MainController.CurrentGame.CloneIntroduced = true;
			MainController.ShowNote("Something is following you...");
		}
	}
	
	void Update() {
		// Get the next delta to move.
		if (Time.time - LastUpdateTime >= CharacterMovement.UPDATE_INTERVAL) {
			LastUpdateTime = Time.time;
			GoalLoc = MainController.GetPlayerLocation(Idx);
			Idx = (Idx + 1) % MainController.PlayerLocations.Length;
		}

		if (GoalLoc != null) {
			controller.Move(GoalLoc.position);

			gameObject.transform.rotation = 
					Quaternion.Lerp(gameObject.transform.rotation, GoalLoc.rotation, Time.deltaTime);
		}
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

	public CloneLocation(Vector3 position, Quaternion rotation) {
		this.position = position;
		this.rotation = rotation;
	}
}
