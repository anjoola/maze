using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Shows the pause menu and changes the audio volume.
public class PauseMenuController : MonoBehaviour {
	public static PauseMenuController instance;

	float DISPLAY_TIME = 0.3f;
	float SCALE = 20;

	public Text LevelName;
	public GameObject Overlay;
	public GameObject UpperPanel;
	public GameObject Buttons;

	private bool IsVisible;
	public bool IsPaused;

	void Awake() {
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		IsVisible = true;
	}

	public void UpdateText(string levelName) {
		LevelName.text = levelName;
	}

	public void HidePauseMenu(bool quickly=false) {
		// TODO handle if not in a level if (currentLevel == null && enabled) return;
		IsPaused = false;

		SlideOut(quickly);
		AudioController.ResumeVolume();
		LevelUIController.instance.ResumeTimer();
	}
	public void ShowPauseMenu() {
		// TODO handle if not in a level if (currentLevel == null && enabled) return;
		IsPaused = true;

		UpdateText(MainUIController.currentLevel.assetsName);
		LevelUIController.instance.PauseTimer();
		SlideIn();
		AudioController.ReduceVolume();
	}

	public void SlideIn() {
		if (IsVisible) return;

		this.gameObject.SetActive(true);
		iTween.MoveBy(UpperPanel, iTween.Hash("y", -4, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", DISPLAY_TIME));
		iTween.ScaleBy(Buttons, iTween.Hash("x", SCALE, "y", SCALE, "z", SCALE, "easeType", "linear",
		                                    "loopType", "none", "delay", 0.0, "time", DISPLAY_TIME));
		IsVisible = true;
	}
	public void SlideOut(bool quickly=false) {
		if (!IsVisible) return;

		float time = quickly ? 0 : DISPLAY_TIME;
		iTween.MoveBy(UpperPanel, iTween.Hash("y", 4, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", time));
		iTween.ScaleBy(Buttons, iTween.Hash("x", 1/SCALE, "y", 1/SCALE, "z", 1/SCALE, "easeType", "linear",
		                                    "loopType", "none", "delay", 0.0, "time", time,
		                                    "oncomplete", "Deactivate", "oncompletetarget", this.gameObject));
		IsVisible = false;
	}
	public void Deactivate() {
		this.gameObject.SetActive(false);
	}

	// Button handlers.
	public void OnResumeClicked() {
		AudioController.PlayButtonPress();
		HidePauseMenu();
	}
	public void OnRestartClicked() {
		AudioController.PlayButtonPress();
		MainUIController.RestartLevel();
	}
	public void OnQuitClicked() {
		AudioController.PlayButtonPress();
		MainUIController.ExitLevel();
	}
}
