using System;
using System.Collections;
using UnityEngine;

/**
 * Generates a maze using Prefabs. Need to add all the potential maze blocks to the MazeBlocks list and set the Size.
 * The MazeBlocks list size must be Size x Size, where Size is an odd number.
 */
public class PrefabMazeGen : MonoBehaviour {
	PrefabMazeGenerator Gen;

	// Size of one side of the maze. (e.g. an 11 x 11 maze would have Size = 11).
	public int Size;
	public GameObject[] MazeBlocks;
	
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

				Debug.Log ("(" + row + "," + col + "): " + numSpaces);
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

	void Start() {
		Gen = new PrefabMazeGenerator(MazeBlocks, Size);
		Gen.GenerateMaze();
		Gen.ComputeEmptyCells();
	}
}
