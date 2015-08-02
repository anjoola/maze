using UnityEngine;
using System.Collections;

/**
 * Targets the player once in line of sight, and locks on. Otherwise, just shoots straight at a set interval and
 * returns to its original rotation.
 */
public class LockOnShootingEnemy : ShootingEnemy {
	public override ClearRequirement[] ClearRequirements { get {
		return new ClearRequirement[]{
			new ClearRequirement(ClearDirection.AHEAD, 3),
			new ClearRequirement(ClearDirection.RIGHT, 3),
			new ClearRequirement(ClearDirection.LEFT, 3),
			new ClearRequirement(ClearDirection.BEHIND, 3)
		};
	} }

	// When the enemy lost contact with the user.
	private float StoppedLooking = 0.0f;
	public int LookDamping = 4;

	// Starting rotation to return to.
	private Quaternion StartRot;
	private Quaternion DestRot;

	override protected void doStart() {
		base.doStart();
		StartRot = parent.gameObject.transform.rotation;
		StoppedLooking = -1;
	}

	void FixedUpdate() {
		// Rotate towards the player if within line of sight.
		if (InLineOfSight()) {
			DestRot = Quaternion.LookRotation(player.transform.position - parent.transform.position);
			parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, DestRot,
			                                             Time.deltaTime * LookDamping);
		}
		// Otherwise rotate back to original position.
		else if (DestRot != StartRot) {
			StoppedLooking = Time.time;
			DestRot = StartRot;
		}
		else if (StoppedLooking != -1 && Time.time - StoppedLooking > 4) {
			parent.transform.rotation = Quaternion.Slerp(parent.transform.rotation, DestRot,
			                                             Time.deltaTime * LookDamping);
		}
		ShootProjectile();
	}
}
