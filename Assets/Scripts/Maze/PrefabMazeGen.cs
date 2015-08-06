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
	public int Size, MazeCenter;
	public GameObject[] MazeBlocks;

	void Start() {
		MazeCenter = (Size + 1) / 2 - 1;

		Gen = new PrefabMazeGenerator(MazeBlocks, Size);
		Gen.GenerateMaze();
		Gen.DoCleanup();
	}

	/**
	 * Destroys all enemies within "blocks" away from a position.
	 * 
	 * position: Central position from which to destroy.
	 * blocks: Number of blocks in each direction to destroy.
	 */
	public void DestroyEnemiesWithin(Vector3 position, int blocks) {
		EmptyCell cell = Vector3ToCell(position);
		for (int r = Mathf.Max(0, cell.Row - blocks); r < Mathf.Min(Size, cell.Row + blocks); r++) {
			for (int c = Mathf.Max(0, cell.Col - blocks); c < Mathf.Min(Size, cell.Col + blocks); c++) {
				GameObject obj = MazeBlocks[r * Size + c];

				// Destroy if this is an enemy.
				if (obj != null && obj.GetComponentInChildren<SpawnObject>() is BaseEnemy) {
					MazeBlocks[r * Size + c] = null;
					obj.GetComponentInChildren<BaseEnemy>().DestroySelf();
				}
			}
		}
	}

	/**
	 * Converts a world-space position to a coordinate in the maze.
	 */
	private EmptyCell Vector3ToCell(Vector3 position) {
		int row = (int) Mathf.Floor(position.z / EmptyCell.MAZE_BLOCK_SIZE + MazeCenter) + 1;
		int col = (int) Mathf.Floor(position.x / EmptyCell.MAZE_BLOCK_SIZE + MazeCenter) + 1;
		return new EmptyCell(row, col);
	}

	/**
	 * Fit a clone into the maze.
	 */
	public void FitClone(String clone) {
		EmptyCell spawnCell = new EmptyCell(Size, 1, 1);
		Vector3 position = spawnCell.Coordinates;
		Instantiate(Resources.Load(clone) as GameObject, position, DEFAULT_ROTATION);
	}

	/**
	 * Try to fit the spawn object with the given prefab name. If it can not be spawned, destroy it.
	 */
	public void FitSpawnObject(String prefab) {
		GameObject obj = InstantiateGameObject(prefab);
		EmptyCell cell = Gen.FitSpawnObject(obj);
		if (cell == null)
			Destroy(obj);

		// Otherwise, store a reference to the object instantiated here.
		else
			MazeBlocks[cell.Row * Size + cell.Col] = obj;
	}

	/**
	 * Destroys all maze blocks (except the boundary).
	 */
	public void MakeMazeInvisible() {
		for (int r = 1; r < Size - 1; r++) {
			for (int c = 1; c < Size - 1; c++) {
				GameObject obj = MazeBlocks[r * Size + c];
				
				// Destroy if this is a maze block.
				if (obj != null && obj.GetComponentInChildren<SpawnObject>() == null) {
					MazeBlocks[r * Size + c] = null;
					Destroy(obj);
				}
			}
		}
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
				Destroy(this.MazeBlocks[row * Size + col]);
				this.MazeBlocks[row * Size + col] = null;
				
				// Add it to the list of empty spaces.
				EmptySpaces[row * Size + col] = new EmptyCell(Size, row, col);
			}
		}

		/**
		 * Cleanup the maze by removing empty cells where the player and the goal reside and 2 spaces away.
		 */
		public void DoCleanup() {
			// Remove from the player start location.
			EmptySpaces[1 * Size + 1] = null;
			if (EmptySpaces[1 * Size + 2] != null) {
				EmptySpaces[1 * Size + 2] = null;
				EmptySpaces[1 * Size + 3] = null;
			}
			if (EmptySpaces[2 * Size + 1] != null) {
				EmptySpaces[2 * Size + 1] = null;
				EmptySpaces[3 * Size + 1] = null;
			}

			// Remove from the goal area.
			EmptySpaces[(Size - 2) * Size + (Size - 2)] = null;
			if (EmptySpaces[(Size - 2) * Size + (Size - 2) - 1] != null) {
				EmptySpaces[(Size - 2) * Size + (Size - 2) - 1] = null;
				EmptySpaces[(Size - 2) * Size + (Size - 2) - 2] = null;
			}
			if (EmptySpaces[(Size - 3) * Size + (Size - 2)] != null) {
				EmptySpaces[(Size - 3) * Size + (Size - 2)] = null;
				EmptySpaces[(Size - 4) * Size + (Size - 2)] = null;
			}
		}
		
		/**
		 * Try to fit in a SpawnObject into an empty space into the maze. Returns the spot if a spot is found.
		 */
		public EmptyCell FitSpawnObject(GameObject obj) {
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
					spawnObj.Rotation = rotation;

					// Remove it from the list of empty cells and removing neighboring cells.
					EmptyCell spot = EmptySpaces[cell.Row * Size + cell.Col];
					EmptySpaces[cell.Row * Size + cell.Col] = null;
					RemoveNeighbors(cell.Row, cell.Col, spawnObj, rotation);
					return spot;
				}
			}

			// Could not find a spot that fits.
			return null;
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
					return EmptyCellOpenDirectionVector.GetRotationForDirection(dir);
			}

			// No direction will work.
			return NULL_ROTATION;
		}

		/**
		 * Converts a relative direction to an absolute direction based on the current rotation.
		 * 
		 * dir: The relative direction.
		 * rotate: The current rotation.
		 */
		private EmptyCellOpenDirection RelativeToAbsoluteDirection(ClearDirection dir, Vector3 rotation) {
			int offset = (int) dir + (int) EmptyCellOpenDirectionVector.GetDirectionForRotation(rotation);
			return EmptyCell.EMPTY_DIRECTIONS[offset % 4];
		}

		/**
		 * Removes neighboring empty spaces according to the rules defined by the SpawnObject.
		 * 
		 * row: Row where the object was spawned.
		 * col: Column where the object was spawned.
		 * obj: The spawned object.
		 * rotation: Resulting rotation the object spawned in.
		 */
		private void RemoveNeighbors(int row, int col, SpawnObject obj, Vector3 rotation) {
			foreach (ClearRequirement req in obj.ClearRequirements) {
				EmptyCellOpenDirection dir = RelativeToAbsoluteDirection(req.Direction, rotation);

				if (dir == EmptyCellOpenDirection.ABOVE) {
					for (int r = row + 1; r <= Math.Min(row + req.Amount, Size - 1); r++) {
						EmptySpaces[r * Size + col] = null;
					}
				}
				else if (dir == EmptyCellOpenDirection.RIGHT) {
					for (int c = col + 1; c <= Math.Min(col + req.Amount, Size - 1); c++) {
						EmptySpaces[row * Size + c] = null;
					}
				}
				else if (dir == EmptyCellOpenDirection.BELOW) {
					for (int r = row - 1; r >= Math.Max(row - req.Amount, 0); r--) {
						EmptySpaces[r * Size + col] = null;
					}
				}
				else {
					for (int c = col - 1; c >= Math.Max(col - req.Amount, 0); c--) {
						EmptySpaces[row * Size + c] = null;
					}
				}
			}
		}
	}
}
