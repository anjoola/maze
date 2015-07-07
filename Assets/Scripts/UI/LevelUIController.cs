using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Controls the level UI, including the number of points, the level name, and the HP of the player.
 */
public class LevelUIController : MonoBehaviour {
	// Treasure.
	public Text Treasure;
	int TreasureAmt;

	// HP bar.
	public GameObject[] HP;
	int HPIntervals;

	// Floor number.
	public GameObject FloorObject;
	public Text Floor;

	void Start() {
		// Start with 0 treasure.
		TreasureAmt = 0;

		// Start a 100% HP.
		HPIntervals = 10;
		for (int i = 0; i < 10; i++) {
			HP[i].SetActive(true);
		}

		FloorObject.SetActive(false);
	}

	/**
	 * Increase the amount of treasure.
	 *
	 * amount: Amount to increase by.
	 */
	public void AcquireTreasure(int amount) {
		Treasure.text = ("" + TreasureAmt + amount).PadLeft(6, '0');
	}

	/**
	 * Increase HP by the given number of intervals (HP increases in 10% intervals).
	 * 
	 * numIntervals: Number of intervals to increase by.
	 */
	public void IncreaseHP(int numIntervals) {
		for (int i = 0; i < numIntervals; i++) {
			// Can't increase HP anymore.
			if (i + HPIntervals - 1 > 10)
				break;

			HP[i + HPIntervals - 1].SetActive(true);
		}
		HPIntervals += numIntervals;
	}

	/**
	 * Decrease HP by the given number of intervals (HP decreases in 10% intervals).
	 * 
	 * numIntervals: Number of intervals to decrease by.
	 */
	public void DecreaseHP(int numIntervals) {
		for (int i = 0; i < numIntervals; i++) {
			// Can't decrease HP anymore.
			if (HPIntervals - i - 1 < 0)
				break;
			
			HP[HPIntervals - i - 1].SetActive(false);
		}
		HPIntervals -= numIntervals;
	}

	/**
	 * Briefly show the current floor number.
	 *
	 * floor: The floor number to show.
	 */
	public void ShowFloor(int floor) {
		FloorObject.SetActive(true);
		Floor.text = "Floor " + floor;
		StartCoroutine(Dismiss());
	}

	/**
	 * Dismiss the floor number after a certain period.
	 */
	IEnumerator Dismiss() {
		yield return new WaitForSeconds(2f);
		FloorObject.SetActive(false);
	}
}
