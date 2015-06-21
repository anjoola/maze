using System;
using System.Collections;
using System.Diagnostics;

/**
 * Generates any square-sized maze.
 * 
 * Maze generation algorithm from http://weblog.jamisbuck.org/2010/12/29/maze-generation-eller-s-algorithm.
 */
public class MazeGenerator {
	// Probability of producing a wall.
	public float WALL_PROBABILITY = 0.5f;

	// Mapping of set number of a list of cells with that set number.
	public ArrayList[] SetToCells;
	public Maze CurrentMaze;
	public Random random;
	public int Size;

	public MazeGenerator(int size) {
		// Maze size must be an odd number!
		Debug.Assert(size % 2 == 1, "Size must be an odd number!");
		random = new Random();

		// Initialize mapping of set number to cells. Initially all cells are in their own set.
		SetToCells = new ArrayList[size * size];
		CurrentMaze = new Maze(this, size);
		Size = size;
	}

	public void GenerateMaze() {
		// Loop through pairs of non-full-wall rows.
		for (int i = 0; i < Size - 3; i += 2) {
			Row row, newRow;
			// Create the first row of walls and first real row.
			if (i == 0) {
				CurrentMaze.AddRow(true);
				row = CurrentMaze.AddRow();
				ProcessRow(row);
			}
			row = CurrentMaze.Rows[i + 1];

			// Add the next row of walls and row and create vertical connections.
			CurrentMaze.AddRow(true);
			newRow = CurrentMaze.AddRow();
			CreateVerticalConnections(row, newRow);

			ProcessRow(newRow, i + 3 == Size - 2);
			DeleteRowSets(row);
		}
		CurrentMaze.AddRow(true);
	}
	// Processes a row by randomly joining adjacent cells, only if they are not in the same set.
	public void ProcessRow(Row row, bool isLastRow=false) {
		for (int i = 1; i < Size - 3; i += 2) {
			Cell left = row.Cells[i];
			Cell right = row.Cells[i + 2];

			// Join "adjacent" cells (really, there is a wall between them; we join adjacent empty cells) if they are
			// not in the same set.
			if (!InSameSet(left, right) && (isLastRow || random.NextDouble() < WALL_PROBABILITY)) {
				right.ChangeSetNumber(left.SetNumber);

				// Wall in-between is now gone.
				row.Cells[i + 1].ChangeType(false);
			}
		}
	}
	private bool InSameSet(Cell first, Cell second) {
		return first.SetNumber == second.SetNumber;
	}
	public void CreateVerticalConnections(Row current, Row next) {
		// Go through each set and randomly determine vertical connections.
		for (int i = 0; i < SetToCells.Length; i++) {
			// No cells in this set.
			if (SetToCells[i] == null || SetToCells[i].Count == 0) continue;

			bool removedWall = false;
			ArrayList possibleCells = new ArrayList();
			for (int j = 0; j < SetToCells[i].Count; j++) {
				Cell cell = (Cell)SetToCells[i][j];
				// Only check cells in the current row and cells that were not once walls.
				if (cell.ColNumber % 2 == 1 && cell.RowNumber == current.RowNumber && !cell.IsWall) {
					Cell cellBelow = cell.GetCellBelow();

					// If this is not randomly chosen, move on. Add cell to the list of cells that could be chosen.
					if (random.NextDouble() < 1 - WALL_PROBABILITY) {
						possibleCells.Add(cell);
						continue;
					}

					// Otherwise, merge the sets.
					cellBelow.ChangeSetNumber(cell.SetNumber);

					// Wall in-between is now gone.
					cell.GetWallBelow().ChangeType(false);
					removedWall = true;
				}
			}

			// If no walls removed from this set, randomly pick one to remove (we have to remove one).
			if (!removedWall && possibleCells.Count > 0) {
				Cell cellToMerge = (Cell)possibleCells[random.Next(0, possibleCells.Count)];
				cellToMerge.GetCellBelow().ChangeSetNumber(cellToMerge.SetNumber);
				cellToMerge.GetWallBelow().ChangeType(false);
			}
		}
	}
	// Delete the set information for this row since it's no longer needed.
	public void DeleteRowSets(Row row) {
		for (int i = 0; i < Size; i++) {
			Cell cell = row.Cells[i];
			cell.DestroySetNumber();
		}
	}

	public virtual void CellTypeChangedCallback(int row, int col, bool toWall) { }
	
	static int Main(string[] args) {
		MazeGenerator gen = new MazeGenerator(31);
		gen.GenerateMaze();
		Console.Write(gen.CurrentMaze);
		return 0;
	}
}
