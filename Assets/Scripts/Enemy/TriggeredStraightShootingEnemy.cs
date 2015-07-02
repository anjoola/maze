using UnityEngine;
using System.Collections;

/**
 * Straight shooting enemy, shoots straight at a constant rate, but only if the player is within sight.
 */
public class TriggeredStraightShootingEnemy : ShootingEnemy {
	// Only shoot if the player is detected.
	void FixedUpdate() {
		if (InLineOfSight()) {
			ShootProjectile();
		}
	}
}
