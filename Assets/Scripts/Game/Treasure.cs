using UnityEngine;
using System.Collections;

public class Treasure : SpawnObject {
	public override int SpaceNeeded { get { return 0; } }

	public GameObject player;

	// Value of this treasure.
	public int TreasureValue = 0;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			MainController.AcquireTreasure(TreasureValue);
			Destroy(gameObject);
		}
	}
}
