using UnityEngine;

/**
 * TODO
 */
[System.Serializable]
public abstract class Level {
	// Whether or not the level has been completed.
	public bool IsCompleted;

	// The current floor in the maze.
	public int CurrentFloor;

	// Total number of floors in the maze.
	public int NumFloors;

	// The floors for each level. Contains details about its size, enemies that appear, etc.
	public abstract Floor[] Floors { get; }

	public Level() {
		IsCompleted = false;
		NumFloors = 0;
		CurrentFloor = 1;
	}

	/**
	 * Starts this level. Loads the first floor.
	 */
	public void Start() {
		Floor firstFloor = this.Floors[0];
		AutoFade.LoadLevel(firstFloor.Scene, 0.2f, 0.2f, Color.black, GetNextFloorCallback, firstFloor);

		MainController.CurrentLevel = this;
		MainController.ShowLevelUI();
		// TODO other things?
	}

	/**
	 * Finish the level. Show the level complete UI and TODO
	 */
	public void Finish() {
		IsCompleted = true;
		
		// TODO show level complete UI
	}

	/**
	 * Get the next floor, load the scene, and apply the floor-specific properties. If this is the last floor, then
	 * instead show the level completion UI.
	 */
	public void GetNextFloor() {
		// Already finished.
		if (CurrentFloor++ == NumFloors)
			Finish();

		// Get the next floor and load it.
		Floor next = Floors[CurrentFloor - 1];
		AutoFade.LoadLevel(next.Scene, 0.2f, 0.2f, Color.black, GetNextFloorCallback, next);
	}

	/**
	 * Apply floor-specific modifiers.
	 * 
	 * floor: Properties for this floor.
	 */
	private void GetNextFloorCallback(Floor floor) {
		// Spawn enemies.
		foreach (string enemy in floor.Enemies) {
			// TODO need to instantiate
		}

		MainController.ShowFloorNumber();
	}
}
