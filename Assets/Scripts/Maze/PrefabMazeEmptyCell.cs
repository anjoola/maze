using System;
using UnityEngine;

/**
 * Represents an empty cell in the maze. Used for spawning GameObjects such as enemies.
 */
public class EmptyCell {
	// Possible empty directions.
	public static EmptyCellOpenDirection[] EMPTY_DIRECTIONS = {
		EmptyCellOpenDirection.LEFT,
		EmptyCellOpenDirection.RIGHT,
		EmptyCellOpenDirection.ABOVE,
		EmptyCellOpenDirection.BELOW
	};

	// Size of a maze block.
	static int MAZE_BLOCK_SIZE = 500;

	// Coordinates for this empty cell.
	public int Size, Row, Col;
	public Vector3 Coordinates;

	// Mapping from direction -> number of empty cells. This represents the number of free spaces in that direction.
	int[] NumEmpty;

	public EmptyCell(int size, int row, int col) {
		int MazeCenter = (size + 1) / 2 - 1;
		Row = row;
		Col = col;
		Size = size;
		Coordinates = new Vector3((col - MazeCenter) * MAZE_BLOCK_SIZE, 0, (row - MazeCenter) * MAZE_BLOCK_SIZE);

		NumEmpty = new int[] { -1, -1, -1, -1 };

		// If this is an edge cell, set values we already know.
		if (row == 1)
			SetNumEmpty(EmptyCellOpenDirection.BELOW, 0);
		if (col == 1)
			SetNumEmpty(EmptyCellOpenDirection.LEFT, 0);
		if (row == size - 1)
			SetNumEmpty(EmptyCellOpenDirection.ABOVE, 0);
		if (col == size - 1)
			SetNumEmpty(EmptyCellOpenDirection.RIGHT, 0);
	}

	/**
	 * Get the number of empty cells in a given direction.
	 * 
	 * direction: The direction to get.
	 * returns: The number of empty cells.
	 */
	public int GetNumEmpty(EmptyCellOpenDirection direction) {
		return NumEmpty[(int) direction];
	}

	/**
	 * Set the number of empty cells in a given direction.
	 * 
	 * direction: Direction of emptiness.
	 * num: The number of cells it is empty for.
	 */
	public void SetNumEmpty(EmptyCellOpenDirection direction, int num) {
		NumEmpty[(int) direction] = num;
	}

	/**
	 * Get the number of empty cells in the given direction.
	 * 
	 * dir: The direction.
	 * cells: Reference to all of the empty cells in the maze.
	 */
	public int NumEmptyInDirection(EmptyCellOpenDirection dir, EmptyCell[] cells) {
		int num = 0;

		if (dir == EmptyCellOpenDirection.LEFT) {
			for (int c = Col - 1; c >= 0; c--) {
				if (cells[Row * Size + c] != null)
					num++;
				else
					break;
			}
		}
		else if (dir == EmptyCellOpenDirection.RIGHT) {
			for (int c = Col + 1; c < Size; c++) {
				if (cells[Row * Size + c] != null)
					num++;
				else
					break;
			}
		}
		else if (dir == EmptyCellOpenDirection.ABOVE) {
			for (int r = Row + 1; r < Size; r++) {
				if (cells[r * Size + Col] != null)
					num++;
				else
					break;
			}
		}
		else if (dir == EmptyCellOpenDirection.BELOW) {
			for (int r = Row - 1; r >= 0; r--) {
				if (cells[r * Size + Col] != null)
					num++;
				else
					break;
			}
		}

		return num;
	}

	/**
	 * Get the rotation corresponding to the direction.
	 */
	public static Vector3 GetRotationForDirection(EmptyCellOpenDirection dir) {
		if (dir == EmptyCellOpenDirection.LEFT)
			return new Vector3(0, -90, 0);
		else if (dir == EmptyCellOpenDirection.RIGHT)
			return new Vector3(0, 90, 0);
		// All prefabs should default to facing above.
		else if (dir == EmptyCellOpenDirection.ABOVE)
			return new Vector3(0, 0, 0);
		else
			return new Vector3(0, 180, 0);
	}
}

/**
 * Direction of emptiness, relative to the current maze block.
 */
public enum EmptyCellOpenDirection : int {
	LEFT = 0, RIGHT = 1, ABOVE = 2, BELOW = 3
};
