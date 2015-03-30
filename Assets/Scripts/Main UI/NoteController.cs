using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoteController : MonoBehaviour {
	public static NoteController instance;

	float SCALE = 0.001f;
	float TIME = 0.2f;

	public Text TextField;
	public GameObject NotePanel;
	public GameObject Pointer;
	public GameObject NoteObject;

	// True if the note can be dismissed anywhere, false if the note must be tapped to be dismissed.
	public bool CanDismissAnywhere;

	void Awake() {
		instance = this;
		DontDestroyOnLoad(this.gameObject);

		// Move pointer up and down.
		iTween.MoveBy(Pointer, iTween.Hash("amount", new Vector3(0, 0.1f, 0), "easeType", "linear",
		                                   "loopType", "pingPong", "delay", 0.0, "time", 0.5f));
	}
	void Start() {
		CanDismissAnywhere = false;
	}

	public void SetText(string text) {
		TextField.text = text;
	}
	
	public void ShowNote(bool canDismissAnywhere=false) {
		// If the note is already shown, do nothing.
		if (NoteObject.activeSelf) {
			return;
		}
		CanDismissAnywhere = canDismissAnywhere;
		NoteObject.SetActive(true);
		iTween.ScaleBy(NotePanel, iTween.Hash("y", 1/SCALE, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", TIME, "oncomplete", "activate", "oncompletetarget", NoteObject));
	}
	public void HideNote(bool hideQuickly=false) {
		// If the note is already hidden, do nothing.
		if (!NoteObject.activeSelf) {
			return;
		}
		Pointer.SetActive(false);
		float time = hideQuickly ? 0 : TIME;
		iTween.ScaleBy(NotePanel, iTween.Hash("y", SCALE, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", time, "oncomplete", "deactivate",
		                                      "oncompletetarget", NoteObject));
	}
	
	public void Activate() {
		Pointer.SetActive(true);
	}
	public void Deactivate() {
		NoteObject.SetActive(false);
	}
}
