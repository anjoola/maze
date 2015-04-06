using System.Collections;

public class Cell {
	public MazeGenerator Gen;
	public bool IsWall;
	public int SetNumber;
	
	public int RowNumber;
	public int ColNumber;
	
	public Cell(MazeGenerator gen, bool wall, int number) {
		Gen = gen;
		IsWall = wall;
		SetNumber = number;
		
		RowNumber = number / Gen.CurrentMaze.Size;
		ColNumber = number % Gen.CurrentMaze.Size;
		
		Gen.SetToCells[number] = new ArrayList();
		Gen.SetToCells[number].Add(this);
	}
	public void ChangeSetNumber(int number) {
		// Merge the cells from the old set with the new set.
		while (Gen.SetToCells[SetNumber].Count > 0) {
			Cell cell = (Cell)Gen.SetToCells[SetNumber][0];
			Gen.SetToCells[SetNumber].RemoveAt(0);
			Gen.SetToCells[number].Add(cell);
		}
		SetNumber = number;
	}
	public void ChangeType(bool toWall) {
		IsWall = toWall;
		Gen.CellTypeChangedCallback(RowNumber, ColNumber, toWall);
	}
	public void DestroySetNumber() {
		Gen.SetToCells[SetNumber].Remove(this);
	}
	public Cell GetCellBelow() {
		return Gen.CurrentMaze.Rows[RowNumber + 2].Cells[ColNumber];
	}
	public Cell GetWallBelow() {
		return Gen.CurrentMaze.Rows[RowNumber + 1].Cells[ColNumber];
	}
}
