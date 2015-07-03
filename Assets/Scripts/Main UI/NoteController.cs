using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Shows a note to the player.
 */
public class NoteController : MonoBehaviour {
	public static NoteController instance;

	public Text NoteText;
	public GameObject NoteObject;

	// True if the note should dismiss itself.
	bool AutoDismiss;
	
	void Awake() {
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		AutoDismiss = false;
	}

	/**
	 * Show the note.
	 * 
	 * text: Text to show.
	 * autoDimiss: Whether or not this note will dismiss itself.
	 */
	public void ShowNote(string text, bool autoDismiss=false) {
		NoteText.text = text;
		AutoDismiss = autoDismiss;

		// If the note is already shown, do nothing.
		if (NoteObject.activeSelf)
			return;
		NoteObject.SetActive(true);

		// TODO automdismiss
	}
	public void HideNote() {
		// If the note is already hidden, do nothing.
		if (!NoteObject.activeSelf)
			return;

		NoteObject.SetActive(false);
	}
}
