using UnityEngine;
using System.Collections;

public class LaserRing : MonoBehaviour {
	int SCALE = 4;
	GameObject player;
	float Lifetime;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		iTween.ScaleTo(gameObject, iTween.Hash("x", SCALE, "y", SCALE, "z", SCALE, "loopType", "none", "time", 2.5f,
		                                       "easeType", "linear"));
		Lifetime = Time.time;
	}

	void FixedUpdate() {
		// Laser has expanded enough.
		if (Time.time - Lifetime > 2.5f)
			Destroy(gameObject);
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player)
			DoDamage();
	}
	void OnTriggerExit(Collider other) {
		if (other.gameObject == player)
			DoDamage();
	}

	private void DoDamage() {
		// TODO play a sound
		MainController.DecreaseHP(1);
		Destroy(gameObject);
	}
}
