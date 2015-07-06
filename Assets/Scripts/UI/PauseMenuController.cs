using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Pause menu. Handles resuming, restarting, and exiting the current level.
 */
public class PauseMenuController : MonoBehaviour {
	float DISPLAY_TIME = 0.3f;
	public GameObject UpperPanel, Buttons, Overlay;

	// Whether or not the game is currently paused.
	public bool IsPaused = true;

	// Original time scale.
	float OldTimeScale = -1;

	public void TogglePauseMenu() {
		if (IsPaused)
			HidePauseMenu();
		else
			ShowPauseMenu();
	}

	public void ShowPauseMenu() {
		if (IsPaused) return;
		IsPaused = true;

		Overlay.SetActive(true);
		iTween.MoveBy(UpperPanel, iTween.Hash("y", -2, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", DISPLAY_TIME, "ignoretimescale", true));
		iTween.MoveBy(Buttons, iTween.Hash("y", 6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                   "time", DISPLAY_TIME, "ignoretimescale", true));
		ShowPauseMenuDone();
	}
	public void ShowPauseMenuDone() {
		OldTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}

	public void HidePauseMenu(bool hurry=false) {
		if (!IsPaused) return;
		IsPaused = false;

		float time = hurry ? 0 : DISPLAY_TIME;

		Overlay.SetActive(false);
		if (OldTimeScale != -1)
			Time.timeScale = OldTimeScale;

		iTween.MoveBy(UpperPanel, iTween.Hash("y", 2, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", time));
		iTween.MoveBy(Buttons, iTween.Hash("y", -6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                   "time", time));
	}

	/**
	 * Resume the game.
	 */
	public void Resume() {
		HidePauseMenu();
	}

	/**
	 * Restarts the current level.
	 */
	public void Restart() {
		HidePauseMenu(true);
		Level level = MainController.CurrentGame.Levels[MainController.CurrentLevelNumber - 1];
		level.Start();
	}

	/**
	 * Exit this level and return to the world map.
	 */
	public void Exit() {
		HidePauseMenu(true);
		AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black);
	}
}
