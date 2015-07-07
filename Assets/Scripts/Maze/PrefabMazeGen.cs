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
	static Quaternion NULL_ROTATION = new Quaternion(-1, -1, -1, -1);

	// Size of one side of the maze. (e.g. an 11 x 11 maze would have Size = 11).
	public int Size;
	public GameObject[] MazeBlocks;

	void Start() {
		Gen = new PrefabMazeGenerator(MazeBlocks, Size);
		Gen.GenerateMaze();
		Gen.ComputeEmptyCells();
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
			for (int row = 1; row < size - 1; row++) {
				for (int col = 1; col < size - 1; col++) {
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
			SpawnObject spawnObj = obj.GetComponent<SpawnObject>();

			// Shuffle the empty cells.
			IEnumerable<EmptyCell> shuffled = EmptySpaces.OrderBy(item => UnityEngine.Random.value);
			foreach (EmptyCell cell in shuffled) {
				Quaternion rotation = SpaceFits(cell, spawnObj);

				// Space fits. Instantiate object at this location.
				if (rotation != NULL_ROTATION) {
					obj.transform.position = cell.Coordinates;
					//obj.transform.rotation = TODO
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
		private Quaternion SpaceFits(EmptyCell cell, SpawnObject obj) {
			// TODO
			return DEFAULT_ROTATION;
		}






		/**
		 * Compute properties for each empty cell in the maze (used for getting enemy spawn locations).
		 */
		public void ComputeEmptyCells() {
			int row = 1;
			int col = 1;
			while (true) {
				EmptyCell cell = EmptySpaces[row * Size + col];
				if (cell != null) {
					
					
					
					
					int nextCol = row + 1;
					int numSpaces = 1;
					while (nextCol < Size - 1) {
						EmptyCell nextCell = EmptySpaces[row * Size + nextCol];
						if (nextCell != null) {
							numSpaces++;
							nextCol++;
						}
						
						else
							break;
					}
					
					//Debug.Log ("(" + row + "," + col + "): " + numSpaces);
				}
				
				if (++col > Size - 1) {
					col = 1;
					++row;
				}
				if (row > Size - 1)
					break;
			}
		}
	}
}
