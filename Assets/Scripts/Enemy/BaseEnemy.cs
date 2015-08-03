using UnityEngine;
using System.Collections;

/**
 * Base enemy class.
 */
public abstract class BaseEnemy : SpawnObject {
	private int PLAYER_HEIGHT = 70;

	// Amount of damage this enemy does onto the player, in HP intervals (up to 10).
	public int Damage = 1;

	// Radius of detection.
	public float Radius;
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
		if (transform.parent)
			parent = transform.parent.gameObject;
		
		// Set collider radius to be the one specified.
		try {
			this.GetComponent<SphereCollider>().radius = Radius;
		} catch (MissingComponentException) { }

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
		Vector3 playerPos = player.transform.position;
		playerPos.y = PLAYER_HEIGHT;
		Vector3 position = transform.position;
		position.y = PLAYER_HEIGHT;
		Vector3 direction = playerPos - position;

		RaycastHit hit;
		if (Physics.Raycast(position, direction, out hit)) {
			if (hit.collider.gameObject == player) {
				return true;
			}
		}
		return false;
	}

	/**
	 * Shows appropriate animations.
	 */
	protected void ExplodeAnimation() {
		AudioController.playSFX("Bomb");
		GameObject explosion = Instantiate(Resources.Load("Enemy/Explosion") as GameObject,
		                              	   transform.position, transform.rotation) as GameObject;
		ParticleSystem sys = explosion.GetComponentInChildren<ParticleSystem>();
		sys.Play();
		Destroy(explosion, sys.duration);
	}
	protected void PoofAnimation() {
		GameObject poof = Instantiate(Resources.Load("Enemy/Poof") as GameObject,
		                              transform.position, transform.rotation) as GameObject;
		ParticleSystem sys = poof.GetComponentInChildren<ParticleSystem>();
		sys.Play();
		Destroy(poof, sys.duration);
	}

	/**
	 * Destroy self. Show destroying animation.
	 */
	public void DestroySelf() {
		GameObject explosion = Instantiate(Resources.Load("Enemy/BigExplosion") as GameObject,
		                                   transform.position, transform.rotation) as GameObject;
		ParticleSystem sys = explosion.GetComponentInChildren<ParticleSystem>();
		sys.Play();
		Destroy(explosion, sys.duration);

		if (parent != null && parent.gameObject != null)
			Destroy(parent.gameObject);
		else
			Destroy(gameObject);
	}
}
