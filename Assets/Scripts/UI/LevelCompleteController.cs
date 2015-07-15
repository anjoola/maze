using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Shown when the player completes a level.
 */
public class LevelCompleteController : MonoBehaviour {
	public static string LEVEL_COMPLETE = "Level Complete!";
	public static string GAME_OVER = "Game Over!";

	float DISPLAY_TIME = 0.3f;
	public GameObject UpperPanel, Buttons, Overlay;
	public GameObject TreasureObj, DeadObj;
	public Text Status, Treasure;
	
	// Whether or not it is shown.
	public bool IsLevelCompleteShown = true;
	
	// Original time scale.
	float OldTimeScale = -1;
	
	public void ShowLevelComplete(int amount) {
		if (IsLevelCompleteShown) return;
		IsLevelCompleteShown = true;

		// Level complete! Set treasure amount.
		if (amount >= 0) {
			Treasure.text = ("" + amount).PadLeft(6, '0');
			Status.text = LEVEL_COMPLETE;
			DeadObj.SetActive(false);
			TreasureObj.SetActive(true);
		}
		// Game over.
		else {
			Status.text = GAME_OVER;
			DeadObj.SetActive(true);
			TreasureObj.SetActive(false);
		}

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
		iTween.MoveBy(UpperPanel, iTween.Hash("y", 6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", 0, "ignoretimescale", true));
		iTween.MoveBy(Buttons, iTween.Hash("y", -6, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                   "time", 0, "ignoretimescale", true));

		if (OldTimeScale != -1)
			Time.timeScale = OldTimeScale;
	}
	
	/**
	 * Restarts the current level.
	 */
	public void Restart() {
		Level level = MainController.CurrentGame.Levels[MainController.CurrentLevelNumber - 1];
		level.Start();
		HideLevelComplete();
	}

	/**
	 * Exits the current level.
	 */
	public void Exit() {
		HideLevelComplete();
		AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black);
	}
}
