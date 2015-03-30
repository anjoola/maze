using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelUIController : MonoBehaviour {
	public static LevelUIController instance;

	public Text Timer;
	public Text Score;
	public GameObject MenuButton;

	public bool TimerEnabled;
	public int TimeLeft;

	void Awake() {
		instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	void Start() {
		TimerEnabled = false;
		InvokeRepeating("UpdateTimer", 0, 1.0f);
	}

	public void Enable(bool enabled) {
		this.gameObject.SetActive(enabled);

		if (!enabled) {
			StopTimer();
		}
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
		UpdateTimeLeft(time);
	}
	public void PauseTimer() {
		TimerEnabled = false;
	}
	public void ResumeTimer() {
		TimerEnabled = true;
	}
	public void StopTimer() {
		TimerEnabled = false;
	}
	private void UpdateTimer() {
		if (TimerEnabled /*&& LevelUI.activeSelf && !showNotePaused*/) {
			UpdateTimeLeft(--TimeLeft);

			// Timer up!
			if (TimeLeft == 0) {
				StopTimer();
				//timeUpPaused = true;

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
		//PauseMenuController.pauseLevel();
	}
	public void EnableMenuButton(bool enabled) {
		MenuButton.SetActive(enabled);
	}
}
