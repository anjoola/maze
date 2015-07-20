using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Controls the level UI, including the number of points, the level name, and the HP of the player.
 */
public class LevelUIController : MonoBehaviour {
	// Treasure.
	public Text Treasure;
	public int TreasureAmt;
	public static int TreasureAcquired;

	// HP bar.
	public GameObject[] HP;
	int HPIntervals;

	// HP image.
	public GameObject HPFull, HPMissing, HPLow;

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
		TreasureAmt = Mathf.Min(TreasureAmt + amount, 9999999);
		TreasureAcquired += amount;
		Treasure.text = ("" + TreasureAmt).PadLeft(7, '0');
	}

	/**
	 * Reset the treasure received.
	 */
	public void ResetTreasure() {
		TreasureAmt = 0;
		TreasureAcquired = 0;
		Treasure.text = ("0").PadLeft(7, '0');
	}

	/**
	 * Restores all HP.
	 */
	public void RestoreHP() {
		HPIntervals = 10;
		for (int i = 0; i < 10; i++) {
			HP[i].SetActive(true);
		}
		HPLow.SetActive(false);
		HPMissing.SetActive(false);
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
				break;
			
			HP[HPIntervals].SetActive(true);
			HPIntervals++;
		}

		if (HPIntervals == 10)
			HPMissing.SetActive(false);
		if (HPIntervals > 3)
			HPLow.SetActive(false);
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
				break;
			}

			HPIntervals--;
			HP[HPIntervals].SetActive(false);
		}

		if (HPIntervals < 10)
			HPMissing.SetActive(true);
		if (HPIntervals < 3)
			HPLow.SetActive(true);
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
		yield return new WaitForSeconds(1.5f);
		FloorObject.SetActive(false);
	}

	/**
	 * Hide the current floor number.
	 */
	public void HideFloor() {
		FloorObject.SetActive(false);
	}
}
