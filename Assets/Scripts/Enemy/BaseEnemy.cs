using UnityEngine;
using System.Collections;

/**
 * Base enemy class.
 */
public class BaseEnemy : MonoBehaviour {
	// Name of the enemy.
	public string Name;

	// Amount of damage this enemy does onto the player.
	public int Damage = 10;

	// Radius of detection.
	public int Radius;
	bool isWithinRadius;
	public int ViewingAngle = 60;

	// Player game object (for detection purposes).
	GameObject player;

	void Start() {
		doInit();
	}
	protected virtual void doInit() {
		isWithinRadius = false;
		
		// Get player.
		player = GameObject.FindGameObjectWithTag("Player");
		
		// Set collider radius to be the one specified.
		this.GetComponent<SphereCollider>().radius = Radius;
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			isWithinRadius = true;
		}
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			isWithinRadius = false;
		}
	}

	/**
	 * Returns true if the player is within line of sight of the enemy, and within the viewing angle.
	 */
	protected bool inLineOfSight() {
		if (!isWithinRadius) return false;

		// Create vector from enemy to player.
		Vector3 direction = player.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.forward);

		// Angle between forward and where player is is less than half of viewing angle.
		// TODO https://unity3d.com/learn/tutorials/projects/stealth/enemy-sight
		if (angle < ViewingAngle * 0.5f)
			return true;

		return false;
	}
}
