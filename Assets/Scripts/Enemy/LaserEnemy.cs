using UnityEngine;
using System.Collections;

public class LaserEnemy : BaseEnemy {
	// Amount of empty cells needed in the maze to place this object, not including the cell the object will appear in.
	override public int SpaceNeeded { get { return 3; } }

	public int SHOOT_INTERVAL = 8;
	public GameObject Laser;
	
	// Last time a laser ring was shot.
	float LastShootTime = 0;
	
	override protected void doStart() {
		// Randomize shooting start time.
		LastShootTime = Time.time + Random.Range(0, 8) / 3.0f;
	}

	void FixedUpdate() {
		ShootLaser();
	}
	
	/**
	 * Shoots a projectile straight ahead. Only shoots if it has been SHOOT_INTERVAL seconds since the last time a
	 * projectile was shot.
	 */
	private void ShootLaser() {
		if (Time.time - LastShootTime >= SHOOT_INTERVAL) {
			iTween.MoveBy(parent.gameObject, iTween.Hash("y", 7, "time", 0.5f, "easetype", "linear"));

			Instantiate(Laser, transform.position, transform.rotation);
			LastShootTime = Time.time;
			
			iTween.MoveBy(parent.gameObject, iTween.Hash("y", -7, "time", 0.5f, "easetype", "linear", "delay", 0.5f));
		}
	}
}
