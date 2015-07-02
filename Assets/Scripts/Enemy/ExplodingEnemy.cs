using UnityEngine;
using System.Collections;

/**
 * Exploding enemy class. Explodes when the player comes within a certain radius of it. Projectiles are shot out in
 * all directions.
 */
public class ExplodingEnemy : BaseEnemy {
	int NUMBER_OF_SHOTS = 20;
	int SHOOT_FORCE_MULTIPLIER = 10000;
	
	// Projectile to shoot and location to shoot from.
	public GameObject Projectile;
	
	// Force to shoot the projectile.
	public int ProjectileSpeed = 2;

	void FixedUpdate() {
		if (isWithinRadius) {
			Explode();
		}
	}

	void Explode() {
		// Send radius of projectiles.
		float degree = 360f / NUMBER_OF_SHOTS;
		for (float i = -180f; i < 180f; i += degree) {
			Quaternion rotation = Quaternion.AngleAxis(i, transform.up);
			GameObject shot = Instantiate(Projectile, transform.position, rotation * transform.rotation) as GameObject;
			shot.GetComponent<Rigidbody>().AddForce(rotation * transform.forward * ProjectileSpeed * SHOOT_FORCE_MULTIPLIER);
		}

		// Kills itself.
		Destroy(parent);
	}
}
