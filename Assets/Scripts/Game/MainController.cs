using UnityEngine;
using System.Collections;

/**
 * Controls all of the static components of the game, including:
 * - Level UI
 * - Level completion UI
 * - Pause menu
 * - Notes for displaying messages to the player
 * - General game status (current level, floor, etc.)
 */
public class MainController : MonoBehaviour {
	public bool UION;
	public static GameObject instance;

	// Current game.
	public static Game CurrentGame;
	public static Level CurrentLevel;
	public static int CurrentLevelNumber;
	public static int CurrentFloor;

	// Menus and UI.
	public static GameObject LevelUI;
	static LevelUIController LevelUICtrl;
	public static GameObject Notes;
	static NoteController NoteCtrl;
	public static GameObject PauseMenu;
	static PauseMenuController PauseMenuCtrl;
	public static GameObject LevelComplete;
	static LevelCompleteController LevelCompleteCtrl;

	// Whether or not the game is paused.
	public static bool IsPaused;

	void Awake() {
		instance = this.gameObject;

		// Create new game or load game save.
		SaveController.LoadGame();

		// Get objects.
		LevelUI = GameObject.Find("Level UI");
		LevelUICtrl = LevelUI.GetComponent<LevelUIController>();
		Notes = GameObject.Find("Note UI");
		NoteCtrl = Notes.GetComponent<NoteController>();
		PauseMenu = GameObject.Find("Pause Menu");
		LevelComplete = GameObject.Find("Level Complete");
		if (UION) {
			PauseMenuCtrl = PauseMenu.GetComponent<PauseMenuController>();
			LevelCompleteCtrl = LevelComplete.GetComponent<LevelCompleteController>();
		}

		// Make sure prefabs are not destroyed.
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(transform.gameObject);
		DontDestroyOnLoad(LevelUI);
		DontDestroyOnLoad(Notes);
		DontDestroyOnLoad(PauseMenu);
		DontDestroyOnLoad(LevelComplete);

		// Hide unneeded things.
		// TODO comment out if not starting from title screen
		HideLevelUI();
		HideNote();
		if (UION) PauseMenuCtrl.HidePauseMenu(true);
		IsPaused = false;
		if (UION) LevelCompleteCtrl.HideLevelComplete();
	}
	void Start() {
		CurrentFloor = 1;
		// TODO
	}
	void OnApplicationQuit() {
		// Save the game before quitting.
		SaveController.SaveGame();
	}
	void Update() {
		if (Notes.activeSelf && Input.GetMouseButtonDown(0)) {
			HideNote();
		}
	}

	/* ---------------------------------------------------- OTHER --------------------------------------------------- */
	
	public static void GetNextFloor() {
		CurrentLevel.GetNextFloor();
	}

	/* -------------------------------------------------- LEVEL UI -------------------------------------------------- */

	public static void HideLevelUI() {
		LevelUI.SetActive(false);
	}
	public static void ShowLevelUI() {
		LevelUI.SetActive(true);
	}
	public static void AcquireTreasure(int amount) {
		LevelUICtrl.AcquireTreasure(amount);
	}
	public static void IncreaseHP(int numIntervals) {
		LevelUICtrl.IncreaseHP(numIntervals);
	}
	public static void DecreaseHP(int numIntervals) {
		LevelUICtrl.DecreaseHP(numIntervals);
	}
	public static void ShowFloorNumber() {
		LevelUICtrl.ShowFloor(CurrentLevel.CurrentFloor);
	}
	
	/* ---------------------------------------------------- NOTES --------------------------------------------------- */
	
	public static void ShowNote(string note, bool autoDismiss=true) {
		NoteCtrl.ShowNote(note, autoDismiss);
	}
	public static void HideNote() {
		NoteCtrl.HideNote();
	}

	/* ------------------------------------------------- PAUSE MENU ------------------------------------------------- */
	
	public static bool ShouldPause() {
		return PauseMenuCtrl.IsPaused || LevelCompleteCtrl.IsLevelCompleteShown;
	}
	public static void TogglePauseMenu() {
		PauseMenuCtrl.TogglePauseMenu();
	}

	/* ------------------------------------------ LEVEL COMPLETE DISPLAY -------------------------------------------- */

	public static void ShowLevelComplete(int amount) {
		LevelCompleteCtrl.ShowLevelComplete(amount);
	}
	public static void HideLevelComplete() {
		LevelCompleteCtrl.HideLevelComplete();
	}
}
