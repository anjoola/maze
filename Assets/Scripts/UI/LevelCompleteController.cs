using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Shown when the player completes a level.
 */
public class LevelCompleteController : MonoBehaviour {
	public static string LEVEL_COMPLETE = "Level Complete!";
	public static string GAME_OVER = "Game Over!";

	// Game over sounds.
	public string[] GameOverSounds = {
		"GameOver",
		"GameOver2",
		"GameOver3",
		"GameOver4",
		"GameOver5",
		"GameOver6"
	};
	// Level complete sounds.
	public string[] LevelCompleteSounds = {
		"YouDidIt",
		"YouDidIt2",
		"YouDidIt3",
		"YouDidIt4"
	};

	float DISPLAY_TIME = 0.3f;
	public GameObject UpperPanel, Buttons, Overlay;
	public GameObject TreasureObj, DeadObj;
	public Text Status, Treasure;
	
	// Whether or not it is shown.
	public bool IsLevelCompleteShown = true;
	
	// Original time scale.
	float OldTimeScale = -1;

	public void ShowLevelComplete(int amount) {
		MainController.StopLowHealth();
		MainController.HideNote();

		if (IsLevelCompleteShown) return;
		IsLevelCompleteShown = true;

		// Level complete! Set treasure amount.
		if (amount >= 0) {
			Treasure.text = ("" + amount).PadLeft(6, '0');
			Status.text = LEVEL_COMPLETE;
			DeadObj.SetActive(false);
			TreasureObj.SetActive(true);

			AudioController.playRandomSFX(LevelCompleteSounds);
			AudioController.playAudio(AudioController.AudioSourcesStatic[9]);
		}
		// Game over.
		else {
			Status.text = GAME_OVER;
			DeadObj.SetActive(true);
			TreasureObj.SetActive(false);
			AudioController.playRandomSFX(GameOverSounds);
			AudioController.halfVolume();
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
		AudioController.resumeVolume();
		if (!IsLevelCompleteShown && UpperPanel.transform.position.y < 3)
			return;
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
		AudioController.playSFX("ButtonSelect");
		Level level = MainController.CurrentLevel;
		level.Start();
		HideLevelComplete();
	}

	/**
	 * Exits the current level.
	 */
	public void Exit() {
		AudioController.playSFX("ButtonSelect");
		AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black);
		HideLevelComplete();
	}
}
