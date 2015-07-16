using UnityEngine;
using System.Collections;

/**
 * Straight shooting enemy, shoots straight at a constant rate, but only if the player is within sight.
 */
public class TriggeredStraightShootingEnemy : ShootingEnemy {
	public override ClearRequirement[] ClearRequirements { get {
		return new ClearRequirement[]{
			new ClearRequirement(ClearDirection.AHEAD, 3),
			new ClearRequirement(ClearDirection.RIGHT, 1),
			new ClearRequirement(ClearDirection.LEFT, 1),
			new ClearRequirement(ClearDirection.BEHIND, 1)
		};
	} }

	// Only shoot if the player is detected.
	void FixedUpdate() {
		if (InLineOfSight()) {
			ShootProjectile();
		}
	}
}
