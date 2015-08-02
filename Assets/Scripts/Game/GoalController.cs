using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	GameObject player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		iTween.RotateAdd(gameObject, iTween.Hash("y", 359, "time", 10, "easetype", "linear", "looptype", "loop"));
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			MainController.GetNextFloor();
		}
	}
}
