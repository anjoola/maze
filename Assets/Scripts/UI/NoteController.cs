using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
 * Shows a note to the player.
 */
public class NoteController : MonoBehaviour {
	public Text NoteText, ItemNoteText;
	public GameObject NotePanel, ItemNotePanel;

	public GameObject ActiveImage;
	public GameObject Bomb, FullPotion, InvinciblePotion, LargePotion, PoisionPotion, SeeAllGoggles, SmallPotion, TNT;

	// Waiting time duration per word before automatically dismissing a note.
	float WAIT_TIME_PER_CHAR = 0.07f;
	float MIN_WAIT_TIME = 1.5f;

	// Number of notes currently shown. This is to prevent a previous note's disappearance from interfering with a
	// current note's appearance.
	int NumShowing = 0;

	/**
	 * Show the note.
	 * 
	 * text: Text to show.
	 * autoDimiss: Whether or not this note will dismiss itself.
	 */
	public void ShowNote(string text, bool autoDismiss=true) {
		NumShowing++;
		NoteText.text = text;
		if (ItemNotePanel.activeSelf)
			ItemNotePanel.SetActive(false);

		// If the note is already shown, do nothing.
		if (NotePanel.activeSelf)
			return;
		else
			NotePanel.SetActive(true);

		if (autoDismiss)
			StartCoroutine(Dismiss(false));
	}

	public void ShowItemNote(string item, bool autoDismiss=true) {
		string text = "";
		switch (item) {
			case "Bomb":
				ActiveImage = Bomb;
				text = "Picked up a Bomb!\nEnemies nearby have been destroyed!";
				break;
			case "FullPotion":
				ActiveImage = FullPotion;
				text = "Picked up a Full Potion!\nWoohoo! Health has been restored to maximum.";
				break;
			case "InvinciblePotion":
				ActiveImage = InvinciblePotion;
				text = "Picked up an Invincible Potion!\nYou are now invincible for the entire floor. " +
					"No enemies can hurt you!";
				break;
			case "LargePotion":
				ActiveImage = LargePotion;
				text = "Picked up a Large Potion!\nHealth has been restored by 4 HP.";
				break;
			case "PoisonPotion":
				ActiveImage = PoisionPotion;
				text = "Picked up a Poisonous Elixir!\nOops... health has been reduced by 2 HP.";
				break;
			case "SeeAllGoggles":
				ActiveImage = SeeAllGoggles;
				text = "Picked up a See-All Goggles!\nAll maze walls are invinsible for this floor!";
				break;
			case "SmallPotion":
				ActiveImage = SmallPotion;
				text = "Picked up a Small Potion!\nHealth has been restored by 1 HP.";
				break;
			case "TNT":
				ActiveImage = TNT;
				text = "Picked up a TNT!\nAll enemies on this floor have been destroyed!";
				break;
			default:
				return;
		}
		ActiveImage.SetActive(true);
		ItemNoteText.text = text;
		if (NotePanel.activeSelf)
			NotePanel.SetActive(false);

		// If the note is already shown, do nothing.
		if (ItemNotePanel.activeSelf)
			return;
		else
			ItemNotePanel.SetActive(true);

		if (autoDismiss)
			StartCoroutine(Dismiss(true));
	}

	/**
	 * Hide the note.
	 */
	public void HideNote() {
		// If the note is already hidden, do nothing.
		if (!NotePanel.activeSelf && !ItemNotePanel.activeSelf)
			return;

		ActiveImage.SetActive(false);
		NotePanel.SetActive(false);
		ItemNotePanel.SetActive(false);
	}

	/**
	 * Dismiss a note after a certain period.
	 */
	IEnumerator Dismiss(bool isItemNote) {
		do {
			int numChars = isItemNote ? ItemNoteText.text.Length : NoteText.text.Length;
			yield return new WaitForSeconds(Mathf.Max(numChars * WAIT_TIME_PER_CHAR, MIN_WAIT_TIME));
			NumShowing--;
		} while (NumShowing > 1);
		HideNote();
	}
}
