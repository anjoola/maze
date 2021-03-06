using UnityEngine;
using System.Collections;

public class Treasure : SpawnObject {
	public override int SpaceNeeded { get { return 0; } }

	public GameObject player;
	public bool rotate = false;
	public bool hover = false;

	public string AudioFile = null;

	// Value of this treasure.
	public int TreasureValue = 0;

	public int ROTATE_SPEED = 9;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

		if (rotate)
			iTween.RotateAdd(gameObject, iTween.Hash("y", 359, "time", ROTATE_SPEED, "easetype", "linear",
			                                         "looptype", "loop"));
		if (hover) {
			iTween.MoveAdd(gameObject, iTween.Hash("y", 20, "time", 0, "loopType", "none"));
			iTween.MoveBy(gameObject, iTween.Hash("y", 20, "time", 1, "easetype", "linear", "looptype", "pingPong"));
		}
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			if (AudioFile != null)
				AudioController.playSFX(AudioFile);
			MainController.AcquireTreasure(TreasureValue);
			Destroy(gameObject);
		}
	}
}
