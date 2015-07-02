using UnityEngine;
using System.Collections;

/**
 * Targets the player once in line of sight, and locks on. Otherwise, just shoots straight at a set interval.
 */
public class LockOnShootingEnemy : ShootingEnemy {
	void FixedUpdate() {
		// Rotate towards the player if within line of sight.
		if (InLineOfSight()) {
			parent.transform.LookAt(player.transform);
		}
		ShootProjectile();
	}
}
