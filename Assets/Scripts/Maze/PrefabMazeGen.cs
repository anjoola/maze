using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/**
 * Generates a maze using Prefabs. Need to add all the potential maze blocks to the MazeBlocks list and set the Size.
 * The MazeBlocks list size must be Size x Size, where Size is an odd number.
 */
public class PrefabMazeGen : MonoBehaviour {
	PrefabMazeGenerator Gen;
	static Vector3 DEFAULT_POSITION = new Vector3(0, 0, 0);
	static Quaternion DEFAULT_ROTATION = new Quaternion(0, 0, 0, 0);
	static Vector3 NULL_ROTATION = new Vector3(-1, -1, -1);

	// Size of one side of the maze. (e.g. an 11 x 11 maze would have Size = 11).
	public int Size;
	public GameObject[] MazeBlocks;

	void Start() {
		Gen = new PrefabMazeGenerator(MazeBlocks, Size);
		Gen.GenerateMaze();
	}

	/**
	 * Try to fit the spawn object with the given prefab name. If it can not be spawned, destroy it.
	 */
	public void FitSpawnObject(String prefab) {
		GameObject obj = InstantiateGameObject(prefab);
		if (!Gen.FitSpawnObject(obj))
			Destroy(obj);
	}

	/**
	 * Instantiates a GameObject at the default position and rotation.
	 */
	private GameObject InstantiateGameObject(string prefab) {
		return Instantiate(Resources.Load(prefab) as GameObject, DEFAULT_POSITION, DEFAULT_ROTATION) as GameObject;
	}
	
	public class PrefabMazeGenerator : MazeGenerator {
		public GameObject[] MazeBlocks;
		
		// List of all empty spaces in the maze. An array of coordinates.
		public EmptyCell[] EmptySpaces;
		
		// Maze size must be an odd number.
		public PrefabMazeGenerator(GameObject[] blocks, int size) : base(size) {
			MazeBlocks = blocks;
			
			// Initialize empty cells.
			EmptySpaces = new EmptyCell[size * size];
			for (int row = 1; row < size - 1; row += 2) {
				for (int col = 1; col < size - 1; col += 2) {
					// The first and last cells are where the player the goal are, respectively.
					if ((row == 1 && col == 1) || (row == size - 1 && col == size - 1))
						continue;
					
					EmptySpaces[row * size + col] = new EmptyCell(size, row, col);
				}
			}
		}
		
		override public void CellTypeChangedCallback(int row, int col, bool toWall) {
			// Changed from a wall to an empty space.
			if (!toWall && this.MazeBlocks[row * this.Size + col] != null) {
				this.MazeBlocks[row * Size + col].SetActive(false);
				
				// Add it to the list of empty spaces.
				EmptySpaces[row * Size + col] = new EmptyCell(Size, row, col);
			}
		}
		
		/**
		 * Try to fit in a SpawnObject into an empty space into the maze. Returns true if a spot is found.
		 */
		public bool FitSpawnObject(GameObject obj) {
			SpawnObject spawnObj = obj.GetComponentInChildren<SpawnObject>();

			// Shuffle the empty cells. Randomly pick one to fill.
			IEnumerable<EmptyCell> shuffled = EmptySpaces.OrderBy(item => UnityEngine.Random.value)
														 .Where(item => item != null);
			foreach (EmptyCell cell in shuffled) {
				Vector3 rotation = SpaceFits(cell, spawnObj);

				// Space fits. Instantiate object at this location and set it to the correct position and rotation.
				if (rotation != NULL_ROTATION) {
					obj.transform.position = cell.Coordinates;
					obj.transform.Rotate(rotation);

					// Remove it from the list of empty cells.
					EmptySpaces[cell.Row * Size + cell.Col] = null;
					return true;
				}
			}

			// Could not find a spot that fits.
			return false;
		}
		
		/**
		 * Returns whether or not a given empty cell fits the SpawnObject criteria. If so, returns a rotation that
		 * would work. Otherwise, returns null.
		 * 
		 * cell: The empty cell.
		 * obj: The SpawnObject.
		 */
		private Vector3 SpaceFits(EmptyCell cell, SpawnObject obj) {
			// Randomly go through each direction.
			IEnumerable<EmptyCellOpenDirection> directions =
				EmptyCell.EMPTY_DIRECTIONS.OrderBy(item => UnityEngine.Random.value);

			foreach (EmptyCellOpenDirection dir in directions) {
				// Property not set yet, figure it out and set it.
				if (cell.GetNumEmpty(dir) == -1) {
					int numEmpty = cell.NumEmptyInDirection(dir, EmptySpaces);
					cell.SetNumEmpty(dir, numEmpty);
				}
				
				// Does this match the criteria? If so, return the correction rotation.
				if (cell.GetNumEmpty(dir) >= obj.SpaceNeeded)
					return EmptyCell.GetRotationForDirection(dir);
			}

			// No direction will work.
			return NULL_ROTATION;
		}
	}
}
