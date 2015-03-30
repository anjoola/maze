using UnityEngine;
using System.Collections;

public class MainUIController : MonoBehaviour {
	public static GameObject instance;

	public static Game CurrentGame;
	public static Level currentLevel;

	public enum CompletionType {
		GameOver,
		TimeUp,
		LevelComplete
	};

	void Awake() {
		instance = this.gameObject;
		DontDestroyOnLoad(instance);
	}
	void OnApplicationQuit() {
		SaveController.Save();
	}
	void Start() {
		SaveController.Load();
	
		// Hide menus for now.
		PauseMenuController.instance.HidePauseMenu(true);
		LevelUIController.instance.Disable();
		//LevelCompleteController.instance.SlideOut();
		NoteController.instance.HideNote(true);
	}
	void Update() {
		// Check for dismissing the note anywhere.
		if (Input.GetMouseButtonDown(0) && NoteController.instance.CanDismissAnywhere) {
			NoteController.instance.HideNote();
		}
	}

	public static bool ShouldPause() {
		return PauseMenuController.instance.IsPaused ||
		       LevelUIController.instance.TimeLeft == 0 ||
		       NoteController.instance.ShouldPause();
	}

	public static void StartLevel() {
		currentLevel.start();
		LevelUIController.instance.ResetScore();

		AutoFade.LoadLevel(currentLevel.sceneName, 0.2f, 0.2f, Color.black, OnStartLevelFinish);
	}
	public static void OnStartLevelFinish() {
		PauseMenuController.instance.HidePauseMenu(true);
		//LevelCompleteController.instance.SlideOut();

		LevelUIController.instance.EnableWithTime(currentLevel.maxTime);
	}
	public static void RestartLevel() {
		AutoFade.LoadLevel(currentLevel.sceneName, 0.2f, 0.2f, Color.black, OnRestartLevelFinish);
	}
	public static void OnRestartLevelFinish() {
		PauseMenuController.instance.HidePauseMenu(true);
		//LevelCompleteController.instance.SlideOut();

		LevelUIController.instance.ResetScore();
		currentLevel.start();

		LevelUIController.instance.EnableWithTime(currentLevel.maxTime);
	}
	public static void ExitLevel() {
		AutoFade.LoadLevel("WorldMap", 0.2f, 0.2f, Color.black, OnExitLevelComplete);
	}
	private static void OnExitLevelComplete() {
		NoteController.instance.HideNote(true);
		LevelUIController.instance.Disable();
		PauseMenuController.instance.HidePauseMenu(true);
		//LevelCompleteController.instance.SlideOut();
	}
	public static void finishLevel(CompletionType type) {
		// Hide UI.
		NoteController.instance.HideNote(true);
		LevelUIController.instance.DisableMenuButton();
		LevelUIController.instance.StopTimer();
		PauseMenuController.instance.HidePauseMenu(true);


		// Stop music and timer.
		//AudioController.PlaySFX("EndLevel", 5.0f);
		//AudioController.PlayAudio("LevelComplete", false);

		// Set level completion message.
		switch (type) {
			case CompletionType.GameOver:
				//LevelCompleteController.instance.gameOver();
				break;
			case CompletionType.LevelComplete:
				//LevelCompleteController.instance.levelComplete();
				break;
			case CompletionType.TimeUp:
				//LevelCompleteController.instance.timeUp();
				break;
		}

		//LevelCompleteController.instance.SlideIn();

		currentLevel.finish();
	}
}
