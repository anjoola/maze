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
			MainController.DecreaseHP(1);
			Destroy(gameObject);
		}

		// Hit a wall. Projectile is destroyed.
		else if (other.gameObject.tag == "Maze")
			Destroy(gameObject);
	}
}
