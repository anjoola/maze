using UnityEngine;
using System.Collections;

/**
 * Straight shooting enemy which will shoot straight at a constant rate.
 */
public class StraightShootingEnemy : ShootingEnemy {
	public override ClearRequirement[] ClearRequirements { get {
		return new ClearRequirement[]{
			new ClearRequirement(ClearDirection.AHEAD, 3),
			new ClearRequirement(ClearDirection.RIGHT, 1),
			new ClearRequirement(ClearDirection.LEFT, 1),
			new ClearRequirement(ClearDirection.BEHIND, 1)
		};
	} }

	void FixedUpdate() {
		ShootProjectile();
	}
}
