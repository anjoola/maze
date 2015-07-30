using UnityEngine;
using System.Collections;

public abstract class Item : SpawnObject {
	public override int SpaceNeeded { get { return 0; } }
	public abstract string ItemName { get; }

	public GameObject player;
	public bool rotate = false;
	public bool hover = false;
	
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
			MainController.ShowItemNote(ItemName);
			AudioController.playSFX(ItemName);
			ItemEffect();
			Destroy(gameObject);
		}
	}

	/**
	 * Effect this item has. Does the action (such as healing, etc.).
	 */
	protected abstract void ItemEffect();
}
