using UnityEngine;
using System.Collections;

/**
 * A ghost enemy. Chases after the player if the player comes within a certain distance, and will continue chasing
 * the player until player is far enough away.
 */
public class GhostEnemy : BaseEnemy {
	CharacterController controller;

	// Whether or not chasing should occur.
	bool ShouldChase;
	
	// How slowly to turn.
	public int LookDamping = 4;
	
	// How quickly to chase after player.
	public int ChaseSpeed = 400;
	
	// Maximum distance at which it will chase the player. Any further and it will stop chasing.
	public float MaxChasingDistance = 2000;

	// Starting position to return to.
	private Vector3 StartPos;
	private Quaternion StartRot;
	
	override protected void doStart() {
		iTween.MoveBy(parent.gameObject, iTween.Hash("y", 30, "loopType", "pingPong", "easetype", "linear"));
		controller = GetComponentInParent<CharacterController>();
		ShouldChase = false;

		StartPos = gameObject.transform.position;
		StartRot = gameObject.transform.rotation;
	}

	void FixedUpdate() {
		if (InLineOfSight()) {
			ShouldChase = true;
		}
	}

	void Update() {
		// Player hit the ghost! Lose HP and ghost disappears.
		if (Mathf.Abs(player.transform.position.x - parent.gameObject.transform.position.x) <= 115 &&
		    Mathf.Abs(player.transform.position.z - parent.gameObject.transform.position.z) <= 115) {
			MainController.DecreaseHP(2);
			PoofAnimation();
			Destroy(parent);
		}

		else if (ShouldChase) {
			Chase();
		}
		else {
			Return();
		}
	}
	
	void Chase() {
		Vector3 playerPos = player.transform.position;
		playerPos.y = transform.position.y;
		Vector3 moveDirection = playerPos - transform.position;
		
		// See if the player is close enough.
		if (moveDirection.magnitude > MaxChasingDistance) {
			ShouldChase = false;
			return;
		}
		
		Quaternion desiredRotation = Quaternion.LookRotation(moveDirection);
		moveDirection.y = 0;
		
		// Slowly rotate towards our next waypoint and move towards it.
		parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, desiredRotation,
		                                             Time.deltaTime * LookDamping);
		controller.Move(moveDirection.normalized * ChaseSpeed * Time.deltaTime);
	}

	/**
	 * Return to original position.
	 */
	void Return() {
		if (Mathf.Abs(parent.transform.position.x - StartPos.x) <= 10)
			return;

		Vector3 moveDirection = StartPos - transform.position;
		parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, StartRot,
		                                             Time.deltaTime * LookDamping);
		controller.Move(moveDirection.normalized * ChaseSpeed * Time.deltaTime);
	}
}
