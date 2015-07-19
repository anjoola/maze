using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	GameObject player;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter(Collider other) {
		// Projectile hit the player.
		if (other.gameObject == player) {
			// TODO
			MainController.ShowNote("OUCH!");
			MainController.DecreaseHP(1);
			// TODO
			Destroy(gameObject);
		}
		// TODO hit something else like a wall, edge of the maze, another enemy?
		if (other.gameObject.tag == "Maze") {
			Destroy(gameObject);
		}
	}
}
