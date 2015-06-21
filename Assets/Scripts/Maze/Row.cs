using System.Collections;

/**
 * A row in the maze.
 */
public class Row {
	public MazeGenerator Gen;
	public Cell[] Cells;
	public int RowNumber;
	
	public Row(MazeGenerator gen, int size, int rowNumber, bool allWalls=false) {
		Gen = gen;
		Cells = new Cell[size];
		RowNumber = rowNumber;
		for (int col = 0; col < size; col++) {
			Cells[col] = new Cell(gen, col % 2 == 0, rowNumber * size + col);
			// If this is a row of all walls, change the cells in that row accordingly. We no longer need to the
			// set numbers for the cells in this row.
			if (allWalls) {
				Cells[col].ChangeType(true);
				Cells[col].DestroySetNumber();
			}
		}
	}
}
