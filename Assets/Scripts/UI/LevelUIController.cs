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
	public static int TreasureAcquired;

	// HP bar.
	public GameObject[] HP;
	int HPIntervals;

	// Floor number.
	public GameObject FloorObject;
	public Text Floor;

	void Start() {
		// Amount of treasure acquired overall.
		TreasureAmt = 0;

		// Amount of treasure acquired in the current level.
		TreasureAcquired = 0;

		RestoreHP();
	}

	/**
	 * Increase the amount of treasure.
	 *
	 * amount: Amount to increase by.
	 */
	public void AcquireTreasure(int amount) {
		TreasureAmt += amount;
		TreasureAcquired += amount;
		Treasure.text = ("" + TreasureAmt).PadLeft(6, '0');
	}

	/**
	 * Reset the treasure received.
	 */
	public void ResetTreasure() {
		TreasureAmt = 0;
		TreasureAcquired = 0;
		Treasure.text = ("0").PadLeft(6, '0');
	}

	/**
	 * Restores all HP.
	 */
	public void RestoreHP() {
		HPIntervals = 10;
		for (int i = 0; i < 10; i++) {
			HP[i].SetActive(true);
		}
	}

	/**
	 * Increase HP by the given number of intervals (HP increases in 10% intervals).
	 * 
	 * numIntervals: Number of intervals to increase by.
	 */
	public void IncreaseHP(int numIntervals) {
		for (int i = 0; i < numIntervals; i++) {
			// Can't increase HP anymore.
			if (HPIntervals + 1 > 10)
				return;
			
			HP[HPIntervals].SetActive(true);
			HPIntervals++;
		}
	}

	/**
	 * Decrease HP by the given number of intervals (HP decreases in 10% intervals).
	 * 
	 * numIntervals: Number of intervals to decrease by.
	 */
	public void DecreaseHP(int numIntervals) {
		for (int i = 0; i < numIntervals; i++) {
			// Can't decrease HP anymore. Player is dead!
			if (HPIntervals - 1 <= 0) {
				HP[0].SetActive(false);
				MainController.ShowGameOver();
				return;
			}

			HPIntervals--;
			HP[HPIntervals].SetActive(false);
		}
	}

	/**
	 * A new level started. Reset the amount of treasure acquired.
	 */
	public void NewLevel() {
		RestoreHP();
		TreasureAcquired = 0;
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
