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
	protected bool isWithinRadius;
	public int ViewingAngle = 60;

	// Player game object (for detection purposes).
	protected GameObject player;

	// Parent game object (actual game object for this enemy).
	protected GameObject parent;

	void Start() {
		doInit();
	}
	protected virtual void doInit() {
		isWithinRadius = false;
		
		// Get player and parent game object.
		player = GameObject.FindGameObjectWithTag("Player");
		parent = transform.parent.gameObject;
		
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
	 * Returns true if the player is within line of sight of the enemy, and within the viewing angle. Based on
	 * https://unity3d.com/learn/tutorials/projects/stealth/enemy-sight.
	 */
	protected bool InLineOfSight() {
		if (!isWithinRadius) return false;

		Vector3 direction = player.transform.position - transform.position;
		float angle = Vector3.Angle(direction, transform.forward);

		// Angle between forward and where player is is less than half of viewing angle, and player is within line
		// of sight (nothing blocking in between).
		if (angle < ViewingAngle * 0.5f) {
			RaycastHit hit;
			if (Physics.Raycast(transform.position, direction, out hit)) {
				if (hit.collider.gameObject == player) {
					return true;
				}
			}
		}

		return false;
	}
}
