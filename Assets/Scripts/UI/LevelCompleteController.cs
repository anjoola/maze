﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Shown when the player completes a level.
 */
public class LevelCompleteController : MonoBehaviour {
	float DISPLAY_TIME = 0.3f;
	public GameObject UpperPanel, Buttons, Overlay;
	public Text Treasure;
	
	// Whether or not it is shown.
	public bool IsLevelCompleteShown = true;
	
	// Original time scale.
	float OldTimeScale = -1;
	
	public void ShowLevelComplete(int amount) {
		if (IsLevelCompleteShown) return;
		IsLevelCompleteShown = true;

		// Set treasure amount.
		Treasure.text = ("" + amount).PadLeft(6, '0');;

		Overlay.SetActive(true);
		iTween.MoveBy(UpperPanel, iTween.Hash("y", -6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", DISPLAY_TIME, "ignoretimescale", true));
		iTween.MoveBy(Buttons, iTween.Hash("y", 6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                   "time", DISPLAY_TIME, "ignoretimescale", true));
		ShowLevelCompleteDone();
	}
	public void ShowLevelCompleteDone() {
		OldTimeScale = Time.timeScale;
		Time.timeScale = 0;
	}

	public void HideLevelComplete() {
		if (!IsLevelCompleteShown) return;
		IsLevelCompleteShown = false;
		
		Overlay.SetActive(false);
		if (OldTimeScale != -1)
			Time.timeScale = OldTimeScale;
		
		iTween.MoveBy(UpperPanel, iTween.Hash("y", 6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", 0));
		iTween.MoveBy(Buttons, iTween.Hash("y", -6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                   "time", 0));
	}

	/**
	 * Restarts the current level.
	 */
	public void Restart() {
		HideLevelComplete();
		Level level = MainController.CurrentGame.Levels[MainController.CurrentLevelNumber - 1];
		level.Start();
	}

	/**
	 * Exits the current level.
	 */
	public void Exit() {
		HideLevelComplete();
		AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black);
	}
}
