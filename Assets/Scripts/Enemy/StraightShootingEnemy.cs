using UnityEngine;
using System.Collections;

/**
 * Straight shooting enemy which will shoot straight at a constant rate.
 */
public class StraightShootingEnemy : ShootingEnemy {
	void FixedUpdate() {
		shootProjectile();
	}
}
