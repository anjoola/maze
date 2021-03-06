using UnityEngine;
using System.Collections;

/**
 * Controls all of the static components of the game, including:
 * - Level UI
 * - Level completion UI
 * - Pause menu
 * - Notes for displaying messages to the player
 * - General game status (current level, floor, etc.)
 * - Storing clone locations
 */
public class MainController : MonoBehaviour {
	public static GameObject instance;

	// All the levels in the game.
	public static Level[] LEVELS = new Level[] {
		new ForestLevel(),
		new TowerLevel(),
		new CaveLevel(),
		new PyramidLevel(),
		new CityLevel(),
		new CloudLevel()
	};

	// Current game.
	public static Game CurrentGame;
	public static Level CurrentLevel;
	public static int CurrentLevelNumber = 1;
	public static int CurrentFloor;

	// Menus and UI.
	public static GameObject LevelUI;
	public static LevelUIController LevelUICtrl;
	public static GameObject Notes;
	static NoteController NoteCtrl;
	public static GameObject PauseMenu;
	static PauseMenuController PauseMenuCtrl;
	public static GameObject LevelComplete;
	static LevelCompleteController LevelCompleteCtrl;

	// Player's past few positions.
	private static int NUM_PLAYER_LOCS = 150;
	private static int PlayerLocIdx = 0;
	public static CloneLocation[] PlayerLocations;

	// Level selections.
	public static int SelectedLevel = 1;
	public static int PrevHighestAvailableLevel = 1;

	// Player status.
	public static bool IsInvincible = false;
	public static PrefabMazeGen MazeGen = null;

	public GameObject overlay;

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
		PauseMenuCtrl = PauseMenu.GetComponent<PauseMenuController>();
		LevelCompleteCtrl = LevelComplete.GetComponent<LevelCompleteController>();

		// Make sure prefabs are not destroyed.
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(transform.gameObject);
		DontDestroyOnLoad(LevelUI);
		DontDestroyOnLoad(Notes);
		DontDestroyOnLoad(PauseMenu);
		DontDestroyOnLoad(LevelComplete);

		// Hide unneeded things.
		HideLevelUI();
		HideNote();
		PauseMenuCtrl.HidePauseMenu(true);
		LevelCompleteCtrl.HideLevelComplete();

		// Restore last played session and unlocked levels.
		PrevHighestAvailableLevel = CurrentGame.HighestLevelUnlocked;
		SelectedLevel = CurrentGame.LastLevelPlayed;
		LevelUICtrl.TreasureAmt = CurrentGame.TotalTreasure;
	}

	void Start() {
		overlay.SetActive(false);
		CurrentFloor = 1;
		AudioController.playContinuousAudio(0);
	}

	void OnApplicationQuit() {
		// Save the game before quitting.
		CurrentGame.LastLevelPlayed = CurrentLevelNumber;
		CurrentGame.TotalTreasure = LevelUICtrl.TreasureAmt;
		SaveController.SaveGame();
	}

	void Update() {
		if (Notes.activeSelf && Input.GetMouseButtonDown(0)) {
			HideNote();
		}
	}

	/* ---------------------------------------------------- OTHER --------------------------------------------------- */
	
	public static void GetNextFloor() {
		StopInvincible();
		HideNote();
		ResetLocations();
		CurrentLevel.GetNextFloor();
	}
	public static void BecomeInvincible() {
		IsInvincible = true;
		LevelUICtrl.ShowInvincible();
	}
	public static void StopInvincible() {
		IsInvincible = false;
		LevelUICtrl.HideInvincible();

	}
	public static void AddPlayerLocation(CloneLocation loc) {
		PlayerLocations[PlayerLocIdx] = loc;
		PlayerLocIdx = (PlayerLocIdx + 1) % PlayerLocations.Length;

		// Spawn another clone if desired.
		if (PlayerLocIdx % NUM_PLAYER_LOCS == 0 && CurrentLevel.ShouldSpawnClone())
			CurrentLevel.SpawnClone();
	}
	public static CloneLocation GetPlayerLocation(int idx) {
		return PlayerLocations[idx];
	}
	public static void ResetLocations() {
		PlayerLocations = new CloneLocation[NUM_PLAYER_LOCS * CurrentLevel.Floors[CurrentFloor - 1].NumClones + 500];
		PlayerLocIdx = 0;
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
	public static void NewLevel() {
		StopInvincible();
		ResetLocations();
		HideNote();
		LevelUICtrl.NewLevel();
	}
	public static void ShowFloorNumber() {
		LevelUICtrl.ShowFloor(CurrentLevel.CurrentFloor);
	}
	public static void HideFloor() {
		LevelUICtrl.HideFloor();
	}
	public static void StartLowHealth() {
		LevelUICtrl.StartLowHealth();
	}
	public static void StopLowHealth() {
		LevelUICtrl.StopLowHealth();
	}
	
	/* ---------------------------------------------------- NOTES --------------------------------------------------- */
	
	public static void ShowNote(string note, bool autoDismiss=true) {
		NoteCtrl.ShowNote(note, autoDismiss);
	}
	public static void ShowItemNote(string item, bool fake=false) {
		NoteCtrl.ShowItemNote(item, fake);
	}
	public static void HideNote() {
		NoteCtrl.HideNote();
	}

	/* ------------------------------------------------- PAUSE MENU ------------------------------------------------- */

	public static void ChangeLevelName(string name) {
		PauseMenuCtrl.ChangeLevelName(name);
	}
	public static bool ShouldPause() {
		return PauseMenuCtrl.IsPaused || LevelCompleteCtrl.IsLevelCompleteShown;
	}
	public static void TogglePauseMenu() {
		PauseMenuCtrl.TogglePauseMenu();
	}

	/* ------------------------------------------ LEVEL COMPLETE DISPLAY -------------------------------------------- */

	public static void ShowLevelComplete(int amount) {
		PrevHighestAvailableLevel = CurrentGame.HighestLevelUnlocked;
		if (CurrentLevelNumber == CurrentGame.HighestLevelUnlocked && CurrentLevelNumber != 6)
			CurrentGame.HighestLevelUnlocked++;
		LevelCompleteCtrl.ShowLevelComplete(amount);
	}
	public static void HideLevelComplete() {
		LevelCompleteCtrl.HideLevelComplete();
	}

	/**
	 * Game over. Show the game over display, lose all treasure.
	 */
	public static void ShowGameOver() {
		LevelUICtrl.ResetTreasure();
		LevelCompleteCtrl.ShowLevelComplete(-1);
	}
}
