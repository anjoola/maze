using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	GameObject player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			MainController.GetNextFloor();
		}
	}
}
