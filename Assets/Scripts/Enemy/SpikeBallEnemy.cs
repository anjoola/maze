using UnityEngine;
using System.Collections;

public class SpikeBallEnemy : BaseEnemy {
	public float Speed = 1f;

	override protected void doStart() {
		iTween.MoveBy(parent.gameObject, iTween.Hash("y", 500, "looptype", "pingPong", "time", Speed));
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			iTween.Pause(parent.gameObject);
			MainController.DecreaseHP(Damage);
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject == player) {
			iTween.Resume(parent.gameObject);
		}
	}
}
