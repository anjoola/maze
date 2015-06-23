using UnityEngine;
using System.Collections;

/**
 * Straight shooting enemy which will shoot straight at a constant rate.
 */
public class TriggeredStraightShootingEnemy : ShootingEnemy {
	// Only shoot if the player is detected.
	void FixedUpdate() {
		if (InLineOfSight()) {
			ShootProjectile();
		}
	}
}
