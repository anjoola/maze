using UnityEngine;
using System.Collections;

/**
 * Controls all of the static components of the game, including:
 * - Level UI
 * - Notes for displaying messages to the player
 * TODO
 */
public class MainController : MonoBehaviour {
	public static GameObject instance;

	// Menus and UI.
	public static GameObject LevelUI;
	static LevelUIController LevelUICtrl;
	public static GameObject Notes;
	static NoteController NoteCtrl;

	void Awake() {
		instance = this.gameObject;

		// Get objects.
		LevelUI = GameObject.Find("Level UI");
		LevelUICtrl = LevelUI.GetComponent<LevelUIController>();
		Notes = GameObject.Find("Note UI");
		NoteCtrl = Notes.GetComponent<NoteController>();

		// Make sure prefabs are not destroyed.
		DontDestroyOnLoad(gameObject);
		DontDestroyOnLoad(transform.gameObject);
		DontDestroyOnLoad(LevelUI);
		DontDestroyOnLoad(Notes);

		// Hide unneeded things.
		HideNote();
	}
	void Start() {
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
	
	/* ---------------------------------------------------- NOTES ----------------------------------------------------*/
	
	public static void ShowNote(string note, bool autoDismiss=false) {
		NoteCtrl.ShowNote(note, autoDismiss);
	}
	public static void HideNote() {
		NoteCtrl.HideNote();
	}
}
