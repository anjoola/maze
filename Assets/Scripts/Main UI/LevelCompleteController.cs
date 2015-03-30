using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelCompleteController : MonoBehaviour {
	public static LevelCompleteController instance;

	string TIME_UP = "Time's Up!";
	string GAME_OVER = "Game Over!";
	string LEVEL_COMPLETE = "Success!";
	float STAR_SCALE = 1.2f;
	float SCALE = 20.0f;
	float DISPLAY_TIME = 0.3f;

	public GameObject TopPanel;
	public GameObject Buttons;

	public Text Title;
	public GameObject Overlay;
	public GameObject[] Stars;

	private bool IsVisible;

	void Awake() {
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		IsVisible = true;

		// TODO remove later
		for (int i = 0; i < 5; i++) {
			Stars[i].SetActive(true);
			iTween.ScaleBy(Stars[i], iTween.Hash("x", STAR_SCALE, "y", STAR_SCALE, "z", STAR_SCALE,
			                                     "easeType", "linear", "loopType", "pingPong",
			                                     "delay", 0, "time", 0.6f));
			Stars[i].SetActive(false);
		}
	}

	public void SlideIn() {
		if (IsVisible) return;

		this.gameObject.SetActive(true);
		iTween.MoveBy(TopPanel, iTween.Hash("y", -10, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                      "time", DISPLAY_TIME));
		iTween.ScaleBy(Buttons, iTween.Hash("x", SCALE, "y", SCALE, "z", SCALE, "easeType", "linear",
		                                    "loopType", "none", "delay", 0.0, "time", DISPLAY_TIME));
		IsVisible = true;
	}
	public void SlideOut() {
		if (!IsVisible) return;

		iTween.MoveBy(TopPanel, iTween.Hash("y", 10, "easeType", "linear", "loopType", "none", "delay", 0.0,
		                                    "time", 0));
		iTween.ScaleBy(Buttons, iTween.Hash("x", 1/SCALE, "y", 1/SCALE, "z", 1/SCALE, "easeType", "linear",
		                                    "loopType", "none", "delay", 0.0, "time", 0,
		                                    "oncomplete", "Deactivate", "oncompletetarget", this.gameObject));
		IsVisible = false;
	}
	public void Deactivate() {
		this.gameObject.SetActive(false);
	}

	public void levelComplete() {
		Title.text = LEVEL_COMPLETE;
		computeStars();
	}
	public void timeUp() {
		Title.text = TIME_UP;
		computeStars();
	}
	public void gameOver() {
		Title.text = GAME_OVER;
		computeStars();
	}
	public void computeStars() {
		int numStars = MainUIController.currentLevel.computeStars();
		for (int j = 0; j < 5; j++) {
			Stars[j].SetActive(false);
		}
		for (int i = 0; i < numStars; i++) {
			Stars[i].SetActive(true);
		}
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
