using System.Collections;

/**
 * Abstract representation of the maze.
 */
public class Maze {
	MazeGenerator Gen;
	public int Size;
	public Row[] Rows;
	private int CurrentRow;
	
	public Maze(MazeGenerator gen, int size) {
		Gen = gen;
		Size = size;
		Rows = new Row[Size];
		CurrentRow = 0;
	}
	public Row AddRow(bool allWalls=false) {
		Row row = new Row(Gen, Size, CurrentRow, allWalls);
		Rows[CurrentRow++] = row;
		return row;
	}
	
	public override string ToString() {
		string result = "";
		for (int row = 0; row < Size; row++) {
			for (int col = 0; col < Size; col++) {
				result += Rows[row].Cells[col].IsWall ? "XX" : "  ";
			}
			result += "\n";
		}
		return result;
	}
}
