using UnityEngine;
using System.Collections;

public class MainUIController : MonoBehaviour {
	public static GameObject instance;

	// This game.
	public static Game CurrentGame;
	public static Level currentLevel;

	// Menus and UI.
	public static GameObject PauseMenu;
	private static PauseMenuController PauseMenuController;
	public static GameObject LevelComplete;
	private static LevelCompleteController LevelCompleteController;

	// Pauses.
	public static bool isPaused;
	public static bool showNotePaused;
	public static bool timeUpPaused;

	public enum CompletionType {
		GameOver,
		TimeUp,
		LevelComplete
	};

	void Awake() {
		instance = this.gameObject;
		DontDestroyOnLoad(instance);
	
		// Get objects.
		PauseMenu = GameObject.Find("PauseMenu");
		PauseMenuController = PauseMenu.GetComponent("PauseMenuController") as PauseMenuController;
		LevelComplete = GameObject.Find("LevelComplete");
		LevelCompleteController = LevelComplete.GetComponent("LevelCompleteController") as LevelCompleteController;

		// Make sure prefabs are not destroyed.
		DontDestroyOnLoad(LevelComplete);
	}
	void OnApplicationQuit() {
		SaveController.Save();
	}
	void Start() {
		// Load savefile.
		SaveController.Load();
	
		// Hide menus for now.
		enablePauseMenu(false, true);
		LevelUIController.instance.Enable(false);
		enableLevelComplete(false);
		NoteController.instance.HideNote(true);

		isPaused = false;
	}
	void Update() {
		// Check for dismissing the note anywhere.
		if (Input.GetMouseButtonDown(0) && NoteController.instance.CanDismissAnywhere) {
			NoteController.instance.HideNote();
		}
	}

	public static bool shouldPause() {
		return isPaused || showNotePaused || timeUpPaused;
	}

	/* --------------------------------------------------- LEVELS ----------------------------------------------------*/
	
	public static void startLevel() {
		timeUpPaused = false;
		currentLevel.start();
		LevelUIController.instance.ResetScore();

		AutoFade.LoadLevel(currentLevel.sceneName, 0.2f, 0.2f, Color.black, onStartLevelFinish);
	}
	public static void onStartLevelFinish() {
		enablePauseMenu(false, true);
		enableLevelComplete(false);
		AudioController.ResumeVolume();

		LevelUIController.instance.Enable(true);
		LevelUIController.instance.EnableMenuButton(true);

		LevelUIController.instance.StartTimer(currentLevel.maxTime);
	}
	public static void restartLevel() {
		timeUpPaused = false;
		AutoFade.LoadLevel(currentLevel.sceneName, 0.2f, 0.2f, Color.black, onRestartLevelFinish);
	}
	public static void onRestartLevelFinish() {
		enablePauseMenu(false, true);
		enableLevelComplete(false);

		AudioController.ResumeVolume();
		LevelUIController.instance.ResetScore();
		currentLevel.start();
		LevelUIController.instance.Enable(true);
		LevelUIController.instance.EnableMenuButton(true);
		
		LevelUIController.instance.StartTimer(currentLevel.maxTime);
	}
	public static void pauseLevel() {
		LevelUIController.instance.PauseTimer();
		enablePauseMenu(true);
		AudioController.ReduceVolume();
	}
	public static void resumeLevel() {
		enablePauseMenu(false);
		LevelUIController.instance.ResumeTimer();
		AudioController.ResumeVolume();
	}
	public static void exitLevel() {
		AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black, onExitLevelComplete);
	}
	private static void onExitLevelComplete() {
		NoteController.instance.HideNote(true);
		LevelUIController.instance.StopTimer();

		timeUpPaused = false;
		LevelUIController.instance.Enable(false);
		enablePauseMenu(false, true);
		enableLevelComplete(false);

		AudioController.ResumeVolume();
	}
	public static void finishLevel(CompletionType type) {
		NoteController.instance.HideNote(true);

		// Stop music and timer.
		AudioController.ResumeVolume();
		//AudioController.PlaySFX("EndLevel", 5.0f);
		//AudioController.PlayAudio("LevelComplete", false);
		LevelUIController.instance.StopTimer();
		timeUpPaused = true;

		// Set level completion message.
		switch (type) {
			case CompletionType.GameOver:
				LevelCompleteController.gameOver();
				break;
			case CompletionType.LevelComplete:
				LevelCompleteController.levelComplete();
				break;
			case CompletionType.TimeUp:
				LevelCompleteController.timeUp();
				break;
		}

		LevelUIController.instance.EnableMenuButton(false);
		enablePauseMenu(false, true);
		enableLevelComplete(true);

		currentLevel.finish();
	}

	/* ----------------------------------------------------- UI ------------------------------------------------------*/

	/**
	 * Enable and disable UI.
	 */
	public static void enablePauseMenu(bool enabled, bool hurry=false) {
		if (currentLevel == null && enabled) return;
		
		isPaused = enabled;

		if (enabled) {
			PauseMenuController.updateText(currentLevel.assetsName, currentLevel.score);
			PauseMenuController.slideIn();
		}
		else {
			PauseMenuController.slideOut(hurry);
		}
	}
	public static void enableLevelComplete(bool enabled) {
		if (enabled) {
			LevelCompleteController.slideIn();
		} else {
			LevelCompleteController.slideOut();
		}
	}
}
