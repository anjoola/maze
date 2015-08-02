using UnityEngine;
using System.Collections;

/**
 * Rotates a cylinder of a MovingEnemy.
 */
public class MovingEnemyRotation : MonoBehaviour {
	public float Delay = 0.4f;
	void Start() {
		iTween.RotateAdd(gameObject, iTween.Hash("y", 359, "looptype", "loop", "easetype", "linear", "time", 6,
		                                         "delay", Delay));
	}
}
