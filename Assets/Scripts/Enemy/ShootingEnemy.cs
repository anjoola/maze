using UnityEngine;
using System.Collections;

/**
 * Shooting enemy class. Shoots projectiles
 */
public class ShootingEnemy : BaseEnemy {
	int SHOOT_FORCE_MULTIPLIER = 10000;
	int SHOOT_INTERVAL = 3;
	
	// Projectile to shoot and location to shoot from.
	public GameObject Projectile;
	public GameObject ProjectileSource;

	// Force to shoot the projectile.
	public int ProjectileSpeed = 4;
	
	// Last time a projectile was shot.
	float LastShootTime = 0;
	
	void Start() {
		doInit();
	}
	
	protected override void doInit() {
		base.doInit();
		LastShootTime = Time.time;
	}
	
	/**
	 * Shoots a projectile straight ahead. Only shoots if it has been SHOOT_INTERVAL seconds since the last time a
	 * projectile was shot.
	 */
	protected void ShootProjectile() {
		if (Time.time - LastShootTime >= SHOOT_INTERVAL) {
			Transform source = ProjectileSource.transform;
			GameObject shot = Instantiate(Projectile, source.position, source.rotation) as GameObject;
			shot.GetComponent<Rigidbody>().AddForce(source.forward * ProjectileSpeed * SHOOT_FORCE_MULTIPLIER);
			LastShootTime = Time.time;
		}
	}
}
