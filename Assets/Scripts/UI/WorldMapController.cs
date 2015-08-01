using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WorldMapController : MonoBehaviour {
	float X_START = -155.28f;
	float Y_START = 8.5f;
	float X_INTERVAL = 66.5f;
	float Y_INTERVAL = 28f;

	// Currently selected level.
	int SelectedLevel;

	public GameObject player;
	public Text LevelName;
	public Text TreasureCount;
	Vector3 GoalPos;

	public GameObject[] LevelMarkers;
	public GameObject[] LevelLines;
	
	void Start() {
		// Selected level.
		SelectedLevel = MainController.SelectedLevel;
		LevelName.text = MainController.CurrentGame.Levels[SelectedLevel - 1].LevelName;

		// Start at the last location.
		Vector3 tempPos = player.transform.position;
		if (SelectedLevel == 6) {
			tempPos.y += Y_INTERVAL;
			tempPos.x += 2 * X_INTERVAL;
		}
		else {	
			tempPos.x += (SelectedLevel - 1) * X_INTERVAL;
		}
		player.transform.position = tempPos;
		GoalPos = tempPos;

		// Show level markers of available levels.
		for (int level = 0; level <= MainController.PrevHighestAvailableLevel; level++) {
			LevelMarkers[level].SetActive(true);
			if (level > 0) {
				LevelLines[level].SetActive(true);
				iTween.ScaleBy(LevelLines[level], iTween.Hash("x", 40.0f, "time", 0));
			}
		}
		// Animate the appearance of a new level.
		if (MainController.PrevHighestAvailableLevel != MainController.HighestAvailableLevel) {
			GameObject marker = LevelMarkers[MainController.HighestAvailableLevel];
			marker.SetActive(true);
			iTween.ScaleBy(marker, iTween.Hash("x", 1.2f, "y", 1.2f, "time", 0.8f));
			iTween.ScaleBy(marker, iTween.Hash("x", 1/1.2f, "y", 1/1.2f, "time", 1, "delay", 0.7f));
			GameObject line = LevelLines[MainController.HighestAvailableLevel];
			line.SetActive(true);
			iTween.ScaleBy(line, iTween.Hash("x", 40.0f, "time", 1.5f));

			MainController.PrevHighestAvailableLevel = MainController.HighestAvailableLevel;
		}

		TreasureCount.text = ("" + MainController.LevelUICtrl.TreasureAmt).PadLeft(7, '0');

		// No longer a new game.
		MainController.CurrentGame.IsNewGame = false;
	}
	void Update() {
		Vector3 playerPos = GoalPos;

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) &&
		    playerPos.y == Y_START && playerPos.x < X_START + 4 * X_INTERVAL &&
		    SelectedLevel <= MainController.HighestAvailableLevel) {
			playerPos.x += X_INTERVAL;
			SelectedLevel++;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) &&
		         playerPos.y == Y_START && playerPos.x > X_START) {
			playerPos.x -= X_INTERVAL;
			SelectedLevel--;
		}
		else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) &&
		         playerPos.x == X_START + 2 * X_INTERVAL && playerPos.y < Y_START + Y_INTERVAL &&
		         MainController.HighestAvailableLevel == 5) {
			playerPos.y += Y_INTERVAL;
			SelectedLevel = 6;
		}
		else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) &&
		         playerPos.x == X_START + 2 * X_INTERVAL && playerPos.y > Y_START) {
			playerPos.y -= Y_INTERVAL;
			SelectedLevel = 3;
		}
		else if (Input.GetKeyDown(KeyCode.Return)) {
			StartLevel();
		}
	
		GoalPos = playerPos;
		MainController.SelectedLevel = SelectedLevel;
	}

	void FixedUpdate() {
		// Smoother movement of the character.
		player.transform.position = Vector3.Lerp(player.transform.position, GoalPos, Time.fixedDeltaTime * 10.0f);
		if (Mathf.Abs(GoalPos.x - player.transform.position.x) <= 15 &&
		    Mathf.Abs(GoalPos.y - player.transform.position.y) <= 15) {
			LevelName.text = MainController.CurrentGame.Levels[SelectedLevel - 1].LevelName;
		}
	}

	/**
	 * Starts the selected level.
	 */
	public void StartLevel() {
		Level level = MainController.CurrentGame.Levels[SelectedLevel - 1];
		MainController.CurrentLevelNumber = SelectedLevel;
		level.Start();
	}
}
