using UnityEngine;
using System.Collections;

/**
 * Rotates 90 degrees each time and shoots at a defined interval.
 */
public class RotateShootingEnemy : ShootingEnemy {
	// How frequent a rotation occurs.
	int ROTATE_FREQUENCY = 5;

	// How long a rotation takes.
	int ROTATE_DURATION = 1;

	// Last time rotated.
	float LastRotateTime = 0;
	float LastRotateStartedTime = 0;
	bool ShouldRotate = false;

	void FixedUpdate() {
		if (ShouldRotate) {
			RotateSelf();
		}
		// Done rotating.
		if (Time.time - LastRotateStartedTime >= ROTATE_DURATION) {
			ShouldRotate = false;
			LastRotateStartedTime = Time.time;
		}
		// If it's time to rotate again.
		if (Time.time - LastRotateTime >= ROTATE_FREQUENCY) {
			ShouldRotate = true;
			ShootProjectile();
			LastRotateTime = Time.time;
		}
	}

	/**
	 * Rotates the enemy 90 degrees, gradually.
	 */
	void RotateSelf() {
		parent.transform.Rotate(0, 90 * Time.deltaTime, 0, Space.World);
	}
}
