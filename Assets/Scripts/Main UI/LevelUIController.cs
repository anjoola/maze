using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUIController : MonoBehaviour {
	// HP bar.
	public GameObject[] HP;
	int HPIntervals;

	void Start() {
		// Start a 100% HP.
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
}
