using UnityEngine;
using System.Collections;

public class WorldMapController : MonoBehaviour {
	float X_START = -155.28f;
	float Y_START = 8.5f;
	float X_INTERVAL = 66.5f;
	float Y_INTERVAL = 28f;

	// Currently selected level.
	int SelectedLevel;

	public GameObject player;
	Vector3 PlayerStartPos;

	void Start() {
		SelectedLevel = 1;
		PlayerStartPos = player.transform.position;
	}
	void Update() {
		PlayerStartPos = player.transform.position;
		Vector3 playerPos = player.transform.position;
		bool moved = true;

		// TODO allow for starting at any marker


		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && playerPos.y == Y_START) {
			playerPos.x += X_INTERVAL;
			SelectedLevel++;
		}
		else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && playerPos.y == Y_START) {
			playerPos.x -= X_INTERVAL;
			SelectedLevel--;
		}
		else if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) &&
		         playerPos.x == X_START + 2 * X_INTERVAL) {
			playerPos.y += Y_INTERVAL;
			SelectedLevel = 6;
		}
		else if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) &&
		         playerPos.x == X_START + 2 * X_INTERVAL) {
			playerPos.y -= Y_INTERVAL;
			SelectedLevel = 3;
		}
		else {
			moved = false;
		}
	
		// Cap.
		if (moved) {
			playerPos.x = Mathf.Max(Mathf.Min(X_START + 4 * X_INTERVAL, playerPos.x), X_START);
			playerPos.y = Mathf.Max(Mathf.Min(Y_START + Y_INTERVAL, playerPos.y), Y_START);
		}

		player.transform.position = playerPos;
		// TODO smoother movement
		//player.transform.position = Vector3.Lerp(PlayerStartPos, playerPos, 10f * Time.deltaTime);
	}

	/**
	 * Starts the selected level.
	 */
	public void StartLevel() {
		// TODO
		Debug.Log("TODO starting level " + SelectedLevel);
		AutoFade.LoadLevel("TestLevel", 0.2f, 0.2f, Color.black);
	}
}
