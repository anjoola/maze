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

	Vector3 StartPos;
	Vector3 HidePos;

	void Start() {
		StartPos = new Vector3(1, -166, 0);
		HidePos = new Vector3(-1000, -1000, -1000);
	}

	/**
	 * Show the note.
	 * 
	 * text: Text to show.
	 * autoDimiss: Whether or not this note will dismiss itself.
	 */
	public void ShowNote(string text, bool autoDismiss=true) {
		ActiveImage.SetActive(false);
		NoteText.text = text;

		// Hide item, show real note.
		ItemNotePanel.transform.localPosition = HidePos;
		NotePanel.transform.localPosition = StartPos;

		if (autoDismiss) {
			StopCoroutine("Dismiss");
			StartCoroutine("Dismiss", false);
		}
	}

	public void ShowItemNote(string item, bool fake=false) {
		ActiveImage.SetActive(false);
		string text = "";
		switch (item) {
			case "Bomb":
				ActiveImage = Bomb;
				if (MainController.CurrentGame.CloneIntroduced)
					text = "Picked up a Bomb!\nEnemies nearby ...except Shadows... have been destroyed!";
				else
				    text = "Picked up a Bomb!\nEnemies nearby have been destroyed!";
				break;
			case "FullPotion":
				ActiveImage = FullPotion;
				text = "Picked up a Full Potion!\nWoohoo! Health has been restored to maximum.";
				break;
			case "InvinciblePotion":
				ActiveImage = InvinciblePotion;
				text = "Picked up an Invincible Potion!\nYou are now invincible for the entire floor. " +
					"Nothing can hurt you!";
				break;
			case "LargePotion":
				ActiveImage = LargePotion;
				text = "Picked up a Large Potion!\nHealth has been restored by 4 HP.";
				break;
			case "PoisonPotion":
				ActiveImage = PoisionPotion;
				if (MainController.IsInvincible)
					text = "Picked up a Poisonous Elixir...\nExcept you're invincinble so you aren't harmed!";
				else
					text = "Picked up a Poisonous Elixir!\nOops... health has been reduced by 2 HP.";
				break;
			case "MagicGoggles":
				ActiveImage = SeeAllGoggles;
				text = "Picked up a Magic Goggles!\nAll maze walls have disappeared for this floor!";
				break;
			case "SmallPotion":
				ActiveImage = SmallPotion;
				text = "Picked up a Small Potion!\nHealth has been restored by 1 HP.";
				break;
			case "TNTItem":
				ActiveImage = TNT;
				if (MainController.CurrentGame.CloneIntroduced)
					text = "Picked up a TNT!\nAll enemies on this floor ...except Shadows... have been destroyed!";
				else
					text = "Picked up a TNT!\nAll enemies on this floor have been destroyed!";
				break;
			default:
				return;
		}
		ActiveImage.SetActive(true);
		ItemNoteText.text = text;

		// Hide real note panel, show item note.
		NotePanel.transform.localPosition = HidePos;
		ItemNotePanel.transform.localPosition = StartPos;

		if (fake)
			ItemNotePanel.transform.localPosition = HidePos;
		StopCoroutine("Dismiss");
		StartCoroutine("Dismiss", true);
	}

	/**
	 * Hide the note.
	 */
	public void HideNote() {
		ActiveImage.SetActive(false);
		HidePos = new Vector3(-1000, -1000, -1000);
		NotePanel.transform.localPosition = HidePos;
		ItemNotePanel.transform.localPosition = HidePos;
	}

	/**
	 * Dismiss a note after a certain period.
	 */
	IEnumerator Dismiss(bool isItemNote) {
		int numChars = isItemNote ? ItemNoteText.text.Length : NoteText.text.Length;
		yield return new WaitForSeconds(Mathf.Max(numChars * WAIT_TIME_PER_CHAR, MIN_WAIT_TIME));
		HideNote();
	}
}
