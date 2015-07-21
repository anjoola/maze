using UnityEngine;
using System;
using System.Collections;

/**
 * Represents a single level in the game.
 */
[System.Serializable]
public abstract class Level {
	// Whether or not the level has been completed.
	public bool IsCompleted;

	// The current floor in the maze.
	public int CurrentFloor;

	// Total number of floors in the maze.
	public int NumFloors;

	// Number of clones spawned.
	public int NumClones;

	// The maze generator. Used to get positions for spawning objects.
	private PrefabMazeGen MazeGen;

	// The floors for each level. Contains details about its size, enemies that appear, etc.
	public abstract Floor[] Floors { get; }

	// Name of this level.
	public abstract string LevelName { get; }

	public Level() {
		IsCompleted = false;
		NumFloors = 0;
	}

	/**
	 * Starts this level. Loads the first floor.
	 */
	public void Start() {
		NumClones = 0;
		CurrentFloor = 1;

		Floor firstFloor = this.Floors[0];
		MainController.HideLevelUI();
		MainController.CurrentLevel = this;
		MainController.ResetLocations();
		AutoFade.LoadLevel(firstFloor.Scene, 0.2f, 0.2f, Color.black, StartDone, firstFloor);
		MainController.ChangeLevelName(LevelName);
		MainController.NewLevel();
	}
	private void StartDone(Floor floor) {
		MainController.CurrentFloor = 1;
		MainController.ShowLevelUI();

		SpawnGameObjects(floor);
	}

	/**
	 * Finish the level. Show the level complete UI and the amount of treasure acquired in this level.
	 */
	public void Finish() {
		IsCompleted = true;
		MainController.ShowLevelComplete(LevelUIController.TreasureAcquired);
	}

	/**
	 * Get the next floor, load the scene, and apply the floor-specific properties. If this is the last floor, then
	 * instead show the level completion UI.
	 */
	public void GetNextFloor() {
		// Already finished.
		if (CurrentFloor == NumFloors) {
			Finish();
			return;
		}

		// Get the next floor and load it.
		NumClones = 0;
		Floor next = Floors[++CurrentFloor - 1];
		AutoFade.LoadLevel(next.Scene, 0.2f, 0.2f, Color.black, SpawnGameObjects, next);
	}

	/**
	 * Spawn enemies, items, and treasures accordingly.
	 * 
	 * floor: Floor object containing details for spawning.
	 */
	private void SpawnGameObjects(Floor floor) {
		MazeGen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PrefabMazeGen>();
		MainController.MazeGen = MazeGen;

		// Go through each array in round-robin so it's more fair.
		for (int i = 0; i < Mathf.Max(floor.Enemies.Length, floor.Items.Length, floor.Treasures.Length); i++) {
			if (i < floor.Enemies.Length)		
				MazeGen.FitSpawnObject("Enemy/" + floor.Enemies[i]);
			if (i < floor.Items.Length)		
				MazeGen.FitSpawnObject("Item/" + floor.Items[i]);
			if (i < floor.Treasures.Length)		
				MazeGen.FitSpawnObject("Treasure/" + floor.Treasures[i]);
		}
		MainController.ShowFloorNumber();
	}

	/**
	 * Whether or not a new clone should be spanwed. Depends on the current number of clones already spawned.
	 */
	public bool ShouldSpawnClone() {
		return NumClones < Floors[CurrentFloor - 1].NumClones;
	}

	/**
	 * Spawn a clone.
	 */
	public void SpawnClone() {
		NumClones++;
		MazeGen.FitClone("Main/Clone");
	}
}
