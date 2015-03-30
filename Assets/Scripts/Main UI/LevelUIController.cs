using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUIController : MonoBehaviour {
	public static GameObject instance;

	public Text Timer;
	public Text Score;
	public GameObject MenuButton;

	// Updates the score and timer.
	public void UpdateScore(int score) {
		Score.text = score.ToString();
	}
	public void UpdateTimer(int time) {
		Timer.text = time.ToString().PadLeft(3, '0');
	}

	// Shows the menu if the menu button is clicked.
	public void ShowMenu() {
		MainUIController.pauseLevel();
	}
	public void EnableMenuButton(bool enabled) {
		MenuButton.SetActive(enabled);
	}
}
