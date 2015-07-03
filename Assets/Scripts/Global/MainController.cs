using UnityEngine;
using System.Collections;

/**
 * Controls all of the static components of the game, including:
 * - Level UI
 * - Notes for displaying messages to the player
 * TODO
 */
public class MainController : MonoBehaviour {
	public bool UION;
	public static GameObject instance;

	// Menus and UI.
	public static GameObject LevelUI;
	static LevelUIController LevelUICtrl;
	public static GameObject Notes;
	static NoteController NoteCtrl;
	public static GameObject PauseMenu;
	static PauseMenuController PauseMenuCtrl;
	public static GameObject LevelComplete;
	static LevelCompleteController LevelCompleteCtrl;

	// Current floor.
	public static int CurrentFloor;

	// Whether or not the game is paused.
	public static bool IsPaused;

	void Awake() {
		instance = this.gameObject;

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
		// TODO SaveController.saveGame();
	}
	void Update() {
		if (Notes.activeSelf && Input.GetMouseButtonDown(0)) {
			HideNote();
		}
	}

	/* -------------------------------------------------- LEVEL UI ---------------------------------------------------*/

	public static void AcquireTreasure(int amount) {
		LevelUICtrl.AcquireTreasure(amount);
	}
	public static void IncreaseHP(int numIntervals) {
		LevelUICtrl.IncreaseHP(numIntervals);
	}
	public static void DecreaseHP(int numIntervals) {
		LevelUICtrl.DecreaseHP(numIntervals);
	}
	public static void ShowNextFloor() {
		LevelUICtrl.ShowFloor(CurrentFloor); // TODO next floor
	}
	
	/* ---------------------------------------------------- NOTES ----------------------------------------------------*/
	
	public static void ShowNote(string note, bool autoDismiss=true) {
		NoteCtrl.ShowNote(note, autoDismiss);
	}
	public static void HideNote() {
		NoteCtrl.HideNote();
	}

	/* ------------------------------------------------- PAUSE MENU --------------------------------------------------*/

	public static void TogglePauseMenu() {
		PauseMenuCtrl.TogglePauseMenu();
		IsPaused = PauseMenuCtrl.IsPaused;
	}

	/* ------------------------------------------ LEVEL COMPLETE DISPLAY ---------------------------------------------*/

	public static void ShowLevelComplete(int amount) {
		LevelCompleteCtrl.ShowLevelComplete(amount);
	}
	public static void HideLevelComplete() {
		LevelCompleteCtrl.HideLevelComplete();
	}
}
