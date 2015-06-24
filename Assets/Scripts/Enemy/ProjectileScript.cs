using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {
	GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnTriggerEnter(Collider other) {
		// Projectile hit the player.
		if (other.gameObject == player) {
			// TODO
			Debug.Log ("HIT!!!!");
			Destroy(gameObject);
		}
		// TODO hit something else like a wall, edge of the maze, another enemy?
	}
}
