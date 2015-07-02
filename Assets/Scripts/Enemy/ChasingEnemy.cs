using UnityEngine;
using System.Collections;

/**
 * A chasing enemy. Chases after the player if the player comes within a certain distance, and will continue chasing
 * the player until player is far enough away.
 */

// TODO this enemy is kind of dumb -- it will try to chase the player through the wall and keep running into the wall
// -- better used for chasing enemy that can go through walls
public class ChasingEnemy : BaseEnemy {
	// Whether or not chasing should occur.
	bool ShouldChase;

	// How slowly to turn.
	public int LookDamping = 4;

	// How quickly to chase after player.
	public int ChaseSpeed = 400;

	// Maximum distance at which it will chase the player. Any further and it will stop chasing.
	public float MaxChasingDistance = 2000;

	CharacterController controller;

	void Start() {
		doInit();

		controller = GetComponentInParent<CharacterController>();
		ShouldChase = false;
	}
	void FixedUpdate() {
		if (InLineOfSight()) {
			ShouldChase = true;
		}
	}
	void Update() {
		if (ShouldChase) {
			Chase();
		}
	}

	void Chase() {
		Vector3 playerPos = player.transform.position;
		playerPos.y = transform.position.y;
		Vector3 moveDirection = playerPos - transform.position;

		// See if the player is close enough.
		if (moveDirection.magnitude > MaxChasingDistance) {
			StopChase();
			return;
		}

		Quaternion desiredRotation = Quaternion.LookRotation(moveDirection);

		// Slowly rotate towards our next waypoint and move towards it.
		parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, desiredRotation,
		                                             Time.deltaTime * LookDamping);
		controller.Move(moveDirection.normalized * ChaseSpeed * Time.deltaTime);
	}

	void StopChase() {
		ShouldChase = false;
		// TODO show confusion that player has disappeared
	}
}

