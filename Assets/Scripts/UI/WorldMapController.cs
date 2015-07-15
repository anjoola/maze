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
	Vector3 PlayerStartPos;
	
	void Start() {
		// Selected level.
		SelectedLevel = MainController.SelectedLevel;
		LevelName.text = MainController.CurrentGame.Levels[SelectedLevel - 1].LevelName;

		// Start at the last location.
		PlayerStartPos = player.transform.position; // TODO
		Vector3 tempPos = player.transform.position;
		if (SelectedLevel == 6) {
			tempPos.y += Y_INTERVAL;
			tempPos.x += 2 * X_INTERVAL;
		}
		else {	
			tempPos.x += (SelectedLevel - 1) * X_INTERVAL;
		}
		player.transform.position = tempPos;
	}
	void Update() {
		PlayerStartPos = player.transform.position;
		Vector3 playerPos = PlayerStartPos;

		// TODO allow for starting at any marker based on the game save

		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) &&
		    playerPos.y == Y_START && playerPos.x < X_START + 4 * X_INTERVAL) {
			playerPos.x += X_INTERVAL;
			SelectedLevel++;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) &&
		         playerPos.y == Y_START && playerPos.x > X_START) {
			playerPos.x -= X_INTERVAL;
			SelectedLevel--;
		}
		else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) &&
		         playerPos.x == X_START + 2 * X_INTERVAL && playerPos.y < Y_START + Y_INTERVAL) {
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
	
		LevelName.text = MainController.CurrentGame.Levels[SelectedLevel - 1].LevelName;
		player.transform.position = playerPos;
		MainController.SelectedLevel = SelectedLevel;
		// TODO smoother movement
		//player.transform.position = Vector3.Lerp(PlayerStartPos, playerPos, 10f * Time.deltaTime);
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
