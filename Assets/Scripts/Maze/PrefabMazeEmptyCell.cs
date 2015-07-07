using System;
using UnityEngine;

/**
 * Represents an empty cell in the maze. Used for enemy spawning.
 */
public class EmptyCell {
	// Size of a maze block.
	int MAZE_BLOCK_SIZE = 1000;
	
	int MazeCenter;
	public Vector3 Coordinates;

	// Properties of this cell. Mapping from direction -> magnitude. This represents the number of free spaces in that
	// direction.
	int[] Properties;
	public int NumPropertiesSet;
	
	public EmptyCell(int size, int row, int col) {
		MazeCenter = size / 2 + 1;
		Coordinates = new Vector3((col - MazeCenter) * MAZE_BLOCK_SIZE, 0, (row - MazeCenter) * MAZE_BLOCK_SIZE);

		Properties = new int[4];
		NumPropertiesSet = 0;

		// If this is an edge cell, set properties we already know.
		if (row == 1)
			SetProperty(EmptyCellOpenDirection.BELOW, 0);
		if (col == 1)
			SetProperty(EmptyCellOpenDirection.LEFT, 0);
		if (row == size - 1)
			SetProperty(EmptyCellOpenDirection.ABOVE, 0);
		if (col == size - 1)
			SetProperty(EmptyCellOpenDirection.RIGHT, 0);
	}

	/**
	 * Set a property of the cell. Indicates in which directions it is empty.
	 * 
	 * direction: Direction of emptiness.
	 * magnitude: The number of cells it is empty for.
	 */
	public void SetProperty(EmptyCellOpenDirection direction, int magnitude) {
		Properties[(int) direction] = magnitude;
		NumPropertiesSet++;
	}
}

/**
 * Direction of emptiness, relative to the current maze block.
 */
public enum EmptyCellOpenDirection : int {
	LEFT = 0, RIGHT, ABOVE, BELOW, ANY
};
