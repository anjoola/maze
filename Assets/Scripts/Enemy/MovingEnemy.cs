using UnityEngine;
using System.Collections;

public class MovingEnemy : BaseEnemy {
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			MainController.DecreaseHP(Damage);
		}
	}
}
