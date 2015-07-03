using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Shows a note to the player.
 */
public class NoteController : MonoBehaviour {
	public static NoteController instance;

	public Text NoteText;
	public GameObject NotePanel;
	RawImage NotePanelImage;
	public GameObject NoteObject;

	// True if the note should dismiss itself.
	bool AutoDismiss;

	// Waiting time duration per word before automatically dismissing a note.
	float WAIT_TIME_PER_WORD = 0.4f;
	
	void Awake() {
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		AutoDismiss = false;
		NotePanelImage = NotePanel.GetComponent<RawImage>();
	}

	/**
	 * Show the note.
	 * 
	 * text: Text to show.
	 * autoDimiss: Whether or not this note will dismiss itself.
	 */
	public void ShowNote(string text, bool autoDismiss=true) {
		NoteText.text = text;
		AutoDismiss = autoDismiss;

		// If the note is already shown, do nothing.
		if (NoteObject.activeSelf)
			return;
		else
			NoteObject.SetActive(true);

		if (autoDismiss) {
			instance.StartCoroutine(Dismiss());
		}
	}

	/**
	 * Hide the note.
	 */
	public void HideNote() {
		// If the note is already hidden, do nothing.
		if (!NoteObject.activeSelf)
			return;

		NoteObject.SetActive(false);
	}

	/**
	 * Dismiss a note after a certain period.
	 */
	IEnumerator Dismiss() {
		int numWords = NoteText.text.Split(' ').Length;
		yield return new WaitForSeconds(numWords * WAIT_TIME_PER_WORD);
		HideNote();
	}
}
