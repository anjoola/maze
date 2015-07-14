using UnityEngine;
using System.Collections;

public abstract class Item : SpawnObject {
	public override int SpaceNeeded { get { return 0; } }

	public GameObject player;
		
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			ItemEffect();
			Destroy(gameObject);
		}
	}

	/**
	 * Effect this item has. Does the action (such as healing, etc.).
	 */
	protected abstract void ItemEffect();
}
