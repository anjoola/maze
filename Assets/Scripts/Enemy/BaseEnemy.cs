using UnityEngine;
using System.Collections;

/**
 * Base enemy class.
 */
public abstract class BaseEnemy : SpawnObject {
	public int PLAYER_HEIGHT = 200;

	// Amount of damage this enemy does onto the player, in HP intervals (up to 10).
	public int Damage = 1;

	// Radius of detection.
	public int Radius;
	protected bool isWithinRadius;
	public int ViewingAngle = 60;

	// Player game object (for detection purposes).
	protected GameObject player;

	// Parent game object (actual game object for this enemy).
	protected GameObject parent;

	public override ClearRequirement[] ClearRequirements { get {
		return new ClearRequirement[]{
			new ClearRequirement(ClearDirection.AHEAD, 1),
			new ClearRequirement(ClearDirection.RIGHT, 1),
			new ClearRequirement(ClearDirection.LEFT, 1),
			new ClearRequirement(ClearDirection.BEHIND, 1)
		};
	} }

	void Start() {
		isWithinRadius = false;
		
		// Get player and parent game object.
		player = GameObject.FindGameObjectWithTag("Player");
		parent = transform.parent.gameObject;
		
		// Set collider radius to be the one specified.
		try {
			this.GetComponent<SphereCollider>().radius = Radius;
		} catch (MissingComponentException e) { }

		doStart();
	}

	// To be used by subclasses.
	protected virtual void doStart() { }

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
		Vector3 position = transform.position;
		position.y = PLAYER_HEIGHT;
		float angle = Vector3.Angle(direction, transform.forward);

		// Angle between forward and where player is is less than half of viewing angle, and player is within line
		// of sight (nothing blocking in between).
		if (angle < ViewingAngle * 0.5f) {
			RaycastHit hit;
			if (Physics.Raycast(position, direction, out hit)) {
				if (hit.collider.gameObject == player) {
					return true;
				}
			}
		}
		
		return false;
	}

	/**
	 * Returns true if the player is in front of the enemy (not necessarily where the enemy can see, but the player
	 * is not blocked by a wall.
	 */
	protected bool IsPlayerInFront() {
		Vector3 direction = player.transform.position - transform.position;
		direction.y = PLAYER_HEIGHT;

		RaycastHit hit;
		if (Physics.Raycast(transform.position, direction, out hit)) {
			if (hit.collider.gameObject == player) {
				return true;
			}
		}
		return false;
	}
}
