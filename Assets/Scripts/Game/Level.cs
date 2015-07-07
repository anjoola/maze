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

	// The maze generator. Used to get positions for spawning objects.
	private PrefabMazeGen MazeGen;

	// The floors for each level. Contains details about its size, enemies that appear, etc.
	public abstract Floor[] Floors { get; }

	public Level() {
		IsCompleted = false;
		NumFloors = 0;
	}

	/**
	 * Starts this level. Loads the first floor.
	 */
	public void Start() {
		CurrentFloor = 1;
		Floor firstFloor = this.Floors[0];
		AutoFade.LoadLevel(firstFloor.Scene, 0.2f, 0.2f, Color.black, StartDone, firstFloor);
	}
	private void StartDone(Floor floor) {
		MainController.CurrentLevel = this;
		MainController.CurrentFloor = 1;
		MainController.ShowLevelUI();

		MazeGen = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<PrefabMazeGen>();
		SpawnGameObjects(floor);
	}

	/**
	 * Finish the level. Show the level complete UI and TODO
	 */
	public void Finish() {
		IsCompleted = true;
		MainController.ShowLevelComplete(10000); // TODO fake amount
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
		Floor next = Floors[++CurrentFloor - 1];
		AutoFade.LoadLevel(next.Scene, 0.2f, 0.2f, Color.black, SpawnGameObjects, next);
	}

	/**
	 * Spawn enemies, items, and treasures accordingly.
	 * 
	 * floor: Floor object containing details for spawning.
	 */
	private void SpawnGameObjects(Floor floor) {
		// Spawn enemies.
		foreach (string enemy in floor.Enemies) {
			MazeGen.FitSpawnObject("Enemy/" + enemy);
		}

		// Spawn items.
		// TODO

		// Spawn treasures.
		foreach (string treasure in floor.Treasures) {
			MazeGen.FitSpawnObject("Treasure/" + treasure);
		}

		MainController.ShowFloorNumber();
	}
}
