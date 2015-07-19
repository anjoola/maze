using UnityEngine;
using System.Collections;

public class Treasure : SpawnObject {
	public override int SpaceNeeded { get { return 0; } }

	public GameObject player;
	public bool rotate = false;
	public bool hover = false;

	// Value of this treasure.
	public int TreasureValue = 0;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

		if (rotate)
			iTween.RotateAdd(gameObject, iTween.Hash("y", 359, "time", 9, "easetype", "linear", "looptype", "loop"));
		if (hover)
			iTween.MoveBy(gameObject, iTween.Hash("y", 20, "time", 1, "easetype", "linear", "looptype", "pingPong"));
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			MainController.AcquireTreasure(TreasureValue);
			Destroy(gameObject);
		}
	}
}
