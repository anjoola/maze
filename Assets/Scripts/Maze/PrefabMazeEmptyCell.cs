using System;
using UnityEngine;

/**
 * Represents an empty cell in the maze. Used for spawning GameObjects such as enemies.
 */
public class EmptyCell {
	// Possible empty directions.
	public static EmptyCellOpenDirection[] EMPTY_DIRECTIONS = {
		EmptyCellOpenDirection.ABOVE,
		EmptyCellOpenDirection.LEFT,
		EmptyCellOpenDirection.BELOW,
		EmptyCellOpenDirection.RIGHT
	};

	// Size of a maze block.
	public static int MAZE_BLOCK_SIZE = 500;

	// Coordinates for this empty cell.
	public int Size, Row, Col;
	public Vector3 Coordinates;

	// Mapping from direction -> number of empty cells. This represents the number of free spaces in that direction.
	int[] NumEmpty;

	public EmptyCell(int row, int col) {
		Row = row;
		Col = col;
	}

	public EmptyCell(int size, int row, int col) {
		int MazeCenter = (size + 1) / 2 - 1;
		Row = row;
		Col = col;
		Size = size;
		Coordinates = new Vector3((col - MazeCenter) * MAZE_BLOCK_SIZE, 0, (row - MazeCenter) * MAZE_BLOCK_SIZE);

		NumEmpty = new int[] { -1, -1, -1, -1 };

		// If this is an edge cell, set values we already know.
		if (row == size - 1)
			SetNumEmpty(EmptyCellOpenDirection.ABOVE, 0);
		if (col == 1)
			SetNumEmpty(EmptyCellOpenDirection.LEFT, 0);
		if (row == 1)
			SetNumEmpty(EmptyCellOpenDirection.BELOW, 0);
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
}

/**
 * The vector form of an empty direction.
 */
public class EmptyCellOpenDirectionVector {
	public static Vector3 ABOVE = new Vector3(0, 0, 0);
	public static Vector3 RIGHT = new Vector3(0, 90, 0);
	public static Vector3 BELOW = new Vector3(0, 180, 0);
	public static Vector3 LEFT = new Vector3(0, -90, 0);

	/**
	 * Get the rotation corresponding to the direction.
	 */
	public static Vector3 GetRotationForDirection(EmptyCellOpenDirection dir) {
		// All prefabs should default to facing above.
		if (dir == EmptyCellOpenDirection.ABOVE)
			return ABOVE;
		else if (dir == EmptyCellOpenDirection.RIGHT)
			return RIGHT;
		else if (dir == EmptyCellOpenDirection.BELOW)
			return BELOW;
		else
			return LEFT;
	}

	/**
	 * Get the direction corresponding to the rotation.
	 */
	public static EmptyCellOpenDirection GetDirectionForRotation(Vector3 rotation) {
		if (rotation == ABOVE)
			return EmptyCellOpenDirection.ABOVE;
		else if (rotation == RIGHT)
			return EmptyCellOpenDirection.RIGHT;
		else if (rotation == BELOW)
			return EmptyCellOpenDirection.BELOW;
		else
			return EmptyCellOpenDirection.LEFT;
	}
}

/**
 * Direction of emptiness, relative to the current maze block.
 */
public enum EmptyCellOpenDirection : int {
	ABOVE = 0, RIGHT = 1, BELOW = 2, LEFT = 3
};
