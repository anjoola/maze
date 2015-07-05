using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Shows a note to the player.
 */
public class NoteController : MonoBehaviour {
	public Text NoteText;
	public GameObject NotePanel;
	public GameObject NoteObject;

	// Waiting time duration per word before automatically dismissing a note.
	float WAIT_TIME_PER_WORD = 0.45f;
	float MIN_WAIT_TIME = 1.5f;

	/**
	 * Show the note.
	 * 
	 * text: Text to show.
	 * autoDimiss: Whether or not this note will dismiss itself.
	 */
	public void ShowNote(string text, bool autoDismiss=true) {
		NoteText.text = text;

		// If the note is already shown, do nothing.
		if (NoteObject.activeSelf)
			return;
		else
			NoteObject.SetActive(true);

		if (autoDismiss)
			StartCoroutine(Dismiss());
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
		yield return new WaitForSeconds(Mathf.Max(numWords * WAIT_TIME_PER_WORD, MIN_WAIT_TIME));
		HideNote();
	}
}
