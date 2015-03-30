using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Handles the timer, score, and showing of the menu if the user clicks on the menu button.
public class LevelUIController : MonoBehaviour {
	public static LevelUIController instance;

	public Text Timer;
	public Text Score;
	public GameObject MenuButton;

	public bool TimerEnabled;
	public bool TimerPaused;
	public int TimeLeft;

	void Awake() {
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		TimerEnabled = false;
		InvokeRepeating("UpdateTimer", 0, 1.0f);
	}

	public void Disable() {
		this.gameObject.SetActive(false);
		StopTimer();
	}
	public void EnableWithTime(int time) {
		Enable();
		EnableMenuButton();
		StartTimer(time);
	}
	public void Enable() {
		this.gameObject.SetActive(true);
	}
	
	public void AddPoints(int points) {
		//currentLevel.incrementscore(score);
		//UpdateScore(currentLevel.score);
	}
	public void ResetScore() {
		//currentLevel.score = 0;
		UpdateScore(0);
	}
	public void UpdateScore(int score) {
		Score.text = score.ToString();
	}

	public void StartTimer(int time) {
		TimeLeft = time;
		TimerEnabled = true;
		TimerPaused = false;
		UpdateTimeLeft(time);
	}
	public void PauseTimer() {
		TimerPaused = true;
	}
	public void ResumeTimer() {
		TimerPaused = false;
	}
	public void StopTimer() {
		TimerEnabled = false;
		TimerPaused = true;
	}
	private void UpdateTimer() {
		if (TimerEnabled && ! TimerPaused && !MainUIController.ShouldPause()) {
			UpdateTimeLeft(--TimeLeft);

			// Timer up!
			if (TimeLeft == 0) {
				StopTimer();

				//finishLevel(CompletionType.TimeUp);
			}

			// 3 2 1 countdown.
			/*if (currTime <= 3) {
				AudioController.timerBeep();
			}*/
		}
	}
	private void UpdateTimeLeft(int time) {
		Timer.text = time.ToString().PadLeft(5, '0');
	}

	// Shows the menu if the menu button is clicked.
	public void ShowMenu() {
		PauseMenuController.instance.ShowPauseMenu();
	}
	public void DisableMenuButton() {
		MenuButton.SetActive(false);
	}
	public void EnableMenuButton() {
		MenuButton.SetActive(true);
	}
}
