using UnityEngine;
using System.Collections;

/**
 * Targets the player once in line of sight, and locks on. Otherwise, just shoots straight at a set interval.
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

	void FixedUpdate() {
		// Rotate towards the player if within line of sight.
		if (InLineOfSight()) {
			parent.transform.LookAt(player.transform);
		}
		ShootProjectile();
	}
}
